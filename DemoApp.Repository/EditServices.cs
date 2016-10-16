using System.Collections.Generic;
using System.Linq;
using DemoApp.Data;
using DemoApp.Domain;
using DemoApp.Repository.Services;

namespace DemoApp.Repository
{
    public class EditServices : IEdit
    {
        readonly DemoAppContext _context = new DemoAppContext();

        public List<Package> GetAllPackages()
        {

            return _context.Packages.ToList();
        }

        public void EditPackage(Package package)
        {
                Package oldpack = _context.Packages.SingleOrDefault(x => x.Id == package.Id);

                if (oldpack != null)
                {
                    oldpack.Description = package.Description;
                    oldpack.ImageUrl = package.ImageUrl;
                    oldpack.InitialPrice = package.InitialPrice;
                    oldpack.Name = package.Name;
                    oldpack.PackakeTypeId = package.PackakeTypeId;
                    _context.SaveChanges();
                }
        }

        public Component GetSingleComponent(int id)
        {

            return _context.Components.SingleOrDefault(x => x.Id == id);
        }

        public void EditedComponent(Component component)
        {
                Component old = _context.Components.SingleOrDefault(z => z.Id == component.Id);
                if (old != null)
                {
                    old.Name = component.Name;
                    old.ImageUrl = component.ImageUrl;
                    old.PackageId = component.PackageId;
                    old.ComponentTypes = component.ComponentTypes;

                    _context.SaveChanges();
                }
        }

        public void EditedComponentType(ComponentType coming)
        {
                ComponentType old = _context.ComponentTypes.FirstOrDefault(x => x.Id == coming.Id);

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
                    _context.SaveChanges();
                }
            
        }

        public List<Order> GetAllOrders()
        {

            return _context.Orders.ToList();
        }

        public Order GetSingleOrder(int id)
        {

            return _context.Orders.SingleOrDefault(x => x.Id == id);
        }

        public void EditedOrder(Order order)
        {
                Order old = _context.Orders.SingleOrDefault(x => x.Id == order.Id);

                if (old != null)
                {
                    old.PackageId = order.PackageId;
                    old.Customer = order.Customer;
                    old.DeliveryDate = order.DeliveryDate;
                    old.FinalPrice = order.FinalPrice;
                    old.OrderCode = order.OrderCode;
                    old.OrderState = order.OrderState;
                }
                _context.SaveChanges();    
        }

        public void DeleteOrder(Order order)
        {
                var orderToDelete = _context.Orders.SingleOrDefault(x => x.Id == order.Id);
                _context.Orders.Remove(orderToDelete);
                _context.SaveChanges();
        }

        public void DeleteComponentType(ComponentType type)
        {
                var typetodelete = _context.ComponentTypes.SingleOrDefault(x => x.Id == type.Id);
                _context.ComponentTypes.Remove(typetodelete);
                _context.SaveChanges();

        }

        public void DeleteComponent(Component component)
        {
                var todelete = _context.Components.SingleOrDefault(x => x.Id == component.Id);
                var types = _context.ComponentTypes.Where(x => x.ComponentId == component.Id).ToList();

                foreach (var componentType in types)
                {
                    _context.ComponentTypes.Remove(componentType);
                    _context.SaveChanges();
                }

                _context.Components.Remove(todelete);
                _context.SaveChanges();
        }

        public void DeletePackage(int id)
        {
                var todelete = _context.Packages.SingleOrDefault(x => x.Id == id);
                var componets = _context.Components.Where(x => x.PackageId == todelete.Id).ToList();
                List<ComponentType> listofcomponents = new List<ComponentType>();

                foreach (var item in componets)
                {
                    var types = _context.ComponentTypes.Where(x => x.ComponentId == item.Id).ToList();
                    foreach (var componentType in types)
                    {
                        listofcomponents.Add(componentType);
                    }
                }

                foreach (var itemcomp in listofcomponents)
                {
                    var itemtodelete = _context.ComponentTypes.SingleOrDefault(x => x.Id == itemcomp.Id);
                    _context.ComponentTypes.Remove(itemtodelete);
                    _context.SaveChanges();
                }

                foreach (var item in componets)
                {
                    var itemcom = _context.Components.SingleOrDefault(x => x.Id == item.Id);
                    _context.Components.Remove(itemcom);
                    _context.SaveChanges();
                }
                _context.Packages.Remove(todelete);
                _context.SaveChanges();
        }
    }
}
