namespace MovieRentalPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres (Id, GenreName) Values (1, 'Comedy')");
            Sql("Insert into Genres (Id, GenreName) Values (2, 'Action')");
            Sql("Insert into Genres (Id, GenreName) Values (3, 'Family')");
            Sql("Insert into Genres (Id, GenreName) Values (4, 'Romance')");
            Sql("Insert into Genres (Id, GenreName) Values (5, 'Suspense')");
            Sql("Insert into Genres (Id, GenreName) Values (6, 'Biography')");
        }

        public override void Down()
        {
        }
    }
}
