namespace DapperDog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testingM : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "Name", c => c.String());
            AlterColumn("dbo.Product", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false));
        }
    }
}
