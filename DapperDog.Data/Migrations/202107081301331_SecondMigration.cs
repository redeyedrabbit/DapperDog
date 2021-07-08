namespace DapperDog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "BrandName", c => c.String());
            CreateIndex("dbo.Product", "BrandId");
            AddForeignKey("dbo.Product", "BrandId", "dbo.Brand", "BrandId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "BrandId", "dbo.Brand");
            DropIndex("dbo.Product", new[] { "BrandId" });
            DropColumn("dbo.Product", "BrandName");
        }
    }
}
