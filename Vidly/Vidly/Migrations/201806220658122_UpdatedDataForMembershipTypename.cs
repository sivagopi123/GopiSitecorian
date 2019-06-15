namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDataForMembershipTypename : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes set MembershipTypeName = 'PayasyouGo' where MembershipTypeId = 1");
            Sql("Update MembershipTypes set MembershipTypeName = 'Quaterly' where MembershipTypeId = 2");
            Sql("Update MembershipTypes set MembershipTypeName = 'Halfearly' where MembershipTypeId = 3");
            Sql("Update MembershipTypes set MembershipTypeName = 'Annual' where MembershipTypeId = 4");
        }
        
        public override void Down()
        {
        }
    }
}
