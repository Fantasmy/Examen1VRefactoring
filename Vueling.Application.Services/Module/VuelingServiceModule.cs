using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Domain.Entities;
using Vueling.Infrastructure.Repository.Contracts;
using Vueling.Infrastructure.Repository.Modules;
using Vueling.Infrastructure.Repository.Repository;
using Vueling.Utils.LogHelper;

namespace Vueling.Application.Services.Module
{
    public class VuelingServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder) 
        {
            builder
                 .RegisterType<ClientRepository>()
                 .As<IClientRepository<ClientEntity>>()
                 .InstancePerRequest();

            builder
                .RegisterType<PolicyRepository>()
                .As<IPolicyRepository<PolicyEntity>>()
                .InstancePerRequest();

            builder
                 .RegisterType<Log4netAdapter>()
                 .As<ILogger>()
                 .InstancePerRequest();

            builder.RegisterModule(new VuelingRepositoryModule()); 

            base.Load(builder);
        }
    }
}
