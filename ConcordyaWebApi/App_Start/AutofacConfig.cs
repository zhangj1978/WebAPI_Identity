using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using ConcordyaPayee.Data;
using ConcordyaPayee.Data.Infrastructure;
using ConcordyaPayee.Data.Repositories;
using ConcordyaPayee.Web.Api.Controllers;

namespace ConcordyaPayee.Web.Api.App_Start
{
    public class AutofacConfig
    {
        public static void RegisterIOCs()
        {
            //var config = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(ConcordyaPayee.Web.Api.Controllers.VerifyCodeController).Assembly);
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            //builder.RegisterAssemblyTypes(typeof(IRepository<>).Assembly)
            //    .AsClosedTypesOf(typeof(IRepository<>)).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(IRepository<>).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();  
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}