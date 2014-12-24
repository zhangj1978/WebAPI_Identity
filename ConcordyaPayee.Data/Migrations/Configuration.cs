namespace ConcordyaPayee.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ConcordyaPayee.Model.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<ConcordyaPayee.Data.ConcordyaPayeeDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ConcordyaPayee.Data.ConcordyaPayeeDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var billIds = new List<string>();
            var categoryIds = new List<string>();
            var vendorIds = new List<string>();
            var dateNow = DateTime.UtcNow;
            var maxIds = 5;
            for (int i = 0; i < maxIds; i++)
            {
                billIds.Add(Guid.NewGuid().ToString());
                categoryIds.Add(Guid.NewGuid().ToString());
                vendorIds.Add(Guid.NewGuid().ToString());
            }

            for (int i = 0; i < maxIds; i++)
            {
                context.Vendors.AddOrUpdate(v => v.Id,
                    new Vendor { Id = vendorIds[i], Name = "Vendor " + i.ToString(), CreatedOn = dateNow, LastUpdatedOn = dateNow });
            }
            context.SaveChanges();
            for (int i = 0; i < maxIds; i++)
            {
                context.Categories.AddOrUpdate(c => c.Id,
                    new Category { Id = categoryIds[i], Name = "Cat " + i.ToString() });
            }
            context.SaveChanges();
            for (int i = 0; i < maxIds; i++)
            {
                context.Bills.AddOrUpdate(b => b.Id,
                    new Bill
                {
                    Id = billIds[i],
                    BillDate = DateTime.UtcNow,
                    DueDate = DateTime.UtcNow.AddDays(i),
                    Description = "Test Bill " + i.ToString(),
                    VendorId = vendorIds[i],
                    CategoryId = categoryIds[i],
                    CreatedOn = dateNow,
                    LastUpdatedOn = dateNow
                });
            }
            context.SaveChanges();
            for (int i = 0; i < maxIds; i++)
			{
                context.BillItems.AddOrUpdate(it => it.Id,
                    new BillItem
                    {
                        Id = Guid.NewGuid().ToString(),
                        BillId = billIds[i],
                        Name = "Item " + i.ToString(),
                        PricePerUnit = (decimal)i,
                        Quantity = i,
                        Total = i * i,
                        Unit = "¸ö"
                    });
			}
            context.SaveChanges();
        }
    }
}
