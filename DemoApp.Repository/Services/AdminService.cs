using System.Collections.Generic;
using System.Web.Mvc;
using DemoApp.Domain;
using DemoApp.Repository.Services;
using DemoApp.Services.Repositories;

namespace DemoApp.Services.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _repository;

        public AdminService(IAdminRepository repository)
        {
            _repository = repository;
        }

        public void SaveNewPackageType(string name)
        {
            _repository.SaveNewPackageType(name);
        }

        public List<SelectListItem> PackageTypeItems()
        {
            return  _repository.PackageTypeItems();
        }

        public List<Package> PackageItems()
        {
            return _repository.PackageItems();
        }

        public List<SelectListItem> ComponentItems(int? id)
        {
            return _repository.ComponentItems(id);
        }

        public void CreateAPackage(Package package)
        {
            _repository.CreateAPackage(package);
        }

        public void CreateComponent(Component component)
        {
           _repository.CreateComponent(component);
        }

        public List<Component> GetComponents(int id)
        {
            return _repository.GetComponents(id);
        }

        public void SaveNewComponentType(ComponentType type)
        {
            _repository.SaveNewComponentType(type);
        }

        public List<SelectListItem> PackageItemsList()
        {
            return _repository.PackageItemsList();
        }
    }
}
