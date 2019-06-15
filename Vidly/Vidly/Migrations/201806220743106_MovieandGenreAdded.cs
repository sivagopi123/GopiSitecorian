namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieandGenreAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        GenreName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GenreId);
            
            AddColumn("dbo.tblMovie", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.tblMovie", "NoInStock", c => c.Int(nullable: false));
            AddColumn("dbo.tblMovie", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tblMovie", "Genre_GenreId", c => c.Int(nullable: false));
            AlterColumn("dbo.tblMovie", "MovieName", c => c.String(nullable: false));
            CreateIndex("dbo.tblMovie", "Genre_GenreId");
            AddForeignKey("dbo.tblMovie", "Genre_GenreId", "dbo.Genres", "GenreId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblMovie", "Genre_GenreId", "dbo.Genres");
            DropIndex("dbo.tblMovie", new[] { "Genre_GenreId" });
            AlterColumn("dbo.tblMovie", "MovieName", c => c.String());
            DropColumn("dbo.tblMovie", "Genre_GenreId");
            DropColumn("dbo.tblMovie", "ReleaseDate");
            DropColumn("dbo.tblMovie", "NoInStock");
            DropColumn("dbo.tblMovie", "DateAdded");
            DropTable("dbo.Genres");
        }
    }
}
