using System.Web.Mvc;
using DemoApp.Domain;
using DemoApp.Repository.Services;
using DemoApp.Services.Services;

namespace DemoApp.web.Controllers
{
    public class EditController : Controller
    {

        private readonly IEditService _editServices;
        private readonly IStartService _iservices;
        private readonly IAdminService _iadmin;

        public EditController(IEditService eServices,  IStartService iservices, IAdminService iadmin)
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
            
            return View(_editServices.GetAllPackages());
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
           
            return View(_iadmin.GetComponents(id));
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
           
            return View(_iservices.GetComponentTypeList(id));
        }

        [HttpGet]
        public ActionResult EditComponentType(int id)
        {
            
            return View(_iservices.GetSingleComponentType(id));
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
            return View(_editServices.GetAllOrders());
        }

        [HttpGet]
        public ActionResult EditOrder(int id)
        {
            return View(_editServices.GetSingleOrder(id));
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