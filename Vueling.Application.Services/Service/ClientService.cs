using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Application.Dto;
using Vueling.Application.Services.Contracts;
using Vueling.Common.Layer;
using Vueling.Domain.Entities;
using Vueling.Infrastructure.Repository.Contracts;
using Vueling.Infrastructure.Repository.Repository;
using Vueling.Utils.LogHelper;

namespace Vueling.Application.Services.Service
{
    public class ClientService : IService<ClientDto>
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        private readonly IRepository<ClientEntity> clientRepository;

        public ClientService() : this(new ClientRepository())
        {
        }

        public ClientService(ClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }
        /// <summary>
        /// Returns the specified client dto.
        /// </summary>
        /// <param name="clientDto">The client dto.</param>
        /// <returns></returns>
        public ClientDto Add(ClientDto clientDto)
        {
            ClientEntity clientEntity = new ClientEntity();

            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<ClientDto, ClientEntity>());

            IMapper iMapper = config.CreateMapper();

            clientEntity = iMapper.Map<ClientDto, ClientEntity>(clientDto);

            try
            {
                clientRepository.Add(clientEntity);
            }
            catch (VuelingException ex)
            {
                log.Error(Resource2.AnEx);
                throw;
            }

            return clientDto;
        }

        /// <summary>
        /// Returns clients list dto.
        /// </summary>
        /// <returns></returns>
        public List<ClientDto> GetAll()
        {
            List<ClientDto> clientDtos;
            List<ClientEntity> clientRepositoryArrive;
            try
            {
                clientRepositoryArrive = clientRepository.GetAll();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientEntity, ClientDto>());
                IMapper iMapper = config.CreateMapper();

                clientDtos = iMapper.Map<List<ClientDto>>(clientRepositoryArrive);
            }
            catch (VuelingException ex)
            {
                log.Error(Resource2.AnEx);
                throw;
            }

            log.Debug(Resource2.ReAList);
            return clientDtos;
        }

        public ClientDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }

        public ClientDto Update(ClientDto model)
        {
            throw new NotImplementedException();
        }
    }
}
