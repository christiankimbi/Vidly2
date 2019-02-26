namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRES (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO GENRES (Id, Name) VALUES (2, 'Adventure')");
            Sql("INSERT INTO GENRES (Id, Name) VALUES (3, 'Comedy')");
            Sql("INSERT INTO GENRES (Id, Name) VALUES (4, 'Crime')");
            Sql("INSERT INTO GENRES (Id, Name) VALUES (5, 'Drama')");
            Sql("INSERT INTO GENRES (Id, Name) VALUES (6, 'Horror')");
            Sql("INSERT INTO GENRES (Id, Name) VALUES (7, 'Musical')");
            Sql("INSERT INTO GENRES (Id, Name) VALUES (8, 'Romance')");
            Sql("INSERT INTO GENRES (Id, Name) VALUES (9, 'Thriller')");
            Sql("INSERT INTO GENRES (Id, Name) VALUES (10, 'Supernatural')");
        }
        
        public override void Down()
        {
        }
    }
}
