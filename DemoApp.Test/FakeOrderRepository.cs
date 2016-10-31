using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DemoApp.Domain;
using DemoApp.Repository.Services;
using DemoApp.Services.Repositories;


namespace DemoApp.Test
{
    public class FakePackageRepository : IStartRepository
    {
        public List<PackageType> GetPackageTypes()
        {
            throw new NotImplementedException();
        }

        public List<Package> GetPackagesById(int id)
        {
            throw new NotImplementedException();
        }

        public Package GetSinglePackage(int id)
        {
            var pack = new Package()
            {
                Id = id,
                Name = "Car"
            };
            var comp = new Component()
            {

                Name = "comp1",
                PackageId = pack.Id
            };
            pack.Components = new List<Component>();
            pack.Components.Add(comp);

            var type = new ComponentType()
            {

                Name = "Blue",
                ComponentId = comp.Id
            };
            comp.ComponentTypes = new List<ComponentType>();
            comp.ComponentTypes.Add(type);

            return pack;

        }

        public List<ComponentType> GetComponentTypeList(int id)
        {
            throw new NotImplementedException();
        }

        public ComponentType GetSingleComponentType(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Component> GetComponetsNdTypes(int id)
        {
            throw new NotImplementedException();
        }

        public decimal FinalPrice(List<ComponentType> prices)
        {
            throw new NotImplementedException();
        }

        public bool CheckIfExist(List<ComponentType> list, ComponentType type)
        {
            throw new NotImplementedException();
        }

        public List<ComponentType> CleanList(List<ComponentType> list)
        {
            throw new NotImplementedException();
        }

        public void GetCurrentUser()
        {
            throw new NotImplementedException();
        }

        public List<Order> GetMyOrders(string name)
        {
            throw new NotImplementedException();
        }
    }
}
