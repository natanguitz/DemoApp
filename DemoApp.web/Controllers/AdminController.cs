using System.Collections.Generic;
using System.Web.Mvc;
using DemoApp.Domain;
using DemoApp.Repository.Services;

namespace DemoApp.web.Controllers
{
    [Authorize(Roles = "admins")]
    public class AdminController : Controller
    {
        private readonly IAdmin _iservices;

        public AdminController(IAdmin services)
        {
            _iservices = services;
        }
        // GET: Admin
     
        public ActionResult AdminIndex()
        {
            return View();
        }
        public ActionResult NewPackageType()
        {

            return View();
        }
        [HttpPost]
        public ActionResult NewPackageType(string name )
        {
            _iservices.SaveNewPackageType(name);
            return View("ThankYou");
        }
        public ActionResult NewPackage()
        {
            ViewBag.items = _iservices.PackageTypeItems();
            return View();
        }
        [HttpPost]
        public ActionResult NewPackage(Package package)
        {
            _iservices.CreateAPackage(package);
            return View("ThankYou");
        }
        public ActionResult NewComponent()
        {
            ViewBag.items = _iservices.PackageItems();
            return View();
        }
        [HttpPost]
        public ActionResult NewComponent(Component component)
        {
            _iservices.CreateComponent(component);
            return View("ThankYou");
        }

        public ActionResult NewComponentType()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewComponentType(ComponentType type)
        {
            return View("ThankYou");
        }
    }
}