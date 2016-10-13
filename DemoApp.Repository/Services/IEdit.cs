using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoApp.Domain;

namespace DemoApp.Repository.Services
{
    public interface IEdit
    {
        List<Package> GetAllPackages();

        void EditPackage(Package package);
    }
}
