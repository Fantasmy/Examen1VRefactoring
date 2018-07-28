using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Vueling.Application.Dto;
using Vueling.Common.Layer;

namespace Vueling.Application.Services.Service
{
    public static class HttpClientService
    {
        /// <summary>
        /// The client
        /// </summary>
        static HttpClient client;
        
        /// <summary>
        /// Initializes the <see cref="ClientController"/> class.
        /// </summary>
        static HttpClientService()
        {
            var uriClient = ConfigurationManager.AppSettings["UriClient"];

            client = new HttpClient();

            client.BaseAddress = new Uri(uriClient);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Gets all clients list from Json url.
        /// </summary>
        /// <returns>Returns all clients data from url</returns>
        public static async Task<ClientsListDto> GetAllClients()
        {
            ClientsListDto clientsListDto = null;

            try
            {
                HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(Resource2.ReqMsgInfo + response.RequestMessage + Resource2.n);
                    Console.WriteLine(Resource2.ReqMsgHeader + response.Content.Headers + Resource2.n);

                    var clientJsonString = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(Resource2.RespData + clientJsonString);

                    clientsListDto = JsonConvert.DeserializeObject<ClientsListDto>(clientJsonString);

                }

            }
            catch (HttpRequestException ex)
            {
                throw new VuelingException();
            }

            return clientsListDto;

        }
    }
}
