using System.Collections.Generic;
using DemoApp.Domain;

namespace DemoApp.Services.Repositories
{
    public interface IStartRepository
    {
        List<PackageType> GetPackageTypes();
        List<Package> GetPackagesById(int id);
        Package GetSinglePackage(int id);
        List<ComponentType> GetComponentTypeList(int id);
        ComponentType GetSingleComponentType(int id);
        IList<Component> GetComponetsNdTypes(int id);
        decimal FinalPrice(List<ComponentType> prices);
        bool CheckIfExist(List<ComponentType> list, ComponentType type);
        List<ComponentType> CleanList(List<ComponentType> list);
        void GetCurrentUser();
        List<Order> GetMyOrders(string name);
    }
}
