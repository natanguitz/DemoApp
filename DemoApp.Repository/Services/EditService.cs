using System.Collections.Generic;
using DemoApp.Domain;
using DemoApp.Repository.Services;
using DemoApp.Services.Repositories;

namespace DemoApp.Services.Services
{
    public class EditService : IEditService
    {
        private readonly IEditRepository _repository;

        public EditService(IEditRepository repository)
        {
            _repository = repository;
        }
        public List<Package> GetAllPackages()
        {
            return _repository.GetAllPackages();
        }

        public void EditPackage(Package package)
        {
            _repository.EditPackage(package);
        }

        public Component GetSingleComponent(int id)
        {
            return _repository.GetSingleComponent(id);
        }

        public void EditedComponent(Component component)
        {
            _repository.EditedComponent(component);
        }

        public void EditedComponentType(ComponentType type)
        {
            _repository.EditedComponentType(type);
        }

        public List<Order> GetAllOrders()
        {
            return _repository.GetAllOrders();
        }

        public Order GetSingleOrder(int id)
        {
            return _repository.GetSingleOrder(id);
        }

        public void EditedOrder(Order order)
        {
            _repository.EditedOrder(order);;
        }

        public void DeleteOrder(Order order)
        {
            _repository.DeleteOrder(order);
        }

        public void DeleteComponentType(ComponentType type)
        {
            _repository.DeleteComponentType(type);
        }

        public void DeleteComponent(Component component)
        {
            _repository.DeleteComponent(component);
        }

        public void DeletePackage(int id)
        {
            _repository.DeletePackage(id);
        }
    }
}
