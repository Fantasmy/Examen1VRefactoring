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
    public class ClientController : ApiController
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        private readonly IService<ClientDto> clientService;

        private ExamenVuelingEntities db = new ExamenVuelingEntities();

        public ClientController() : this(new ClientService())
        {
        }

        public ClientController(ClientService clientService)
        {
            this.clientService = clientService;
        }

        // GET: api/Client
        public List<ClientDto> Get()
        {
            log.Debug(Resource.AllASent);
            return clientService.GetAll();
        }

        // GET: api/Client/5
        public ClientDto Get(int id)
        {
            return clientService.GetById(id);
        }

        // POST: api/Client
        [ResponseType(typeof(ClientDto))]
        public IHttpActionResult Post(ClientDto clientDto)
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
                         clientService.Add(clientDto);
            }
            catch (VuelingException ex)
            {
                log.Debug(Resource.NoAddC);
                throw new HttpResponseException(HttpStatusCode.NotAcceptable);
            }

            var defApi = ConfigurationManager.AppSettings["DefApi"];

            return CreatedAtRoute(defApi,
                new { id = clientDtoInsert.id }, clientDtoInsert);

        }

        // PUT: api/Client/5
        public IHttpActionResult Put(int id, ClientDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            clientService.Update(model);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Client/5
        public IHttpActionResult Delete(int id)
        {
            log.Debug(Resource.OkDel);
            return Ok(clientService.Remove(id));
        }
    }
}
