using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Infrastructure.Repository.Contracts;
using Vueling.Domain.Entities;
using AutoMapper;
using Vueling.Infrastructure.Repository.DataModel;
using System.Data.Entity.Infrastructure;
using Vueling.Common.Layer;
using System.Data.Entity.Validation;
using Vueling.Utils.LogHelper;

namespace Vueling.Infrastructure.Repository.Repository
{
    public class PolicyRepository : IRepository<PolicyEntity>
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        private readonly ExamenVuelingEntities db;

        public PolicyRepository() : this(new ExamenVuelingEntities())
        {

        }

        public PolicyRepository(
            ExamenVuelingEntities examenVuelingEntities)
        {
            this.db = examenVuelingEntities;
        }
        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="VuelingException">
        /// </exception>
        public PolicyEntity Add(PolicyEntity model)
        {
            Policies policy = null;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PolicyEntity, Policies>());
            IMapper iMapper = config.CreateMapper();
            policy = iMapper.Map<PolicyEntity, Policies>(model);

            try
            {
                db.Policies.Add(policy);
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

        public List<PolicyEntity> GetAll()
        {
            List<PolicyEntity> policyEntity;
            IQueryable<Policies> policyClients;
            try
            {
                policyClients = db.Policies;
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

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Policies, PolicyEntity>());
            IMapper iMapper = config.CreateMapper();

            policyEntity = iMapper.Map<List<PolicyEntity>>(policyClients);

            return policyEntity;
        }

        public PolicyEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }

        public PolicyEntity Update(PolicyEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
