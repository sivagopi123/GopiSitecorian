namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblCustomer", "MembershipType_MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.tblCustomer", new[] { "MembershipType_MembershipTypeId" });
            RenameColumn(table: "dbo.tblCustomer", name: "MembershipType_MembershipTypeId", newName: "MembershipTypeId");
            RenameColumn(table: "dbo.tblMovie", name: "Genre_GenreId", newName: "GenreId");
            RenameIndex(table: "dbo.tblMovie", name: "IX_Genre_GenreId", newName: "IX_GenreId");
            AlterColumn("dbo.tblCustomer", "MembershipTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.tblCustomer", "MembershipTypeId");
            AddForeignKey("dbo.tblCustomer", "MembershipTypeId", "dbo.MembershipTypes", "MembershipTypeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblCustomer", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.tblCustomer", new[] { "MembershipTypeId" });
            AlterColumn("dbo.tblCustomer", "MembershipTypeId", c => c.Int());
            RenameIndex(table: "dbo.tblMovie", name: "IX_GenreId", newName: "IX_Genre_GenreId");
            RenameColumn(table: "dbo.tblMovie", name: "GenreId", newName: "Genre_GenreId");
            RenameColumn(table: "dbo.tblCustomer", name: "MembershipTypeId", newName: "MembershipType_MembershipTypeId");
            CreateIndex("dbo.tblCustomer", "MembershipType_MembershipTypeId");
            AddForeignKey("dbo.tblCustomer", "MembershipType_MembershipTypeId", "dbo.MembershipTypes", "MembershipTypeId");
        }
    }
}
