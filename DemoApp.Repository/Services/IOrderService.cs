using System;
using System.Collections.Generic;
using DemoApp.Domain;

namespace DemoApp.Services.Services
{
    public interface IOrderService
    {
        void SaveOrder(Order order);
        string GetCode(List<ComponentType> list);
        decimal GetFinalPrice(List<ComponentType> list, decimal packagePrice);
        DateTime GetDeliveryDate(List<ComponentType> list);
    }
}
