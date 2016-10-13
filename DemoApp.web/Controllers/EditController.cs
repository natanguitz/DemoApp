using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoApp.Domain;
using DemoApp.Repository.Services;

namespace DemoApp.web.Controllers
{
    public class EditController : Controller
    {

        private readonly IEdit _editServices;
        private readonly IServices _iservices;
        private readonly IAdmin _iadmin;

        public EditController(IEdit eServices,  IServices iservices, IAdmin iadmin)
        {
            _iservices = iservices;
            _editServices = eServices;
            _iadmin = iadmin;

        }
        // GET: Edit
        public ActionResult EditHome()
        {
            return View();
        }

        public ActionResult EditPackage()
        {
            var listOfPackages = _editServices.GetAllPackages();
            return View(listOfPackages);
        }

        [HttpPost]
        public ActionResult EditPackage(Package package)
        {
            _editServices.EditPackage(package);
            return View("Thankyou");
        }


        [HttpGet]
        public ActionResult EditAPackage(int id)
        {
            var package = _iservices.GetSinglePackage(id);
            ViewBag.packagesTypes = _iadmin.PackageTypeItems();
            
            return View("PackageEditForm",package);
        }

        public ActionResult EditComponent()
        {
            return View();
        }

        public ActionResult EditComponentType()
        {
            return View();
        }

        public ActionResult EditOrder()
        {
            return View();
        }
    }
}