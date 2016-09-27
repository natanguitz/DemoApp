namespace DemoApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Components",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PackageId = c.Int(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.PackageId, cascadeDelete: true)
                .Index(t => t.PackageId);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PackageCodeName = c.String(),
                        Description = c.String(),
                        InitialPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FinalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageUrl = c.String(),
                        PackakeTypeId = c.Int(nullable: false),
                        PackageType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PackageTypes", t => t.PackageType_Id, cascadeDelete: true)
                .Index(t => t.PackageType_Id);
            
            CreateTable(
                "dbo.PackageTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ComponentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeliveryDate = c.DateTime(nullable: false),
                        Manufacturer = c.String(),
                        ImageUrl = c.String(),
                        ComponentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Components", t => t.ComponentId, cascadeDelete: true)
                .Index(t => t.ComponentId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Company = c.String(),
                        Email = c.String(),
                        Name = c.String(),
                        Telephone = c.String(),
                        DeliveryAdress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderCode = c.String(),
                        OrderState = c.Int(),
                        DeliveryDate = c.DateTime(nullable: false),
                        FinalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Customer = c.String(nullable: false),
                        PackageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.PackageId, cascadeDelete: true)
                .Index(t => t.PackageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.ComponentTypes", "ComponentId", "dbo.Components");
            DropForeignKey("dbo.Packages", "PackageType_Id", "dbo.PackageTypes");
            DropForeignKey("dbo.Components", "PackageId", "dbo.Packages");
            DropIndex("dbo.Orders", new[] { "PackageId" });
            DropIndex("dbo.ComponentTypes", new[] { "ComponentId" });
            DropIndex("dbo.Packages", new[] { "PackageType_Id" });
            DropIndex("dbo.Components", new[] { "PackageId" });
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.ComponentTypes");
            DropTable("dbo.PackageTypes");
            DropTable("dbo.Packages");
            DropTable("dbo.Components");
        }
    }
}
