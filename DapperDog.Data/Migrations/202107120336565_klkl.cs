namespace DapperDog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class klkl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "BrandId", "dbo.Brand");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropIndex("dbo.Product", new[] { "BrandId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            AddColumn("dbo.Product", "CategoryName", c => c.String());
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Description", c => c.String());
            AlterColumn("dbo.Product", "Name", c => c.String());
            DropColumn("dbo.Product", "CategoryName");
            CreateIndex("dbo.Product", "CategoryId");
            CreateIndex("dbo.Product", "BrandId");
            AddForeignKey("dbo.Product", "CategoryId", "dbo.Category", "CategoryId", cascadeDelete: true);
            AddForeignKey("dbo.Product", "BrandId", "dbo.Brand", "BrandId", cascadeDelete: true);
        }
    }
}
