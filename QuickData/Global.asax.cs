﻿using FastDB.Common;
using FastDB.Core;
using FastDB.Service;
using QuickData.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace QuickData
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DependencyInjection.Initialise();
            DependencyResolver.Current.GetService<DBStart>();
            GlobalConfiguration.Configuration.EnsureInitialized();//???
        }

        protected void Application_End()
        {
           DependencyResolver.Current.GetService<DBExit>();
        }
    }
}
