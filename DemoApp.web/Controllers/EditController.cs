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

        public ActionResult DeletePackage(int id)
        {
            _editServices.DeletePackage(id);

            return RedirectToAction("EditPackage");
        }


        [HttpGet]
        public ActionResult GetAllComponents(int id)
        {
            var listAllPackages = _iadmin.GetComponents(id);
            return View(listAllPackages);
        }

        [HttpGet]
        public ActionResult EditComponent(int id)
        {
            var comp = _editServices.GetSingleComponent(id);
            ViewBag.packageitems = _iadmin.PackageItemsList();  
            return View(comp);
        }

        [HttpPost]
        public ActionResult ComponentEdited(Component component)
        {
            _editServices.EditedComponent(component);

            return View("ThankYou");
        }

        [HttpGet]
        public ActionResult DeleteComponent(Component component)
        {
            _editServices.DeleteComponent(component);

            return RedirectToAction("EditPackage");
        }

        [HttpGet]
        public ActionResult GetAllComponentTypes(int id)
        {
            var list = _iservices.GetComponentTypeList(id);
            return View(list);
        }

        [HttpGet]
        public ActionResult EditComponentType(int id)
        {
            var type = _iservices.GetSingleComponentType(id);
            return View(type);
        }

        [HttpPost]
        public ActionResult ComponentTypeEdited(ComponentType type)
        {
            _editServices.EditedComponentType(type);

            return View("ThankYou");
        }

        public ActionResult DeleteComponentType(ComponentType type)
        {
            _editServices.DeleteComponentType(type);
            return RedirectToAction("EditPackage");
        }


        public ActionResult AllOrders()
        {
            var allOrders = _editServices.GetAllOrders();
            return View(allOrders);
        }

        [HttpGet]
        public ActionResult EditOrder(int id)
        {
            Order order = _editServices.GetSingleOrder(id);
            return View(order);
        }

        [HttpPost]
        public ActionResult OrderEdited(Order order)
        {
            _editServices.EditedOrder(order);
            return RedirectToAction("AllOrders");
        }

        [HttpGet]
        public ActionResult OrderToDelete(Order order)
        {
            _editServices.DeleteOrder(order);
            return RedirectToAction("AllOrders");
        }
    }
}