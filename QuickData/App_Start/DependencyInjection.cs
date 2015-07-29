using Autofac;
using SQLST.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using FastDB.Service;
using SQLST;
using FastDB.AOF;
using FastDB.Log;
using FastDB.Cache;
using FastDB.Cache.Repoistory;

namespace QuickData.App_Start
{
    public static class DependencyInjection
    {
        public static void Initialise()
        {
            var configuration = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.Register(c => new DatabaseFactory()).As<IDatabaseFactory>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<FastDBService>().As<IFastDB>().InstancePerLifetimeScope();
            builder.RegisterType<AOFAdapter>().As<IAOF>().InstancePerLifetimeScope();
            builder.RegisterType<IOLogger>().As<ILogger>().InstancePerLifetimeScope();
            builder.RegisterType<Memory>().As<IMemory>().InstancePerLifetimeScope();

            builder.RegisterType<KeyValueSR>().As<IKeyValueSR>().InstancePerLifetimeScope();

            builder.RegisterType<SingleRES>().As<ISingleRES>().InstancePerLifetimeScope();

            IContainer container = builder.Build();

            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}