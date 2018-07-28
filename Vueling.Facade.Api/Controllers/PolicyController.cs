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

        //// PUT: api/Policy/5
        ///// <summary>
        ///// Puts the specified identifier.
        ///// </summary>
        ///// <param name="id">The identifier.</param>
        ///// <param name="model">The model.</param>
        ///// <returns></returns>
        //public IHttpActionResult Put(int id, PolicyDto model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    policyService.Update(model);
        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// DELETE: api/Policy/5
        ///// <summary>
        ///// Deletes the specified identifier.
        ///// </summary>
        ///// <param name="id">The identifier.</param>
        ///// <returns>Nothing</returns>
        //public IHttpActionResult Delete(int id)
        //{
        //    return Ok(policyService.Remove(id));
        //}
    }
    
}



