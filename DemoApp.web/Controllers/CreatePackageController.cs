using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DemoApp.Domain;
using DemoApp.Repository.Services;
using DemoApp.Services.Services;
using DemoApp.web.Models;


namespace DemoApp.web.Controllers
{
    [Authorize]
    public class CreatePackageController : Controller
    {
        private readonly IStartService _iservices;
        private readonly IOrderService _iorders;

        public CreatePackageController(IStartService services, IOrderService iorders)
        {
            _iservices = services;
            _iorders = iorders;
        }

        // GET: CreatePackage
        public ActionResult Create(int id)
        {

            // clean list if user going to start to build a new 

            if ((List<ComponentType>) Session["MyCart"] != null)
            {
                Session["MyCart"] = _iservices.CleanList((List<ComponentType>) Session["MyCart"]);
            }

            //instance View model 
            BuildPackage buildPackage = new BuildPackage();
            buildPackage.Package = _iservices.GetSinglePackage(id);
            buildPackage.Component = _iservices.GetComponetsNdTypes(buildPackage.Package.Id);

            // save package in the session 
            Session["packageToSend"] = buildPackage.Package;

            return View(buildPackage);
        }

        [HttpGet]
        public PartialViewResult PreviuosCartPartialViewResult(int id)
        {
            var ct = _iservices.GetSingleComponentType(id);


            // instance view model 

            MyCart cart = new MyCart();

            if ((List<ComponentType>) Session["MyCart"] == null)
            {

                cart.ListTypes.Add(ct);
            }
            else
            {

                cart.ListTypes = (List<ComponentType>) Session["MyCart"];

                if (!_iservices.CheckIfExist(cart.ListTypes, ct))
                {
                    cart.ListTypes.Add(ct);
                }
            }

            cart.BasicPrice = _iservices.FinalPrice(cart.ListTypes);
            cart.PackObject = (Package) Session["packageToSend"];

            Session["MyCart"] = cart.ListTypes;
            TempData["MyObject"] = cart;

            return PartialView("Partials/PreviousCart", cart);
        }

        public ActionResult SendOrderViewResult(MyCart toOrderCart)
        {
            if (toOrderCart == null) throw new ArgumentNullException(nameof(toOrderCart));
            toOrderCart = (MyCart) TempData["MyObject"];
            toOrderCart.FinalPrice = _iorders.GetFinalPrice(toOrderCart.ListTypes, toOrderCart.PackObject.InitialPrice);
            TempData["ToOrder"] = toOrderCart;

            return View("PreviosOrder", toOrderCart);

        }


        public ActionResult SaveOrder(MyCart cartData)
        {
                if (cartData == null) throw new ArgumentNullException(nameof(cartData));
                cartData = (MyCart)TempData["ToOrder"];
                    Order myOrder = new Order
                    {
                        Customer = User.Identity.Name,
                        FinalPrice = _iorders.GetFinalPrice(cartData.ListTypes, cartData.PackObject.InitialPrice),
                        OrderCode = _iorders.GetCode(cartData.ListTypes),
                        PackageId = cartData.PackObject.Id,
                        OrderState = OrderState.New,
                        DeliveryDate = _iorders.GetDeliveryDate(cartData.ListTypes)
                    };

                    _iorders.SaveOrder(myOrder);

                    return View("Thank_You");
        }

    }
}