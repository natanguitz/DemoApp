using System.Collections.Generic;

namespace DemoApp.Domain
{
    public class Component
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public Package Package { get; set; }
        public int  PackageId { get; set; }
        public string ImageUrl { get; set; }

        public List<ComponentType> ComponentTypes { get; set; }
       
    }
}