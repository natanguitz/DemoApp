using System.Web.Mvc;
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
            return View();
        }
        public ActionResult NewComponent()
        {
            return View();
        }

        public ActionResult NewComponentType()
        {
            return View();
        }
    }
}