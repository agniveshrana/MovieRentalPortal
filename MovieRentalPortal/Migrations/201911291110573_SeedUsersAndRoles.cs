namespace MovieRentalPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsersAndRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'34e659da-f264-43f0-98cf-229df2b69593', N'admin@movierental.com', 0, N'AOuVdemsq75X1SiqiKoL1tSePpbDyksbc+odQ7abXW9A15aGjnCCoo28o9YkUxN5pw==', N'2c193da9-febf-463b-8dd9-96ed63365371', NULL, 0, 0, NULL, 1, 0, N'admin@movierental.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd53cecfb-c038-45f0-ae3d-3f2c0b2730dd', N'guest@movierental.com', 0, N'AJw2T6dDxP9ikqTjq8AfTeoAULduUc6x7O8nGCX73X0EVVCn6MTg5akVqJw6RPXZsg==', N'c5b1fab0-6133-4d54-b552-20858f3c04f7', NULL, 0, 0, NULL, 1, 0, N'guest@movierental.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'73342a15-468e-4bc5-afae-eae97a590b25', N'admin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'34e659da-f264-43f0-98cf-229df2b69593', N'73342a15-468e-4bc5-afae-eae97a590b25')


");
        }

        public override void Down()
        {
        }
    }
}
