using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DemoApp.Data;
using DemoApp.Domain;
using DemoApp.Repository.Services;

namespace DemoApp.Repository
{
    public class MyServices : IServices
    {
        //first code lines 


        public List<PackageType> GetPackageTypes()
        {
            using (var db = new DemoAppContext())
            {
                var pt = db.PackageTypes.ToList();
               

                return pt;

            }
        }

        public List<Package> GetPackagesById(int id)
        {
            using (var db = new DemoAppContext())
            {
                var packs = db.Packages.Where(x => x.PackakeTypeId == id).ToList();
                return packs;
            }
        }

        public Package GetSinglePackage(int id)
        {
            using (var db = new DemoAppContext() )
            {
                var sp = db.Packages.SingleOrDefault(x => x.Id == id);
                return sp;
            }
        }

        public List<Component> GetComponent(int id)
        {
            using (var db = new DemoAppContext())
            {
                var allComponents = db.Components.Where(x => x.PackageId == id).ToList();
                return allComponents;
            }
        }

        public List<ComponentType> GetComponentTypeList(int id)
        {
            using (var db = new DemoAppContext())
            {
                var types = db.ComponentTypes.Where(x => x.Component.Id == id).ToList();
                return types;
            }
        }

        public ComponentType GetSingleComponentType(int id)
        {
            using (var context = new DemoAppContext())
            {
                var type = context.ComponentTypes.SingleOrDefault(x => x.Id == id);
                return type;
            }
        }


        public IList<Component> GetComponetsNdTypes(int id )
        {
            using (var context = new DemoAppContext())
            {
                var list = context.Components.Where(x => x.PackageId == id).Include(x => x.ComponentTypes).ToList();
                return list;
            }
        }

        public decimal FinalPrice(List<ComponentType> prices)
        {
            decimal total = prices.Sum(x => x.Price);
            return total;
        }


        public bool CheckIfExist(List<ComponentType> list ,ComponentType type)
        {
            bool check = list.Any(x => x.ComponentId == type.ComponentId);

            return check;
        }

        public List<ComponentType> CleanList(List<ComponentType> list )
        {
            list.Clear();
            return list;
        }

        public bool CheckItems(List<ComponentType> list)
        {
            bool check = list.Any(x => x.Id == 1 && x.Id == 2 && x.Id == 3);

            return check;
        }



        //ending code lines 
    }
}
 