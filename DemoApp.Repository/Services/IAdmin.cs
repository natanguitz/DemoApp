using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DemoApp.Domain;

namespace DemoApp.Repository.Services
{
    public interface IAdmin
    {
        void SaveNewPackageType(string name);
        List<SelectListItem> PackageTypeItems();
        List<SelectListItem> PackageItems();
        void CreateAPackage(Package package);
        void CreateComponent(Component component);
    }
}
