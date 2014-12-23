namespace ConcordyaPayee.Web.Api.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ConcordyaPayee.Web.Api.Models;
    using ConcordyaPayee.Web.Api.Providers;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<ConcordyaPayee.Web.Api.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ConcordyaPayee.Web.Api.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            manager.Create(new ApplicationUser { UserName = "123456", PhoneNumber="123456" }, "123456");
            var passHash = manager.PasswordHasher.HashPassword("123456");
            context.SaveChanges();
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
        }
    }
}
