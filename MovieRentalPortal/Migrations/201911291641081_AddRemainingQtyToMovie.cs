namespace MovieRentalPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRemainingQtyToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "RemainingQty", c => c.Int(nullable: false));
            Sql("Update Movies Set RemainingQty = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "RemainingQty");
        }
    }
}
