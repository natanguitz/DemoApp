using System.Web.Mvc;
using DemoApp.Repository.Services;

namespace DemoApp.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServices _iservices;

        public HomeController(IServices services)
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
        //method ends
    }
}