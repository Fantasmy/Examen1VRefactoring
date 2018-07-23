using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Vueling.Application.Dto;

namespace Vueling.Facade.Api.Controllers
{
    public class PolicyController : ApiController
    {
        /// <summary>
        /// The client
        /// </summary>
        static HttpClient client;
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientController"/> class.
        /// </summary>
        public PolicyController() { }
        /// <summary>
        /// Initializes the <see cref="ClientController"/> class.
        /// </summary>
        static PolicyController()
        {
            var uriClient = ConfigurationManager.AppSettings["UriClient"];
            client = new HttpClient();
            client.BaseAddress = new Uri(uriClient);
        }

        /// <summary>
        /// Gets all policies.
        /// </summary>
        /// <returns></returns>
        public async Task<List<PolicyDto>> GetAllPolicies()
        {
            IEnumerable<PolicyDto> policiesList = new List<PolicyDto>();
            try
            {
                var defApi = ConfigurationManager.AppSettings["DefApi"];

                HttpResponseMessage response = client.GetAsync(defApi).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(Resource.ReqMsgInfo + response.RequestMessage + Resource.n);
                    Console.WriteLine(Resource.ReqMsgHeader + response.Content.Headers + Resource.n);

                    var policyJsonString = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(Resource.RespData + policyJsonString);

                    var deserialized = JsonConvert.DeserializeObject<IEnumerable<PolicyDto>>(policyJsonString);
                    policiesList = deserialized;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return policiesList.ToList();

        }

        // POST: api/HttpPolicy
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/HttpPolicy/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/HttpPolicy/5
        public void Delete(int id)
        {
        }
    }
}



