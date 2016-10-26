using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DemoApp.Domain;

namespace DemoApp.web.Models
{
    public class BuildPackage
    {
        [Required]
        public Package Package { get; set; }
        [Required]
        public IList<Component> Component { get; set; }
    }
}