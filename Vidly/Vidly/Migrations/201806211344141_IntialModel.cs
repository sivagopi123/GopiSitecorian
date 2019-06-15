namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCustomer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 255),
                        MembershipType_MembershipTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.MembershipTypes", t => t.MembershipType_MembershipTypeId)
                .Index(t => t.MembershipType_MembershipTypeId);
            
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        MembershipTypeId = c.Int(nullable: false, identity: true),
                        MembershipTypeName = c.String(),
                    })
                .PrimaryKey(t => t.MembershipTypeId);
            
            CreateTable(
                "dbo.tblMovie",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        MovieName = c.String(),
                    })
                .PrimaryKey(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblCustomer", "MembershipType_MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.tblCustomer", new[] { "MembershipType_MembershipTypeId" });
            DropTable("dbo.tblMovie");
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.tblCustomer");
        }
    }
}
