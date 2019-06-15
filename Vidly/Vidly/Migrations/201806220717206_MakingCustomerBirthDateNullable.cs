namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakingCustomerBirthDateNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblCustomer", "CustomerBirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblCustomer", "CustomerBirthDate", c => c.DateTime(nullable: false));
        }
    }
}
