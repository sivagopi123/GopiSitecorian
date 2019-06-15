namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerBirthDateAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblCustomer", "CustomerBirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblCustomer", "CustomerBirthDate");
        }
    }
}
