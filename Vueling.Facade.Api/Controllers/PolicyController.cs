using Microsoft.Web.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Vueling.Application.Dto;
using Vueling.Application.Services.Contracts;
using Vueling.Application.Services.Service;
using Vueling.Common.Layer;
using Vueling.Infrastructure.Repository.DataModel;
using Vueling.Utils.LogHelper;

namespace Vueling.Facade.Api.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [ApiVersion("0.9", Deprecated = true)]
    [RoutePrefix("api/Policy")]
    public class PolicyController : ApiController
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        private readonly IPolicyService<PolicyDto> policyService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PolicyController"/> class.
        /// </summary>
        public PolicyController() : this(new PolicyService())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PolicyController"/> class.
        /// </summary>
        /// <param name="policyService">The policy service.</param>
        public PolicyController(PolicyService policyService)
        {
            this.policyService = policyService;
        }

        // GET: api/Policy
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IEnumerable<PolicyDto> GetAll()
        {
            log.Debug(Resource.AllPolSent);
            return policyService.GetAll();
        }

        // GET: api/Policy/5
        /// <summary>
        /// Get policy by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns the policy identified by id</returns>
        [HttpGet]
        [Authorize(Roles = "admin, user")]
        public PolicyDto Get(Guid id)
        {
            log.Debug(Resource.RePolById);
            return policyService.GetById(id);
        }

        // POST: api/Policy
        /// <summary>
        /// Posts the specified policy dto.
        /// </summary>
        /// <param name="policyDto">The policy dto.</param>
        /// <returns></returns>
        [ResponseType(typeof(PolicyDto))]
        public IHttpActionResult Post(PolicyDto model)
        {
            var defApi = ConfigurationManager.AppSettings["DefApi"];

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PolicyDto policyDtoInsert = null;

            try
            {
                policyDtoInsert =
                         policyService.Add(model);
            }
            catch (VuelingException ex)
            {
                log.Debug(Resource.NoAddP);
                throw new HttpResponseException(HttpStatusCode.NotAcceptable);

            }

            log.Debug(Resource.InserPoli);
            return CreatedAtRoute(defApi,
                new { id = policyDtoInsert.id }, policyDtoInsert);

        }

    }
    
}



