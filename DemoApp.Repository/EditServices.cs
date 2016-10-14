using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DemoApp.Data;
using DemoApp.Domain;
using DemoApp.Repository.Services;

namespace DemoApp.Repository
{
    public class EditServices : IEdit
    {
        public List<Package> GetAllPackages()
        {
            using (var context = new DemoAppContext())
            {
                var list = context.Packages.ToList();
                return list;
            }
        }

        public void EditPackage(Package package)
        {
            using (var context = new DemoAppContext())
            {
                Package oldpack = context.Packages.SingleOrDefault(x => x.Id == package.Id);

                if (oldpack != null)
                {
                    oldpack.Description = package.Description;
                    oldpack.ImageUrl = package.ImageUrl;
                    oldpack.InitialPrice = package.InitialPrice;
                    oldpack.Name = package.Name;
                    oldpack.PackakeTypeId = package.PackakeTypeId;
                    context.SaveChanges();
                }
            }
        }

        public Component GetSingleComponent(int id)
        {
            using (var context = new DemoAppContext())
            {
                var component = context.Components.SingleOrDefault(x => x.Id == id);
                return component;
            }
        }

        public void EditedComponent(Component component)
        {
            using (var context = new DemoAppContext())
            {
                Component old = context.Components.SingleOrDefault(z => z.Id == component.Id);
                if (old != null)
                {
                    old.Name = component.Name;
                    old.ImageUrl = component.ImageUrl;
                    old.PackageId = component.PackageId;
                    old.ComponentTypes = component.ComponentTypes;

                    context.SaveChanges();
                }
            }
        }

        public void EditedComponentType(ComponentType coming)
        {

            using (var context = new DemoAppContext())
            {
                ComponentType old = context.ComponentTypes.FirstOrDefault(x => x.Id == coming.Id);

                if (old != null)
                {
                    old.ComponentId = coming.ComponentId;
                    old.DeliveryDate = coming.DeliveryDate;
                    old.Description = coming.Description;
                    old.ImageUrl = coming.ImageUrl;
                    old.Manufacturer = coming.Manufacturer;
                    old.Name = coming.Name;
                    old.Price = coming.Price;
                    old.TypeCode = coming.TypeCode;
                    context.SaveChanges();
                }
            }
            
        }

        public List<Order> GetAllOrders()
        {
            using (var context = new DemoAppContext())
            {
                var allOrders = context.Orders.ToList();
                return allOrders;
            }
        }

        public Order GetSingleOrder(int id)
        {
            using (var context = new DemoAppContext())
            {
                Order order = context.Orders.SingleOrDefault(x => x.Id == id);
                return order;
            }
        }

        public void EditedOrder(Order order)
        {
            using (var context = new DemoAppContext())
            {
                Order old = context.Orders.SingleOrDefault(x => x.Id == order.Id);

                if (old != null)
                {
                    old.PackageId = order.PackageId;
                    old.Customer = order.Customer;
                    old.DeliveryDate = order.DeliveryDate;
                    old.FinalPrice = order.FinalPrice;
                    old.OrderCode = order.OrderCode;
                    old.OrderState = order.OrderState;
                }
                context.SaveChanges();
            }
            
        }

        public void DeleteOrder(Order order)
        {
            using (var context = new DemoAppContext())
            {
                var orderToDelete = context.Orders.SingleOrDefault(x => x.Id == order.Id);
                context.Orders.Remove(orderToDelete);
                context.SaveChanges();
            }
        }

        public void DeleteComponentType(ComponentType type)
        {
            using (var context = new DemoAppContext())
            {
                var typetodelete = context.ComponentTypes.SingleOrDefault(x => x.Id == type.Id);
                context.ComponentTypes.Remove(typetodelete);
                context.SaveChanges();
            }

        }

        public void DeleteComponent(Component component)
        {
            using (var context = new DemoAppContext())
            {
                var todelete = context.Components.SingleOrDefault(x => x.Id == component.Id);
                var types = context.ComponentTypes.Where(x => x.ComponentId == component.Id).ToList();

                foreach (var componentType in types)
                {
                    context.ComponentTypes.Remove(componentType);
                    context.SaveChanges();
                }

                context.Components.Remove(todelete);
                context.SaveChanges();

            }
        }

        public void DeletePackage(int id)
        {

            using (var  context = new DemoAppContext())
            {
                var todelete = context.Packages.SingleOrDefault(x => x.Id == id);
                var componets = context.Components.Where(x => x.PackageId == todelete.Id).ToList();
                List<ComponentType> listofcomponents = new List<ComponentType>();

                foreach (var item in componets)
                {
                    var types = context.ComponentTypes.Where(x => x.ComponentId == item.Id).ToList();
                    foreach (var componentType in types)
                    {
                        listofcomponents.Add(componentType);
                    }
                }

                foreach (var itemcomp in listofcomponents)
                {
                    var itemtodelete = context.ComponentTypes.SingleOrDefault(x => x.Id == itemcomp.Id);
                    context.ComponentTypes.Remove(itemtodelete);
                    context.SaveChanges();
                }

                foreach (var item in componets)
                {
                    var itemcom = context.Components.SingleOrDefault(x => x.Id == item.Id);
                    context.Components.Remove(itemcom);
                    context.SaveChanges();
                }
                context.Packages.Remove(todelete);
                context.SaveChanges();


            }
        }
    }
}
