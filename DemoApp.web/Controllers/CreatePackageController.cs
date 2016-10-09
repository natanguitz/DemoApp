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
            

            BuildPackage buildPackage = new BuildPackage();
            buildPackage.Package = _iservices.GetSinglePackage(id);
            buildPackage.Component = _iservices.GetComponetsNdTypes(buildPackage.Package.Id);
            Session["packageToSend"] = buildPackage.Package;

            return View(buildPackage);
        }

        [HttpGet]
        public PartialViewResult PreviuosCartPartialViewResult(int id )
        {
            var ct = _iservices.GetSingleComponentType(id);

            MyCart cart = new MyCart();

            if ((List<ComponentType>)Session["MyCart"] == null)
            {
                
                cart.ListTypes.Add(ct);
            }
            else
            {

                cart.ListTypes = (List<ComponentType>)Session["MyCart"];

                if (!_iservices.CheckIfExist(cart.ListTypes, ct))
                {
                    cart.ListTypes.Add(ct);
                }               
            }

            cart.BasicPrice = _iservices.FinalPrice(cart.ListTypes);
            cart.PackObject = (Package)Session["packageToSend"];

            Session["MyCart"] = cart.ListTypes;
            TempData["MyObject"] = cart;

            return PartialView("Partials/PreviousCart", cart);
        }

        public ActionResult TestActionResult(MyCart toOrderCart)
        {
            if (toOrderCart == null) throw new ArgumentNullException(nameof(toOrderCart));
            toOrderCart = (MyCart)TempData["MyObject"];

            return View("PreviosOrder", toOrderCart);
            
        }
    }
}