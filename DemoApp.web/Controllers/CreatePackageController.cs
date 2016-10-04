using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using DemoApp.Domain;
using DemoApp.Repository.Services;
using DemoApp.web.Models;

namespace DemoApp.web.Controllers
{
    [Authorize]
    public class CreatePackageController : Controller
    {
        private readonly IServices _iservices;

        public CreatePackageController(IServices services)
        {
            _iservices = services;
        }
        // GET: CreatePackage
        public ActionResult Create(int id)
        {
            //var listan = (List<ComponentType>) Session["MyCart"];
            //listan.Clear();
            BuildPackage model = new BuildPackage();
            model.Package = _iservices.GetSinglePackage(id);
            model.Component = _iservices.GetComponetsNdTypes(model.Package.Id);

            return View(model);
        }

        public PartialViewResult GetComponents(int id)
        {
            var comp = _iservices.GetComponent(id);

            return PartialView("Partials/LisOfComponents", comp);
        }

        public PartialViewResult GetTypes(int id)
        {
            var typ = _iservices.GetComponentTypeList(id);

            return PartialView("Partials/ListOfComponentTyes", typ);
        }

        [HttpGet]
        public PartialViewResult PreviuosCartPartialViewResult(int id )
        {
            var ct = _iservices.GetSingleComponentType(id);

            MyCart model = new MyCart();

            if ((List<ComponentType>)Session["MyCart"] == null)
            {
                model.ComponentTypes.Add(ct);
            }
            else
            {
                model.ComponentTypes = (List<ComponentType>)Session["MyCart"];
                model.ComponentTypes.Add(ct);
            }

            Session["MyCart"] = model.ComponentTypes;

            

            return PartialView("Partials/PreviousCart", model);
        }
    }
}