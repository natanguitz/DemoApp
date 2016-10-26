using System;
using System.ComponentModel.DataAnnotations;

namespace DemoApp.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderCode { get; set; }
        public OrderState OrderState { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal FinalPrice { get; set; }
        [Required]
        public string Customer { get; set; }
        public Package Package { get; set; }
        public int PackageId { get; set; }
    }
}
