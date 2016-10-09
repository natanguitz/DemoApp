using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoApp.Data;
using DemoApp.Domain;
using DemoApp.Repository.Services;

namespace DemoApp.Repository
{
    public class OrderServices : IOrders
    {
        public void SaveOrder(Order order)
        {
            Order neworder = new Order();
            neworder.Customer = order.Customer;
            neworder.OrderCode = order.OrderCode;
            neworder.DeliveryDate = order.DeliveryDate;
            neworder.PackageId = order.PackageId;
            neworder.FinalPrice = order.FinalPrice;

            using (var context = new DemoAppContext())
            {
                context.Orders.Add(neworder);
                context.SaveChanges();
            }
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

        //public Package GetSinglePackage(int id)
        //{
        //    using (var context = new DemoAppContext())
        //    {
        //        var package = context.Packages.SingleOrDefault(x => x.Id == id);
        //        return package;
        //    }
        //}

        //public int GetSinglePackageId(int id)
        //{
        //    using (var context = new DemoAppContext())
        //    {
        //        var pc = context.Packages.SingleOrDefault(x => x.Id == id);
        //        return pc.Id;
        //    }
        //}

        public int GetDeliveryDate(List<ComponentType> list)
        {
            var today = DateTime.Now.Day;
            var fixedList = list.OrderByDescending(x => x.DeliveryDate.Day);
            var lastDay = fixedList.FirstOrDefault();


            if (lastDay != null)
            {
                var days = today - lastDay.DeliveryDate.Day;
                return days;
            }
            else
            {
                return DateTime.Now.Day;
            }
        }
    }
}
 