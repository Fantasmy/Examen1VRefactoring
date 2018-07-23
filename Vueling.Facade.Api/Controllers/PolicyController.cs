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

        private readonly IService<PolicyDto> policyService;

        private ExamenVuelingEntities db = new ExamenVuelingEntities();

        public PolicyController() : this(new PolicyService())
        {
        }

        public PolicyController(PolicyService policyService)
        {
            this.policyService = policyService;
        }

        // GET: api/Policy
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public List<PolicyDto> Get()
        {
            log.Debug(Resource.AllASent);
            return policyService.GetAll();
        }

        // GET: api/Policy/5
        public PolicyDto Get(int id)
        {
            return policyService.GetById(id);
        }

        // POST: api/Policy
        /// <summary>
        /// Posts the specified policy dto.
        /// </summary>
        /// <param name="policyDto">The policy dto.</param>
        /// <returns></returns>
        [ResponseType(typeof(PolicyDto))]
        public IHttpActionResult Post(PolicyDto policyDto)
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
                         policyService.Add(policyDto);
            }
            catch (VuelingException ex)
            {
                // return the best http error
                log.Debug(Resource.NoAddP);
                throw new HttpResponseException(HttpStatusCode.NotAcceptable);

            }

            return CreatedAtRoute(defApi,
                new { id = policyDtoInsert.id }, policyDtoInsert);

        }

        // PUT: api/Policy/5
        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public IHttpActionResult Put(int id, PolicyDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            policyService.Update(model);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Policy/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Nothing</returns>
        public IHttpActionResult Delete(int id)
        {
            return Ok(policyService.Remove(id));
        }
    }
    
}



