using System.Collections.Generic;
using DemoApp.Domain;

namespace DemoApp.web.Models
{
    public class MyCart
    {
        public MyCart()
        {
            ListTypes = new List<ComponentType>();
           
        }
        public List<ComponentType> ListTypes { get; set; }
        public Package PackObject { get; set; }
        public decimal BasicPrice { get; set; }
    }
}