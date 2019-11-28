namespace MovieRentalPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateMembershipType2 : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes Set Name='Pay as You Go' Where id=1");
            Sql("Update MembershipTypes Set Name='Monthly' Where id=2");
            Sql("Update MembershipTypes Set Name='Quaterly' Where id=3");
            Sql("Update MembershipTypes Set Name='Yearly' Where id=4");
        }

        public override void Down()
        {
        }
    }
}
