namespace DemoApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class packageidchanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Packages", "PackageType_Id", "dbo.PackageTypes");
            DropIndex("dbo.Packages", new[] { "PackageType_Id" });
            AlterColumn("dbo.Packages", "PackageType_Id", c => c.Int());
            CreateIndex("dbo.Packages", "PackageType_Id");
            AddForeignKey("dbo.Packages", "PackageType_Id", "dbo.PackageTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Packages", "PackageType_Id", "dbo.PackageTypes");
            DropIndex("dbo.Packages", new[] { "PackageType_Id" });
            AlterColumn("dbo.Packages", "PackageType_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Packages", "PackageType_Id");
            AddForeignKey("dbo.Packages", "PackageType_Id", "dbo.PackageTypes", "Id", cascadeDelete: true);
        }
    }
}
