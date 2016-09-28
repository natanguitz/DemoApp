using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        [HttpGet]
        public PartialViewResult PreviuosCartPartialViewResult(int id )
        {
            var ct = new Services().GetSingleComponentType(id);
            MyCart model = new MyCart();

            if ((List<ComponentType>)Session["MyCart"] == null)
            {
                model.ComponentTypes.Add(ct);
            }
            else
            {
                model.ComponentTypes = (List<ComponentType>)Session["MyCart"];
            }

            
            model.ComponentTypes.Add(ct);
            model.PreviousCost = new Services().FinalPrice(model.ComponentTypes);
           


           Session["MyCart"] = model.ComponentTypes;

            return PartialView("Partials/PreviousCart", model);
        }
    }
}