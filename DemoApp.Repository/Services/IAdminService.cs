using System.Collections.Generic;
using System.Web.Mvc;
using DemoApp.Domain;

namespace DemoApp.Services.Services
{
    public interface IAdminService
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
