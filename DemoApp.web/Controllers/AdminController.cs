using System.Web.Mvc;
using DemoApp.Repository.Services;

namespace DemoApp.web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IOrders _iservices;

        public AdminController(IOrders services)
        {
            _iservices = services;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}