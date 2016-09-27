using System.Data.Entity;
using DemoApp.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DemoApp.Data
{
    public class DemoAppContext : IdentityDbContext<AppUser>
    {
        public DemoAppContext()
           : base("name=MyAppDB")
        {
            Database.SetInitializer<DemoAppContext>(new DropCreateDatabaseIfModelChanges<DemoAppContext>());
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageType> PackageTypes { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<ComponentType> ComponentTypes { get; set; }
        public DbSet<Order> Orders { get; set; }

        //public System.Data.Entity.DbSet<DemoApp.Data.AppUser> AppUsers { get; set; } ´´´´´´´´Created by scaffolding option
    }
}