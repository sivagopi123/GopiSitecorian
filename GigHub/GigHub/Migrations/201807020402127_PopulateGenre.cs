namespace GigHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Genres (Id, Name) VALUES (1, 'Jazz')
                  INSERT INTO Genres (Id, Name) VALUES (2, 'Blues')
                  INSERT INTO Genres (Id, Name) VALUES (3, 'Rock')
                  INSERT INTO Genres (Id, Name) VALUES (4, 'Country')
                ");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id IN (1,2,3,4)");
        }
    }
}
