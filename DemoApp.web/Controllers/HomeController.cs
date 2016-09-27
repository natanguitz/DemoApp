using System.Web.Mvc;
using DemoApp.Repository;

namespace DemoApp.web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
             var packageTypes = new Services().GetPackageTypes();
            
            return View(packageTypes);
        }


        [HttpGet]
        public PartialViewResult GetPacks(int id)
        {
            var objAllPacks= new Services().GetPackagesById(id);
            return PartialView("Partials/PackagesTypesViewModel", objAllPacks);
      
        }

        //method ends
    }
}