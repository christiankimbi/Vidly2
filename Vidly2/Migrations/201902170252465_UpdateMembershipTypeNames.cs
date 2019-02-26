namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeNames : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name='Pay as You Go' WHERE Id =1");
            Sql("UPDATE MembershipTypes SET Name='Monthly Subscription' WHERE Id =2");
            Sql("UPDATE MembershipTypes SET Name='Quaterly Subscription' WHERE Id =3");
            Sql("UPDATE MembershipTypes SET Name='Yearly Subscription' WHERE Id =4");
        }
        
        public override void Down()
        {
        }
    }
}
