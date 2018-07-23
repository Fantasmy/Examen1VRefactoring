using System;
using System.Collections.Generic;
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

            // Configuration and services of web Api

            // Route web API
            config.MapHttpAttributeRoutes();

            config.MessageHandlers.Add(new TokenValidationHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
