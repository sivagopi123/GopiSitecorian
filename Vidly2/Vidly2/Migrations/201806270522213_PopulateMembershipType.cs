namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (MembershipTypeName,SignUpFee, DurationInMonths, DiscountRate) values ('Payasyougo',0,0,0)");
            Sql("INSERT INTO MembershipTypes (MembershipTypeName,SignUpFee, DurationInMonths, DiscountRate) values ('Quarterly',30,1,10)");
            Sql("INSERT INTO MembershipTypes (MembershipTypeName,SignUpFee, DurationInMonths, DiscountRate) values ('Halfearly',90,3,15)");
            Sql("INSERT INTO MembershipTypes (MembershipTypeName,SignUpFee, DurationInMonths, DiscountRate) values ('Annual',300,12,20)");
        }
        
        public override void Down()
        {
        }
    }
}
