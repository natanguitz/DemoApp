using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoApp.Domain
{
    public class Package
    {
        public Package()
        {
            Components = new List<Component>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal InitialPrice { get; set; }
        public string ImageUrl { get; set; }
        public PackageType PackageType { get; set; }
        [Required]
        public int PackakeTypeId { get; set; }
        public List<Component> Components { get; set; }


    }
}
