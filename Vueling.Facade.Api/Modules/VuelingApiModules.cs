using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Vueling.Application.Dto;
using Vueling.Application.Services.Contracts;
using Vueling.Application.Services.Module;
using Vueling.Application.Services.Service;
using Vueling.Utils.LogHelper;

namespace Vueling.Facade.Api.Modules
{
    public class VuelingApiModules : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder
                 .RegisterType<ClientService>()
                 .As<IClientService<ClientDto>>()
                 .InstancePerRequest();

            builder
                .RegisterType<PolicyService>()
                .As<IPolicyService<PolicyDto>>()
                .InstancePerRequest();

            builder
                 .RegisterType<Log4netAdapter>()
                 .As<ILogger>()
                 .InstancePerRequest();

            builder.RegisterModule(new VuelingServiceModule());

            base.Load(builder);
        }
    }
}