using System;
using System.Collections.Generic;
using DemoApp.Domain;
using DemoApp.Repository.Services;
using DemoApp.Services.Repositories;

namespace DemoApp.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrdersRepository _repository;

        public OrderService(IOrdersRepository repository)
        {
            _repository = repository;
        }

        public void SaveOrder(Order order)
        {
           _repository.SaveOrder(order);
        }

        public string GetCode(List<ComponentType> list)
        {
            return _repository.GetCode(list);
        }

        public decimal GetFinalPrice(List<ComponentType> list, decimal packagePrice)
        {
            return  _repository.GetFinalPrice(list, packagePrice);
        }

        public DateTime GetDeliveryDate(List<ComponentType> list)
        {
            return _repository.GetDeliveryDate(list);
        }
    }
}
