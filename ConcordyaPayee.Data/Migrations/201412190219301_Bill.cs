namespace ConcordyaPayee.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BillNumber = c.String(),
                        BillDate = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        LastUpdatedOn = c.DateTime(nullable: false),
                        LastUpdatedBy = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bills");
        }
    }
}
