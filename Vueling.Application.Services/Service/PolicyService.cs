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
    public class PolicyService : IPolicyService<PolicyDto>
    {
        /// <summary>
        /// Calls the log helper
        /// </summary>
        private readonly ILogger log;

        /// <summary>
        /// The policy repository
        /// </summary>
        private readonly IPolicyRepository<PolicyEntity> policyRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PolicyService"/> class.
        /// </summary>
        public PolicyService() : this(new PolicyRepository())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PolicyService"/> class.
        /// </summary>
        /// <param name="policyRepository">The policy repository.</param>
        public PolicyService(PolicyRepository policyRepository)
        {
            this.policyRepository = policyRepository;
        }

        /// <summary>
        /// Add new policy method.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Returns a new policy dto</returns>
        public PolicyDto Add(PolicyDto model)
        {
            PolicyEntity policyEntity = null;

            IMapper iMapper = AutomapperConfigService.writeConfig.CreateMapper();

            policyEntity = iMapper.Map<PolicyDto, PolicyEntity>(model);

            try
            {
                policyRepository.Add(policyEntity);

            }
            catch (VuelingException ex)
            {
                log.Error(Resource2.AnEx);
                throw ex;
            }

            log.Debug(Resource2.ReAList);
            return model;
        }

        /// <summary>
        /// Get all policies method.
        /// </summary>
        /// <returns>Returns the list of policies dto</returns>
        public List<PolicyDto> GetAll()
        {
            List<PolicyDto> listPolicyDtos;
            List<PolicyEntity> listPolicyRepositoryArrive;

            listPolicyRepositoryArrive = policyRepository.GetAll();

            IMapper iMapper = AutomapperConfigService.readConfig.CreateMapper();

            listPolicyDtos = iMapper.Map<List<PolicyDto>>(listPolicyRepositoryArrive);

            log.Debug(Resource2.RePolList);
            return listPolicyDtos;
        }

        /// <summary>
        /// Get the policy by id method.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns a policy identified by id</returns>
        public PolicyDto GetById(Guid id)
        {
            PolicyDto policy;
            PolicyEntity policyEntityArrive;

            policyEntityArrive = policyRepository.GetById(id);

            IMapper iMapper = AutomapperConfigService.readConfig.CreateMapper();

            policy = iMapper.Map<PolicyDto>(policyEntityArrive);

            log.Debug(Resource2.RePolById);
            return policy;
        }
    }
}
