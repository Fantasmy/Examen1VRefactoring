using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Domain.Entities;
using Vueling.Infrastructure.Repository.DataModel;

namespace Vueling.Infrastructure.Repository.Repository
{
    class AutomapperConfig
    {
        public static MapperConfiguration writeConfig;

        public static MapperConfiguration readConfig;
        static AutomapperConfig()
        {
            writeConfig = new MapperConfiguration(cfg => cfg.CreateMap<ClientEntity, Clients>()); 

            readConfig = new MapperConfiguration(cfg => cfg.CreateMap<ClientEntity, Clients>()
            .ForMember(dest => dest.id, sou => sou.UseValue("Private")));
        }
    }
}
