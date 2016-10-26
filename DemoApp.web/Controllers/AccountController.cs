using System;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DemoApp.Data;
using DemoApp.Domain;
using DemoApp.web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace DemoApp.web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // GET: Account
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]

        public ActionResult Login(string username, string password, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            var appContext = new DemoAppContext();
            var userStore = new UserStore<AppUser>(appContext);
            var userManager = new UserManager<AppUser>(userStore);
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            var signInManager = new SignInManager<AppUser, string>(userManager, authenticationManager);

            var result = signInManager.PasswordSignIn(username, password,
                isPersistent: false, shouldLockout: false);

            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View();
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Register(string returnurl)
        {
            ViewBag.ReturnUrl = returnurl;

            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterUser model)
        {

            var context  = new DemoAppContext();
            var userstore = new UserStore<AppUser>(context);
            var usermanager = new UserManager<AppUser>(userstore);
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            var singInManager = new SignInManager<AppUser, string>(usermanager, authenticationManager);




            if (ModelState.IsValid)
            {
                var user = new AppUser() { UserName = model.FirstName + model.LastName, FirstName =  model.FirstName, Email = model.Email, LastName = model.LastName, CompanyName = model.CompanyName, DeliveryAdress = model.DeliveryAdress};
                var result = await usermanager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await singInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);


                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }
            return View(model);
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}