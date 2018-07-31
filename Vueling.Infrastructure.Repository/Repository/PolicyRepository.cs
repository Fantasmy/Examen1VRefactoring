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
    public class PolicyRepository : IPolicyRepository<PolicyEntity>
    {
        /// <summary>
        /// Calling the log helper
        /// </summary>
        private readonly ILogger log;
        //public AlumnoController(ILogger Log, IBusiness business)
        //{
        //    this.Log = Log;
        //    this.studentBl = business;
        //}

        /// <summary>
        /// The database
        /// </summary>
        private readonly ExamenVuelingEntities db;

        /// <summary>
        /// Initializes a new instance of the <see cref="PolicyRepository"/> class.
        /// </summary>
        public PolicyRepository() : this(new ExamenVuelingEntities())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PolicyRepository"/> class.
        /// </summary>
        /// <param name="examenVuelingEntities">The examen vueling entities.</param>
        public PolicyRepository(
            ExamenVuelingEntities examenVuelingEntities)
        {
            this.db = examenVuelingEntities;
        }

        /// <summary>
        /// Add method.
        /// </summary>
        /// <returns>Returns a new policy</returns>
        /// <exception cref="VuelingException">
        /// </exception>
        public PolicyEntity Add(PolicyEntity model)
        {
            Policies policy = null;

            //IMapper iMapper = AutomapperConfig.writeConfig.CreateMapper();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PolicyEntity, Policies>());
            IMapper iMapper = config.CreateMapper();

            policy = iMapper.Map<PolicyEntity, Policies>(model);

            try
            {
                if (db.Policies.Find(policy.id) == null)
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

        /// <summary>
        /// Get all method.
        /// </summary>
        /// <returns>Returns all policies list</returns>
        public List<PolicyEntity> GetAll()
        {
            List<PolicyEntity> policiesEntity;
            IQueryable<Policies> listPolicies;

            listPolicies = db.Policies;

            IMapper iMapper = AutomapperConfig.readConfig.CreateMapper();

            policiesEntity = iMapper.Map<List<PolicyEntity>>(listPolicies);

            return policiesEntity;
        }

        /// <summary>
        /// Get by id method.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns a policy identified by id</returns>
        public PolicyEntity GetById(Guid id)
        {
            PolicyEntity policyEntity;
            Policies policy;

            IMapper iMapper = AutomapperConfig.readConfig.CreateMapper();

            policy = db.Policies.Find(id);

            policyEntity = iMapper.Map<PolicyEntity>(policy);

            return policyEntity;
        }

    }
}
