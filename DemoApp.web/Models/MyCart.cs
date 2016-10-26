using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DemoApp.Domain;

namespace DemoApp.web.Models
{
    public class MyCart
    {
        public MyCart()
        {
            ListTypes = new List<ComponentType>();
           
        }
        [Required]
        public List<ComponentType> ListTypes { get; set; }
        [Required]
        public Package PackObject { get; set; }
        [Required]
        public decimal BasicPrice { get; set; }
        [Required]
        public decimal FinalPrice { get; set; }
    }
}