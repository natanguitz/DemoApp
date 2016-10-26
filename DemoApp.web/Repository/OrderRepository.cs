using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.ModelBinding;
using DemoApp.Data;
using DemoApp.Domain;
using DemoApp.Services.Repositories;

namespace DemoApp.web.Repository
{
    public class OrderRepository : IOrdersRepository
    {
        readonly DemoAppContext _context = new DemoAppContext();

        public void SaveOrder(Order order)
        {

                Order neworder = new Order
                {
                    Customer = order.Customer,
                    OrderCode = order.OrderCode,
                    DeliveryDate = order.DeliveryDate,
                    PackageId = order.PackageId,
                    FinalPrice = order.FinalPrice
                };
                _context.Orders.Add(neworder);
                _context.SaveChanges();
                
        }

        public string GetCode(List<ComponentType> list)
        {
            string code = null;

            foreach (var type in list)
            {
                code += type.TypeCode;
            }

            return code;
        }

        public decimal GetFinalPrice(List<ComponentType> list, decimal packagePrice)
        {
            decimal price = packagePrice;

            foreach (var type in list)
            {
                price += type.Price;
            }

            return price;
        }

        public DateTime GetDeliveryDate(List<ComponentType> list)
        {

            var fixedList = list.OrderByDescending(x => x.DeliveryDate).First();

            return fixedList.DeliveryDate;

        }

        public bool CreateFakeOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}