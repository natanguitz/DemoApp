using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoApp.Data;
using DemoApp.Domain;
using DemoApp.Repository.Services;
using System.Collections;
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

        public List<SelectListItem> PackageItems()
        {
            using (var context = new DemoAppContext())
            {
                var list = context.Packages.ToList();
                List<SelectListItem> items = new List<SelectListItem>();
                foreach (var package in list)
                {
                    items.Add(new SelectListItem { Text = package.Name, Value = package.Id.ToString() });
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
    }
}