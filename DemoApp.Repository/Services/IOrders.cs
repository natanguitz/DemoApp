using System;
using System.Collections.Generic;
using DemoApp.Domain;

namespace DemoApp.Repository.Services
{
    public interface IOrders
    {
        void SaveOrder(Order order);

        string GetCode(List<ComponentType> list);
        decimal GetFinalPrice(List<ComponentType> list , decimal packagePrice );
        int GetDeliveryDate( List<ComponentType> list );
    }
}
