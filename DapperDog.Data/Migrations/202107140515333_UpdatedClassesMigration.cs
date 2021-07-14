namespace DapperDog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedClassesMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "Zipcode", c => c.String(nullable: false));
            DropColumn("dbo.Customer", "PhoneNumber");
            DropColumn("dbo.Customer", "BillingAddressSameAsHomeAddress");
            DropColumn("dbo.Customer", "BillingAddress");
            DropColumn("dbo.Customer", "BillingCity");
            DropColumn("dbo.Customer", "BillingState");
            DropColumn("dbo.Customer", "BillingZipcode");
            DropColumn("dbo.Customer", "BillingPhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "BillingPhoneNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Customer", "BillingZipcode", c => c.String());
            AddColumn("dbo.Customer", "BillingState", c => c.Int(nullable: false));
            AddColumn("dbo.Customer", "BillingCity", c => c.String());
            AddColumn("dbo.Customer", "BillingAddress", c => c.String());
            AddColumn("dbo.Customer", "BillingAddressSameAsHomeAddress", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customer", "PhoneNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Customer", "Zipcode", c => c.String());
            AlterColumn("dbo.Customer", "City", c => c.String());
            AlterColumn("dbo.Customer", "Address", c => c.String());
            AlterColumn("dbo.Customer", "LastName", c => c.String());
            AlterColumn("dbo.Customer", "FirstName", c => c.String());
        }
    }
}
