namespace ConcordyaPayee.Web.Api.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ConcordyaPayee.Web.Api.Models;
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
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            manager.Create(new ApplicationUser { UserName = "123456", PhoneNumber = "123456" }, "123456");
            context.SaveChanges();
        }
    }
}
