namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (GenreName) values ('Comedy')");
            Sql("INSERT INTO Genres (GenreName) values ('Family')");
            Sql("INSERT INTO Genres (GenreName) values ('Action')");
            Sql("INSERT INTO Genres (GenreName) values ('Fantacy')");
            Sql("INSERT INTO Genres (GenreName) values ('Adult')");
            Sql("INSERT INTO Genres (GenreName) values ('Racy')");
            Sql("INSERT INTO Genres (GenreName) values ('Classic')");
            Sql("INSERT INTO Genres (GenreName) values ('Art')");
        }
        
        public override void Down()
        {
        }
    }
}
