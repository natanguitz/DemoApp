using System.Collections.Generic;
using DemoApp.Domain;

namespace DemoApp.Repository.Services
{
    public interface IServices
    {
        List<PackageType> GetPackageTypes();

        List<Package> GetPackagesById(int id);

        Package GetSinglePackage(int id);

        List<Component> GetComponent(int id);

        List<ComponentType> GetComponentTypeList(int id);

        ComponentType GetSingleComponentType(int id);

        IList<Component> GetComponetsNdTypes(int id);

        decimal FinalPrice(List<ComponentType> prices);

    }
}
