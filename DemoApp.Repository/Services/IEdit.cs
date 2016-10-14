using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoApp.Domain;
using System.Web.Mvc;

namespace DemoApp.Repository.Services
{
    public interface IEdit
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
