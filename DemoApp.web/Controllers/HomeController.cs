using System.Web.Mvc;
using DemoApp.Services.Services;

namespace DemoApp.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStartService _iservices;

        public HomeController(IStartService services)
        {
            _iservices = services;
        }

        // GET: Home
        public ActionResult Index()
        {
            
            var packageTypes = _iservices.GetPackageTypes();

            return View(packageTypes);
        }


        [HttpGet]
        public PartialViewResult GetPacks(int id)
        {
            var objAllPacks = _iservices.GetPackagesById(id);
            return PartialView("Partials/PackagesTypesViewModel", objAllPacks);
        }

        
        public ActionResult GetMyOrders()
        {
            return View(_iservices.GetMyOrders(User.Identity.Name));
        }
        //method ends
    }
}