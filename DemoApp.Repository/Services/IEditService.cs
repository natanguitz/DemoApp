using System.Collections.Generic;
using DemoApp.Domain;

namespace DemoApp.Repository.Services
{
    public interface IEditService
    {
        List<Package> GetAllPackages();
        void EditPackage(Package package);
        Component GetSingleComponent(int id);
        void EditedComponent(Component component);
        void EditedComponentType(ComponentType type);
        List<Order> GetAllOrders();
        Order GetSingleOrder(int id);
        void EditedOrder(Order order);
        void DeleteOrder(Order order);
        void DeleteComponentType(ComponentType type);
        void DeleteComponent(Component component);
        void DeletePackage(int id);
    }
}
