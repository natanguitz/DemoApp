using System;
using System.ComponentModel.DataAnnotations;

namespace DemoApp.Domain
{
    public class ComponentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TypeCode { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime DeliveryDate { get; set; }
        public string Manufacturer { get; set; }
        public string ImageUrl { get; set; }
        public Component Component { get; set; }
        public int ComponentId { get; set; }
    }
}
