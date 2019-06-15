namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], 
                        [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], 
                        [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], 
                        [UserName]) VALUES (N'40a6bffb-62cd-484b-80d9-50cdacc70579', N'admin@vidly.com', 0, 
                        N'ACfFe/YAUs7okL3FYL3e1K4bJ7UiSUq81pELRqOuQViCcUK1V42lssDvR7cV3b1qCQ==', 
                        N'7125fa6b-0f6d-44fd-bbd9-9865fa4493bd', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], 
                        [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], 
                        [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], 
                        [UserName]) VALUES (N'92db8066-8d3c-4d34-bac8-506efe0b3615', N'guest@vidly.com', 0, 
                        N'AJOKJFx9Ajerm1AxoVGWpXidv1jsPjZK8xZeikTREcS1S58v8fyOU6fpCCkzjbnJtA==', 
                        N'4846c51c-21cc-4c45-b0a7-15d7ad3ce4e3', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b8c69ede-71d1-4150-936a-c02ddb5afc89', 
                        N'CanManagerMovies')

                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES 
                        (N'40a6bffb-62cd-484b-80d9-50cdacc70579', N'b8c69ede-71d1-4150-936a-c02ddb5afc89')


                ");
        }
        
        public override void Down()
        {
        }
    }
}
