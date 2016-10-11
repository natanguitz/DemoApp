using System.Collections.Generic;
using DemoApp.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DemoApp.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DemoApp.Data.DemoAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled  = false;
        }

        protected override void Seed(DemoApp.Data.DemoAppContext context)
        {
            //Seed database with an admin user and role. 

            if (!context.Roles.Any(r => r.Name == "admins"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "admins" }; roleManager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin@admin.com"))
            {
                var userStore = new UserStore<AppUser>(context);
                var userManager = new UserManager<AppUser>(userStore);
                var user = new AppUser {
                    UserName = "admin@admin.com",
                    Email = "fredrik@kodmentor.se", FirstName = "Alexander", LastName = "Guitz", CompanyName = "Nackademin", DeliveryAdress = "Stockholm gatan 1"};
                userManager.Create(user, "P@ssw0rd"); userManager.AddToRole(user.Id, "admins");
            }

        }
    }
    
}
