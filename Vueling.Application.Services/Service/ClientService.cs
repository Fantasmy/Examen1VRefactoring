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
    public class ClientService : IClientService<ClientDto>
    {
        /// <summary>
        /// Calls the log helper
        /// </summary>
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        /// <summary>
        /// The client repository
        /// </summary>
        private readonly IClientRepository<ClientEntity> clientRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientService"/> class.
        /// </summary>
        public ClientService() : this(new ClientRepository())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientService"/> class.
        /// </summary>
        /// <param name="clientRepository">The client repository.</param>
        public ClientService(ClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        /// <summary>
        /// Add method.
        /// </summary>
        /// <returns>Returns a new client Dto</returns>
        public ClientDto Add(ClientDto model)
        {
            ClientEntity clientEntity = null;
            IMapper iMapper = AutomapperConfigService.writeConfig.CreateMapper();

            clientEntity = iMapper.Map<ClientDto, ClientEntity>(model);

            try
            {
                clientRepository.Add(clientEntity);
            }
            catch (VuelingException ex)
            {
                log.Error(Resource2.AnEx);
                throw ex;
            }

            log.Debug(Resource2.ReCliList);

            return model;
        }

        /// <summary>
        /// Get all method.
        /// </summary>
        /// <returns>Returns all client list Dto</returns>
        public List<ClientDto> GetAll()
        {
            List<ClientDto> listClientDtos;
            List<ClientEntity> clientRepositoryArrive;

            clientRepositoryArrive = clientRepository.GetAll();

            IMapper iMapper = AutomapperConfigService.readConfig.CreateMapper();

            listClientDtos = iMapper.Map<List<ClientDto>>(clientRepositoryArrive);

            log.Debug(Resource2.ReCliList);
            return listClientDtos;
        }

        /// <summary>
        /// Get client by email method.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>Returns client identified by email</returns>
        public ClientDto GetByEmail(string email)
        {
            ClientDto client;
            ClientEntity clientEntityArrive;

            clientEntityArrive = clientRepository.GetByEmail(email);

            IMapper iMapper = AutomapperConfigService.readConfig.CreateMapper();

            client = iMapper.Map<ClientDto>(clientEntityArrive);

            log.Debug(Resource2.ReCliByMail);
            return client;
        }

        /// <summary>
        /// Get by id method.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns client by id identifier</returns>
        public ClientDto GetById(Guid id)
        {
            ClientDto client;
            ClientEntity clientEntityArrive;

            clientEntityArrive = clientRepository.GetById(id);

            IMapper iMapper = AutomapperConfigService.readConfig.CreateMapper();

            client = iMapper.Map<ClientDto>(clientEntityArrive);

            log.Debug(Resource2.ReCliById);
            return client;
        }

        /// <summary>
        /// Get the client by name method.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Returns the client identified by name</returns>
        public List<ClientDto> GetByName(string name)
        {
            List<ClientDto> client;
            List<ClientEntity> clientesEntityArrive;

            clientesEntityArrive = clientRepository.GetByName(name);

            IMapper iMapper = AutomapperConfigService.readConfig.CreateMapper();

            client = iMapper.Map<List<ClientDto>>(clientesEntityArrive);

            log.Debug(Resource2.ReCliByName);
            return client;
        }
    }
}