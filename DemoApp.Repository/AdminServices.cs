using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoApp.Data;
using DemoApp.Domain;
using DemoApp.Repository.Services;
using System.Collections;
using System.Data.Entity;
using System.Web.Mvc;

namespace DemoApp.Repository
{
    public class AdminServices : IAdmin
    {
        public void SaveNewPackageType(string name)
        {
            using (var context = new DemoAppContext())
            {
                var npt = new PackageType();
                npt.Name = name;
                context.PackageTypes.Add(npt);
                context.SaveChanges();
            }
        }

        public List<SelectListItem> PackageTypeItems()
        {
            using (var context = new DemoAppContext())
            {
                var list = context.PackageTypes.ToList();
                List<SelectListItem> items = new List<SelectListItem>();
                foreach (var type in list)
                {
                    items.Add(new SelectListItem { Text = type.Name, Value = type.Id.ToString() });
                }
                return items;
            }
        }

        public List<Package> PackageItems()
        {
            using (var context = new DemoAppContext())
            {
                var list = context.Packages.ToList();
                
                
                return list;
            }
        }

        public List<SelectListItem> ComponentItems(int? id)
        {
            using (var context = new DemoAppContext())
            {
                var list = context.Components.Where(x => x.Id == id).ToList();
                List<SelectListItem> items = new List<SelectListItem>();
                foreach (var type in list)
                {
                    items.Add(new SelectListItem { Text = type.Name, Value = type.Id.ToString() });
                }
                return items;
            }
        }

        public void CreateAPackage(Package package)
        {
            using (var context = new DemoAppContext())
            {
                var np = new Package();
                np.Name = package.Name;
                np.Description = package.Description;
                np.ImageUrl = package.ImageUrl;
                np.InitialPrice = package.InitialPrice;
                np.PackakeTypeId = package.PackakeTypeId;
                context.Packages.Add(np);
                context.SaveChanges();
            }
        }

        public void CreateComponent(Component component)
        {
            using (var context = new DemoAppContext())
            {
                Component cp = new Component();
                cp.Name = component.Name;
                cp.ImageUrl = component.ImageUrl;
                cp.PackageId = component.PackageId;
                context.Components.Add(cp);
                context.SaveChanges();
            }   
        }

        public List<Component> GetComponents(int id)
        {
            using (var context = new DemoAppContext())
            {
                var list = context.Components.Where(x => x.PackageId == id).ToList();
                return list;
            }
        }

        public void SaveNewComponentType(ComponentType type)
        {
            using (var context = new DemoAppContext())
            {
                ComponentType model = new ComponentType();
                model.ComponentId = type.ComponentId;
                model.DeliveryDate = type.DeliveryDate;
                model.Description = type.Description;
                model.ImageUrl = type.ImageUrl;
                model.Manufacturer = type.Manufacturer;
                model.Name = type.Name;
                model.Price = type.Price;
                model.TypeCode = type.TypeCode;

                context.ComponentTypes.Add(model);
                context.SaveChanges();
            }
            

            
        }
    }
}