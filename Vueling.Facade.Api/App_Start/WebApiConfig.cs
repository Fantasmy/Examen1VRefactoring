using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using Vueling.Facade.Api.Controllers;
using Vueling.Utils.LogHelper;

namespace Vueling.Facade.Api
{
    public static class WebApiConfig
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        public static void Register(HttpConfiguration config)
        {
            var defApi = ConfigurationManager.AppSettings["DefApi"];
            var routeTemp = ConfigurationManager.AppSettings["RouteTemp"];
            // Configuration and services of web Api

            // Route web API
            config.MapHttpAttributeRoutes();

            config.MessageHandlers.Add(new TokenValidationHandler());

            config.Routes.MapHttpRoute(
                name: defApi,
                routeTemplate: routeTemp,
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
