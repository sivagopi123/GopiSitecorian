namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentalSchemaAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        RentalId = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        CustomerRented_CustomerId = c.Int(nullable: false),
                        MoviesRented_MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RentalId)
                .ForeignKey("dbo.Customers", t => t.CustomerRented_CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MoviesRented_MovieId, cascadeDelete: true)
                .Index(t => t.CustomerRented_CustomerId)
                .Index(t => t.MoviesRented_MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "MoviesRented_MovieId", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "CustomerRented_CustomerId", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "MoviesRented_MovieId" });
            DropIndex("dbo.Rentals", new[] { "CustomerRented_CustomerId" });
            DropTable("dbo.Rentals");
        }
    }
}
