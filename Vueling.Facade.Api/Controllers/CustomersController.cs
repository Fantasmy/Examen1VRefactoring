using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Vueling.Facade.Api.Controllers
{
    /// <summary>
    /// customer controller class for testing security token
    /// </summary>
    [Authorize]
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            var customerFake = Resource.fcus;
            return Ok(customerFake);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var customersFake = new string[] { Resource.cus1, Resource.cus2, Resource.cus3 };
            return Ok(customersFake);
        }
    }
}
