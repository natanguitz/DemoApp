using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DemoApp.Data;
using DemoApp.Domain;
using DemoApp.Services.Repositories;

namespace DemoApp.web.Repository
{
    public class AdminRepository : IAdminRepository
    {
        readonly DemoAppContext _context = new DemoAppContext();
        public void SaveNewPackageType(string name)
        {
            var newpackagetype = new PackageType { Name = name };
            _context.PackageTypes.Add(newpackagetype);
            _context.SaveChanges();
        }

        public List<SelectListItem> PackageTypeItems()
        {
            var allpackagetypes = _context.PackageTypes.ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var type in allpackagetypes)
            {
                items.Add(new SelectListItem { Text = type.Name, Value = type.Id.ToString() });
            }
            return items;
        }

        public List<Package> PackageItems()
        {

            return _context.Packages.ToList();
        }

        public List<SelectListItem> ComponentItems(int? id)
        {

            var componentslist = _context.Components.Where(x => x.Id == id).ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var component in componentslist)
            {
                items.Add(new SelectListItem { Text = component.Name, Value = component.Id.ToString() });
            }
            return items;
        }

        public void CreateAPackage(Package package)
        {
            var np = new Package
            {
                Name = package.Name,
                Description = package.Description,
                ImageUrl = package.ImageUrl,
                InitialPrice = package.InitialPrice,
                PackakeTypeId = package.PackakeTypeId
            };
            _context.Packages.Add(np);
            _context.SaveChanges();

        }

        public void CreateComponent(Component component)
        {
            Component cp = new Component
            {
                Name = component.Name,
                ImageUrl = component.ImageUrl,
                PackageId = component.PackageId
            };
            _context.Components.Add(cp);
            _context.SaveChanges();
        }

        public List<Component> GetComponents(int id)
        {
            return _context.Components.Where(x => x.PackageId == id).ToList();
        }

        public void SaveNewComponentType(ComponentType type)
        {
            ComponentType model = new ComponentType
            {
                ComponentId = type.ComponentId,
                DeliveryDate = type.DeliveryDate,
                Description = type.Description,
                ImageUrl = type.ImageUrl,
                Manufacturer = type.Manufacturer,
                Name = type.Name,
                Price = type.Price,
                TypeCode = type.TypeCode
            };
            _context.ComponentTypes.Add(model);
            _context.SaveChanges();
        }

        public List<SelectListItem> PackageItemsList()
        {
            var list = _context.Packages.ToList();
            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var package in list)
            {
                items.Add(new SelectListItem { Text = package.Name, Value = package.Id.ToString() });
            }
            return items;
        }
    }
}