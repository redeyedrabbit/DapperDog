namespace DapperDog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        State = c.Int(nullable: false),
                        Zipcode = c.String(),
                        BillingAddressSameAsHomeAddress = c.Boolean(nullable: false),
                        BillingAddress = c.String(),
                        BillingCity = c.String(),
                        BillingState = c.Int(nullable: false),
                        BillingZipcode = c.String(),
                        BillingPhoneNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            AddColumn("dbo.Transaction", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Transaction", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Transaction", "DateOfTransaction", c => c.DateTimeOffset(nullable: false, precision: 7));
            CreateIndex("dbo.Transaction", "CustomerId");
            CreateIndex("dbo.Transaction", "ProductId");
            AddForeignKey("dbo.Transaction", "CustomerId", "dbo.Customer", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.Transaction", "ProductId", "dbo.Product", "ProductId", cascadeDelete: true);
            DropColumn("dbo.Transaction", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Transaction", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Transaction", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Transaction", new[] { "ProductId" });
            DropIndex("dbo.Transaction", new[] { "CustomerId" });
            DropColumn("dbo.Transaction", "DateOfTransaction");
            DropColumn("dbo.Transaction", "Quantity");
            DropColumn("dbo.Transaction", "CustomerId");
            DropTable("dbo.Customer");
        }
    }
}
