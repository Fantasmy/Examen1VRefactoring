using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Vueling.Application.Dto;
using Vueling.Application.Services.Service;
using Vueling.Facade.Api.Controllers;
using Vueling.Utils.LogHelper;


namespace Vueling.Facade.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private readonly ILogger log;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            log4net.Config.XmlConfigurator.Configure();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //ClientController clientApi = new ClientController();
            ClientsListDto ClientToList = new ClientsListDto();

            //ClientToList = HttpClientService.GetAllClients().Result;

            //foreach (ClientDto client in ClientToList.clientDto)
            //{
            //    clientApi.Post(client);
            //}


            PolicyController policyApi = new PolicyController();
            PoliciesListDto PolicyToList = new PoliciesListDto();

            PolicyToList = HttpPolicyService.GetAllPolicies().Result;

            foreach (PolicyDto policy in PolicyToList.policyDto)
            {
                policyApi.Post(policy);
            }
        }
    }
}
