using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using ConcordyaPayee.Data;
using ConcordyaPayee.Data.Infrastructure;
using ConcordyaPayee.Data.Repositories;
using ConcordyaPayee.Data.Repositors;
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
            builder.RegisterType<BillRepository>().As<IBillRepository>();
            builder.RegisterType<SmsSendRepository>().As<ISmsRepository>();
            

            //builder.Register(uow => new UnitOfWork(new DatabaseFactory())).As<IUnitOfWork>();
            //builder.Register(billRepo => new BillRepository(new DatabaseFactory())).As<IBillRepository>();
            
            
            
            // IDatabaseFactory
            var container = builder.Build();
            var dbFactory = container.Resolve<IDatabaseFactory>();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}