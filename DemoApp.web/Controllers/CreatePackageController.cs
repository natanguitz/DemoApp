using System;
using System.Collections.Generic;
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
        private readonly IOrders _iorders;

        public CreatePackageController(IServices services, IOrders iorders)
        {
            _iservices = services;
            _iorders = iorders;
        }

        // GET: CreatePackage
        public ActionResult Create(int id)
        {
            if ((List<ComponentType>) Session["MyCart"] != null)
            {
                Session["MyCart"] = _iservices.CleanList((List<ComponentType>) Session["MyCart"]);
            }


            BuildPackage buildPackage = new BuildPackage();
            buildPackage.Package = _iservices.GetSinglePackage(id);
            buildPackage.Component = _iservices.GetComponetsNdTypes(buildPackage.Package.Id);
            Session["packageToSend"] = buildPackage.Package;

            return View(buildPackage);
        }

        [HttpGet]
        public PartialViewResult PreviuosCartPartialViewResult(int id)
        {
            var ct = _iservices.GetSingleComponentType(id);

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

            if (ModelState.IsValid)
            {
                Order myOrder = new Order();
                myOrder.Customer = User.Identity.Name;
                myOrder.FinalPrice = _iorders.GetFinalPrice(cartData.ListTypes, cartData.PackObject.InitialPrice);
                myOrder.OrderCode = _iorders.GetCode(cartData.ListTypes);
                myOrder.PackageId = cartData.PackObject.Id;
                myOrder.OrderState = OrderState.New;
                myOrder.DeliveryDate = _iorders.GetDeliveryDate(cartData.ListTypes);
                _iorders.SaveOrder(myOrder);

                return View("Thank_You");
            }
            else
            {
                return View("PreviosOrder", cartData);
            }
            
        }

    }
}