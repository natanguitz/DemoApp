using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoApp.Domain;

namespace DemoApp.web.Models
{
    public class BuildPackage
    {
        public Package Package { get; set; }
        public IList<Component> Component { get; set; }
    }
}