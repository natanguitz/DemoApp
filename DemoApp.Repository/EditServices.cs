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
    public class EditServices : IEdit
    {
        public List<Package> GetAllPackages()
        {
            using (var context = new DemoAppContext())
            {
                var list = context.Packages.ToList();
                return list;
            }
        }

        public void EditPackage(Package package)
        {
            using (var context = new DemoAppContext())
            {
                Package oldpack = context.Packages.SingleOrDefault(x => x.Id == package.Id);

                if (oldpack != null)
                {
                    oldpack.Description = package.Description;
                    oldpack.ImageUrl = package.ImageUrl;
                    oldpack.InitialPrice = package.InitialPrice;
                    oldpack.Name = package.Name;
                    oldpack.PackakeTypeId = package.PackakeTypeId;
                    context.SaveChanges();
                }
            }
        }
    }
}
