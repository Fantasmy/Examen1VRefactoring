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
    public class PolicyService : IService<PolicyDto>
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        private readonly IRepository<PolicyEntity> policyRepository;

        public PolicyService() : this(new PolicyRepository())
        {
        }

        public PolicyService(PolicyRepository alumnoRepository)
        {
            this.policyRepository = policyRepository;
        }

        /// <summary>
        /// Returns the specified policy dto.
        /// </summary>
        /// <param name="policyDto">The policy dto.</param>
        /// <returns></returns>
        public PolicyDto Add(PolicyDto policyDto)
        {
            PolicyEntity policyEntity = null;

            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<PolicyDto, PolicyEntity>());

            IMapper iMapper = config.CreateMapper();

            policyEntity = iMapper.Map<PolicyDto, PolicyEntity>(policyDto); 
            try
            {
                policyRepository.Add(policyEntity);
            }
            catch (VuelingException ex)
            {
                log.Error(Resource2.AnEx);
                throw;
            }

            return policyDto;
        }

        /// <summary>
        /// Returns policies list dto.
        /// </summary>
        /// <returns></returns>
        public List<PolicyDto> GetAll()
        {
            List<PolicyDto> policyDtos;
            List<PolicyEntity> policyRepositoryArrive;
            try
            {
                policyRepositoryArrive = policyRepository.GetAll();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<PolicyEntity, PolicyDto>());
                IMapper iMapper = config.CreateMapper();

                policyDtos = iMapper.Map<List<PolicyDto>>(policyRepositoryArrive);
            }
            catch (VuelingException ex)
            {
                log.Error(Resource2.AnEx);
                throw;
            }

            log.Debug(Resource2.ReAList);
            return policyDtos;
        }

        public PolicyDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }

        public PolicyDto Update(PolicyDto model)
        {
            throw new NotImplementedException();
        }
    }
}
