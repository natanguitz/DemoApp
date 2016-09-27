namespace DemoApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finalPriceDelPackage : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Packages", "FinalPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Packages", "FinalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
