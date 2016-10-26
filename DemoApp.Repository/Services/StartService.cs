using System.Collections.Generic;
using DemoApp.Domain;
using DemoApp.Repository.Services;
using DemoApp.Services.Repositories;

namespace DemoApp.Services.Services
{
    public class StartService :IStartService
    {
        private readonly IStartRepository _repository;

        public StartService(IStartRepository repository)
        {
            _repository = repository;
        }
        public List<PackageType> GetPackageTypes()
        {
            return _repository.GetPackageTypes();
        }

        public List<Package> GetPackagesById(int id)
        {
            return _repository.GetPackagesById(id);
        }

        public Package GetSinglePackage(int id)
        {
            return _repository.GetSinglePackage(id);
        }

        public List<ComponentType> GetComponentTypeList(int id)
        {
            return _repository.GetComponentTypeList(id);
        }

        public ComponentType GetSingleComponentType(int id)
        {
            return _repository.GetSingleComponentType(id);
        }

        public IList<Component> GetComponetsNdTypes(int id)
        {
            return _repository.GetComponetsNdTypes(id);
        }

        public decimal FinalPrice(List<ComponentType> prices)
        {

            return _repository.FinalPrice(prices);
        }

        public bool CheckIfExist(List<ComponentType> list, ComponentType type)
        {
            return _repository.CheckIfExist(list, type);
        }

        public List<ComponentType> CleanList(List<ComponentType> list)
        {
            return _repository.CleanList(list);
        }

        public List<Order> GetMyOrders(string name)
        {
            return _repository.GetMyOrders(name);
        }
    }
}
