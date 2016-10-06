using System;
using System.Collections.Generic;
using System.Linq;
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
            if ((List<ComponentType>)Session["MyCart"] != null)
            {
                Session["MyCart"] = _iservices.CleanList((List<ComponentType>)Session["MyCart"]);
            }
            

            BuildPackage model = new BuildPackage();
            model.Package = _iservices.GetSinglePackage(id);
            model.Component = _iservices.GetComponetsNdTypes(model.Package.Id);
            TempData["packageid"] = model.Package;

            return View(model);
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

                if (!_iservices.CheckIfExist(model.ComponentTypes, ct))
                {
                    model.ComponentTypes.Add(ct);
                }               
            }

            model.PreviousCost = _iservices.FinalPrice(model.ComponentTypes);
            model.Package = (Package)TempData["packageid"];

            Session["MyCart"] = model.ComponentTypes;

            return PartialView("Partials/PreviousCart", model);
        }
    }
}