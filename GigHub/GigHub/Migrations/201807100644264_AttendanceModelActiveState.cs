namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttendanceModelActiveState : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendances", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attendances", "IsActive");
        }
    }
}
