namespace DapperDog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Category", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Category", "CustomerId", c => c.Int());
        }
    }
}
