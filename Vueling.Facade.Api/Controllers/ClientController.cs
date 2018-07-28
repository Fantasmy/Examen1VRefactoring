using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
    [RoutePrefix("api/Client")]
    public class ClientController : ApiController
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        /// <summary>
        /// The client service
        /// </summary>
        private readonly IClientService<ClientDto> clientService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientController"/> class.
        /// </summary>
        public ClientController() : this(new ClientService())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientController"/> class.
        /// </summary>
        /// <param name="clientService">The client service.</param>
        public ClientController(ClientService clientService)
        {
            this.clientService = clientService;
        }

        // GET: api/Client
        /// <summary>
        /// Get all clients list.
        /// </summary>
        /// <returns>Returns all clients list</returns>
        [HttpGet]
        [Authorize(Roles = "admin, user")]
        public IEnumerable<ClientDto> GetAll()
        {
            log.Debug(Resource.AllCliSent);

            return clientService.GetAll();
        }

        // GET: api/Client/5
        /// <summary>
        /// Get the client by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns the client identified by id</returns>
        [HttpGet]
        [Authorize(Roles = "admin, user")]
        [Route("api/Clients/id/{id}")]
        public ClientDto Get(Guid id)
        {
            return clientService.GetById(id);
        }

        // GET: api/Client/John
        /// <summary>
        /// Get client by name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Returns the client identified by name</returns>
        [HttpGet]
        [Authorize(Roles = "admin, user")]
        [Route("api/Clients/name/{name}")]
        public List<ClientDto> GetByName(string name)
        {
            log.Debug(Resource.ReCliByName);
            return clientService.GetByName(name);
        }

        // POST: api/Client
        /// <summary>
        /// Post client method.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Inserts a new client</returns>
        [ResponseType(typeof(ClientDto))]
        public IHttpActionResult Post(ClientDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ClientDto clientDtoInsert = null;

            try
            {
                log.Debug(Resource.TryNewC);
                clientDtoInsert =
                         clientService.Add(model);
            }
            catch (VuelingException ex)
            {
                log.Debug(Resource.NoAddC);
                throw new HttpResponseException(HttpStatusCode.NotAcceptable);
            }

            var defApi = ConfigurationManager.AppSettings["DefApi"];

            log.Debug(Resource.InserCli);
            return CreatedAtRoute(defApi,
                new { id = clientDtoInsert.id }, clientDtoInsert);

        }

        //// PUT: api/Client/5
        //public IHttpActionResult Put(int id, ClientDto model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    clientService.Update(model);

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// DELETE: api/Client/5
        //public IHttpActionResult Delete(int id)
        //{
        //    log.Debug(Resource.OkDel);
        //    return Ok(clientService.Remove(id));
        //}
    }
}
