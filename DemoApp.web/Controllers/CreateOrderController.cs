using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoApp.Domain;
using DemoApp.Repository.Services;
using DemoApp.web.Models;

namespace DemoApp.web.Controllers
{

    public class CreateOrderController : Controller
    {
        private readonly IOrders _iorders;

        public CreateOrderController(IOrders orders)
        {
            _iorders = orders;
        }
        // GET: CreateOrder
        

        [HttpPost]
        public ActionResult NewOrder(MyCart cart)
        {
            MyCart model = new MyCart();
            model.ComponentTypes = cart.ComponentTypes;
            model.PreviousCost = cart.PreviousCost;
            model.Package = cart.Package;
            
            return View(model);
        }

        //public ActionResult SaveOrdeResult(MyCart cart)
        //{
        //    //Order order = new Order();
        //    //order.OrderCode = _iOrders.GetCode(cart.ComponentTypes);
        //    //order.PackageId = _iOrders.GetSinglePackageId(cart.Package.Id);
        //    //order.FinalPrice = cart.PreviousCost;
        //    //order.OrderState = OrderState.New;
        //    //order.Customer = User.Identity.Name;
        //    //_iOrders.SaveOrder(order);
        //    //return RedirectToAction("Index", "Home");
        //}
    }
}