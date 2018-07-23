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
    public class ClientRepository : IRepository<ClientEntity>
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
        /// Adds a new client.
        /// </summary>
        /// <exception cref="VuelingException">
        /// </exception>
        public ClientEntity Add(ClientEntity model)
        {
            Clients client = null;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientEntity, Clients>());
            IMapper iMapper = config.CreateMapper();
            client = iMapper.Map<ClientEntity, Clients>(model);

            try
            {
                log.Debug("Trying to add a client");
                db.Clients.Add(client);
                log.Debug(Resource3.trySC);
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
        /// Gets all clients.
        /// </summary>
        /// <returns></returns>
        public List<ClientEntity> GetAll()
        {
            List<ClientEntity> clientEntity;
            IQueryable<Clients> listClients;
            try
            {
                log.Debug(Resource3.tryCL);
                listClients = db.Clients;
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

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Clients, ClientEntity>());
            IMapper iMapper = config.CreateMapper();

            clientEntity = iMapper.Map<List<ClientEntity>>(listClients);

            return clientEntity;
        }

        public ClientEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }

        public ClientEntity Update(ClientEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
