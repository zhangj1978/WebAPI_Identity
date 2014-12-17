namespace ConcordyaPayee.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSSendRequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SMSSendRequests", "VerifyCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SMSSendRequests", "VerifyCode");
        }
    }
}
