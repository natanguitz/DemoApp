using System.Web.Mvc;
using DemoApp.Repository.Services;
using DemoApp.Services.Repositories;
using DemoApp.Services.Services;
using DemoApp.web.Repository;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace DemoApp.web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
			
            container.RegisterType<IOrderService,OrderService>(); 
            container.RegisterType<IOrdersRepository,OrderRepository>(); 
            container.RegisterType<IAdminService,AdminService>(); 
            container.RegisterType<IAdminRepository,AdminRepository>();
            container.RegisterType<IEditService, EditService>();
            container.RegisterType<IEditRepository, EditRepository>();
            container.RegisterType<IStartService, StartService>();
            container.RegisterType<IStartRepository, StartRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}