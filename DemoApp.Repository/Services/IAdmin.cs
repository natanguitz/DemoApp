using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DemoApp.Domain;

namespace DemoApp.Repository.Services
{
    public interface IAdmin
    {
        void SaveNewPackageType(string name);
        List<SelectListItem> PackageTypeItems();
        List<Package> PackageItems();
        List<SelectListItem> ComponentItems(int? id);
        void CreateAPackage(Package package);
        void CreateComponent(Component component);
        List<Component> GetComponents(int id);
        void SaveNewComponentType(ComponentType type);
        List<SelectListItem> PackageItemsList();
    }
}
