using System.Web.Mvc;
using System.Web.Services.Description;
using DemoApp.Repository;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace DemoApp.web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<Repository.Services.IServices, MyServices>();


            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}