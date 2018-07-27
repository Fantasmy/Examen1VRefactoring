using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Domain.Entities;
using Vueling.Infrastructure.Repository.Contracts;
using Vueling.Infrastructure.Repository.DataModel;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using Vueling.Common.Layer;
using Vueling.Utils.LogHelper;

namespace Vueling.Infrastructure.Repository.Repository
{
    public class ClientRepository : IClientRepository<ClientEntity>
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        private readonly ExamenVuelingEntities db;

        public ClientRepository() : this(new ExamenVuelingEntities())
        {

        }

        public ClientRepository(
            ExamenVuelingEntities examenVuelingEntities)
        {
            this.db = examenVuelingEntities;
        }


        /// <summary>
        /// Add method
        /// </summary>
        /// <returns>Adds a new client</returns>
        /// <exception cref="VuelingException">
        /// </exception>
        public ClientEntity Add(ClientEntity model)
        {
            Clients client = null;

            IMapper iMapper = AutomapperConfig.writeConfig.CreateMapper();

            client = iMapper.Map<ClientEntity, Clients>(model);

            try
            {
                if (db.Clients.Find(client.id) == null)
                    db.Clients.Add(client);
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                log.Error(Resource3.ExUC);
                throw new VuelingException(Resource3.ErExUC, ex);
            }
            catch (DbUpdateException ex)
            {
                log.Error(Resource3.ExU);
                throw new VuelingException(Resource3.ErExU, ex);
            }
            catch (DbEntityValidationException ex)
            {
                log.Error(Resource3.ExEV);
                throw new VuelingException(Resource3.ErExEV, ex);
            }
            catch (NotSupportedException ex)
            {
                log.Error(Resource3.ExNotS);
                throw new VuelingException(Resource3.ErExNotS, ex);
            }
            catch (ObjectDisposedException ex)
            {
                log.Error(Resource3.ExObjD);
                throw new VuelingException(Resource3.ErExObjD, ex);
            }
            catch (InvalidOperationException ex)
            {
                log.Error(Resource3.ExInvO);
                throw new VuelingException(Resource3.ErExInvO, ex);
            }

            return model;
        }

        /// <summary>
        /// Get all method.
        /// </summary>
        /// <returns>Returns all client list</returns>
        public List<ClientEntity> GetAll()
        {
            List<ClientEntity> clientEntity;
            IQueryable<Clients> listClients;

            listClients = db.Clients;

            IMapper iMapper = AutomapperConfig.readConfig.CreateMapper();

            clientEntity = iMapper.Map<List<ClientEntity>>(listClients);

            return clientEntity;
        }

        /// <summary>
        /// Get by id method.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns a client by id</returns>
        public ClientEntity GetById(Guid id)
        {
            ClientEntity clientEntity;
            Clients client;

            IMapper iMapper = AutomapperConfig.readConfig.CreateMapper();

            client = db.Clients.Find(id);

            clientEntity = iMapper.Map<ClientEntity>(client);

            return clientEntity;
        }

        /// <summary>
        /// Gets the name of the by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public List<ClientEntity> GetByName(string name)
        {
            List<ClientEntity> clientEntity;
            IQueryable<Clients> client;

            IMapper iMapper = AutomapperConfig.readConfig.CreateMapper();


            client = db.Clients
                    .Where(b => b.name == name);

            clientEntity = iMapper.Map<List<ClientEntity>>(client);

            return clientEntity;
        }

        /// <summary>
        /// Get by email method.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>Returns the client identified by email</returns>
        public ClientEntity GetByEmail(string email)
        {
            ClientEntity clientEntity;
            Clients client;

            IMapper iMapper = AutomapperConfig.readConfig.CreateMapper();

            client = db.Clients
                    .FirstOrDefault(b => b.email == email);

            clientEntity = iMapper.Map<ClientEntity>(client);

            return clientEntity;
        }

    }

}

