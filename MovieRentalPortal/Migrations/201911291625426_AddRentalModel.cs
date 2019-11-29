namespace MovieRentalPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddRentalModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    DateRented = c.DateTime(nullable: false),
                    DateReturned = c.DateTime(),
                    CustomerId = c.Int(nullable: false),
                    MovieId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.MovieId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Movie_MovieId", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Movie_MovieId" });
            DropIndex("dbo.Rentals", new[] { "Customer_CustomerId" });
            DropTable("dbo.Rentals");
        }
    }
}
