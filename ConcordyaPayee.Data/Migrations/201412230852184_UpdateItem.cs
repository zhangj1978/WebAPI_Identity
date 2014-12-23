namespace ConcordyaPayee.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateItem : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BillItems", "CreatedOn");
            DropColumn("dbo.BillItems", "CreatedBy");
            DropColumn("dbo.BillItems", "LastUpdatedOn");
            DropColumn("dbo.BillItems", "LastUpdatedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BillItems", "LastUpdatedBy", c => c.String());
            AddColumn("dbo.BillItems", "LastUpdatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.BillItems", "CreatedBy", c => c.String());
            AddColumn("dbo.BillItems", "CreatedOn", c => c.DateTime(nullable: false));
        }
    }
}
