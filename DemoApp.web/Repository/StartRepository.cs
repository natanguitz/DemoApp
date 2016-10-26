using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DemoApp.Data;
using DemoApp.Domain;
using DemoApp.Services.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace DemoApp.web.Repository
{
    public class StartRepository : IStartRepository
    {

        readonly DemoAppContext _context = new DemoAppContext();
        public List<PackageType> GetPackageTypes()
        {

            return _context.PackageTypes.ToList();
        }

        public List<Package> GetPackagesById(int id)
        {

            return _context.Packages.Where(x => x.PackakeTypeId == id).ToList();
        }

        public Package GetSinglePackage(int id)
        {

            return _context.Packages.SingleOrDefault(x => x.Id == id);
        }

        public List<ComponentType> GetComponentTypeList(int id)
        {

            return _context.ComponentTypes.Where(x => x.ComponentId == id).ToList();

        }

        public ComponentType GetSingleComponentType(int id)
        {
            return _context.ComponentTypes.SingleOrDefault(x => x.Id == id);
        }

        public IList<Component> GetComponetsNdTypes(int id)
        {
            return _context.Components.Where(x => x.PackageId == id).Include(x => x.ComponentTypes).ToList();
        }

        public decimal FinalPrice(List<ComponentType> prices)
        {
            return prices.Sum(x => x.Price);
        }

        public bool CheckIfExist(List<ComponentType> list, ComponentType type)
        {
            return list.Any(x => x.ComponentId == type.ComponentId);
        }

        public List<ComponentType> CleanList(List<ComponentType> list)
        {
            list.Clear();
            return list;
        }

        public void GetCurrentUser()
        {
            
        }

        public List<Order> GetMyOrders(string name)
        {
            return _context.Orders.Where(x => x.Customer == name).ToList();

        }
    }
}