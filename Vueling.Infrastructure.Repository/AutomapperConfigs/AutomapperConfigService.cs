using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Application.Dto;
using Vueling.Domain.Entities;

namespace Vueling.Infrastructure.Repository.Repository
{
    public class AutomapperConfigService
    {
        public static MapperConfiguration writeConfig;

        public static MapperConfiguration readConfig;

        static AutomapperConfigService()
        {
            writeConfig = new MapperConfiguration(cfg => cfg.CreateMap<ClientDto, ClientEntity>());

            readConfig = new MapperConfiguration(cfg => cfg.CreateMap<ClientDto, ClientEntity>());
        }
    }
}
