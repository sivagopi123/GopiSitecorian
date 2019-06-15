namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsSubscribedfornewsletter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblCustomer", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblCustomer", "IsSubscribedToNewsletter");
        }
    }
}
