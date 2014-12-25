namespace ConcordyaPayee.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Recurrings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecurringSettings",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RepeatBy = c.Int(nullable: false),
                        Interval = c.Int(nullable: false),
                        RepeatOn = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndsBy = c.Int(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        EndOnTimes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Bills", "AgingStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Bills", "RecurringId", c => c.String());
            AddColumn("dbo.Bills", "RecurringSetting_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Bills", "RecurringSetting_Id");
            AddForeignKey("dbo.Bills", "RecurringSetting_Id", "dbo.RecurringSettings", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bills", "RecurringSetting_Id", "dbo.RecurringSettings");
            DropIndex("dbo.Bills", new[] { "RecurringSetting_Id" });
            DropColumn("dbo.Bills", "RecurringSetting_Id");
            DropColumn("dbo.Bills", "RecurringId");
            DropColumn("dbo.Bills", "AgingStatus");
            DropTable("dbo.RecurringSettings");
        }
    }
}
