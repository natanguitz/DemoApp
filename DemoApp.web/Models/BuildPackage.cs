using System.Collections.Generic;
using DemoApp.Domain;

namespace DemoApp.web.Models
{
    public class BuildPackage
    {
        public Package Package { get; set; }
        public IList<Component> Component { get; set; }
    }
}