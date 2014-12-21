namespace ConcordyaPayee.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newBill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BillItems",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Unit = c.String(),
                        PricePerUnit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        LastUpdatedOn = c.DateTime(nullable: false),
                        LastUpdatedBy = c.String(),
                        BillId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bills", t => t.BillId)
                .Index(t => t.BillId);
            
            AddColumn("dbo.Bills", "CategoryId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BillItems", "BillId", "dbo.Bills");
            DropIndex("dbo.BillItems", new[] { "BillId" });
            DropColumn("dbo.Bills", "CategoryId");
            DropTable("dbo.BillItems");
        }
    }
}
