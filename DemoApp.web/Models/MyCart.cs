using System.Collections.Generic;
using DemoApp.Domain;

namespace DemoApp.web.Models
{
    public class MyCart
    {
        public MyCart()
        {
            ComponentTypes = new List<ComponentType>();
           
        }
        public List<ComponentType> ComponentTypes { get; set; }
        public int Package { get; set; }
        public decimal PreviousCost { get; set; }

    }
}