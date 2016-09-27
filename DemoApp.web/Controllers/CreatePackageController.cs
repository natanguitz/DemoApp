using System.Collections.Generic;
using System.Web.Mvc;
using DemoApp.Domain;
using DemoApp.Repository;
using DemoApp.web.Models;

namespace DemoApp.web.Controllers
{
    [Authorize]
    public class CreatePackageController : Controller
    {
        // GET: CreatePackage
        public ActionResult Create(int id)
        {        
            
            BuildPackage model = new BuildPackage();
            model.Package = new Services().GetSinglePackage(id);
            model.Component = new Services().GetComponetsNdTypes(model.Package.Id);

            return View(model);
        }

        public PartialViewResult GetComponents(int id)
        {

            var comp = new Services().GetComponent(id);

            return PartialView("Partials/LisOfComponents", comp);
        }

        public PartialViewResult GetTypes(int id)
        {
            var typ = new Services().GetComponentTypeList(id);

            return PartialView("Partials/ListOfComponentTyes", typ);
        }
    }
}