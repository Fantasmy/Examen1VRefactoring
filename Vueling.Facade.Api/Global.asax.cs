using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Vueling.Utils.LogHelper;

namespace Vueling.Facade.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();
        protected void Application_Start()
        {
            log.Debug("Hello world");

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            log4net.Config.XmlConfigurator.Configure();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
