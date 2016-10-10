using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoApp.Data;
using DemoApp.Domain;
using DemoApp.Repository.Services;

namespace DemoApp.Repository
{
    public class AdminServices : IAdmin
    {
        public void SaveNewPackageType(string name)
        {
            using (var context = new DemoAppContext())
            {
                var npt = new PackageType();
                npt.Name = name;
                context.PackageTypes.Add(npt);
                context.SaveChanges();
            }
        }
    }
}
