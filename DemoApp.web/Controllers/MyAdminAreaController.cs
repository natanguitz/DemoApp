using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoApp.web.Controllers
{
    public class MyAdminAreaController : Controller
    {
        // GET: MyAdminArea
        public ActionResult Index()
        {
            return View();
        }
    }
}