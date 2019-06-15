namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FollowingActiveFlag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Followings", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Followings", "IsActive");
        }
    }
}
