namespace ConcordyaPayee.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
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
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BillNumber = c.String(),
                        BillDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BillStatus = c.Int(nullable: false),
                        IsRecurring = c.Boolean(nullable: false),
                        VendorId = c.String(maxLength: 128),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        LastUpdatedOn = c.DateTime(nullable: false),
                        LastUpdatedBy = c.String(),
                        Description = c.String(),
                        CategoryId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Vendors", t => t.VendorId)
                .Index(t => t.VendorId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        ParentId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        CompanyId = c.String(),
                        Description = c.String(),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastUpdatedBy = c.String(),
                        LastUpdatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SMSSendRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Phone = c.String(),
                        Message = c.String(),
                        VerifyCode = c.String(),
                        ValidUntil = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        LastUpdatedOn = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bills", "VendorId", "dbo.Vendors");
            DropForeignKey("dbo.Bills", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.BillItems", "BillId", "dbo.Bills");
            DropIndex("dbo.Bills", new[] { "CategoryId" });
            DropIndex("dbo.Bills", new[] { "VendorId" });
            DropIndex("dbo.BillItems", new[] { "BillId" });
            DropTable("dbo.SMSSendRequests");
            DropTable("dbo.Vendors");
            DropTable("dbo.Categories");
            DropTable("dbo.Bills");
            DropTable("dbo.BillItems");
        }
    }
}
