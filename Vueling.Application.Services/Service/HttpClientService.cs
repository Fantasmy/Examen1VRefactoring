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
    class HttpClientService
    {
        /// <summary>
        /// The client
        /// </summary>
        static HttpClient client;
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientController"/> class.
        /// </summary>
        public HttpClientService() { }
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
        /// Gets all clients.
        /// </summary>
        /// <returns></returns>
        public async Task<ClientsListDto> GetAllClients()
        {
            ClientsListDto clientsListDto = null;

            try
            {
                var defApi = ConfigurationManager.AppSettings["DefApi"];

                HttpResponseMessage response = client.GetAsync(defApi).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(Resource2.ReqMsgInfo + response.RequestMessage + Resource2.n);
                    Console.WriteLine(Resource2.ReqMsgHeader + response.Content.Headers + Resource2.n);

                    var clientJsonString = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(Resource2.RespData + clientJsonString);

                    clientsListDto = JsonConvert.DeserializeObject<ClientsListDto>(clientJsonString);

                    //DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(clientJsonString);

                    //DataTable dataTable = dataSet.Tables["clients"];

                    //Console.WriteLine(dataTable.Rows.Count);
                    //// 2

                    //foreach (DataRow row in dataTable.Rows)
                    //{
                    //    Console.WriteLine(row["id"] + " - " + row["name"] + " - " + row["email"] + " - " + row["role"]);
                    //}

                }

            }
            catch (VuelingException ex)
            {

                //throw new HttpResponseException(HttpStatusCode.NotAcceptable);
            }
            return clientsListDto;

        }



        /// <summary>
        /// The method
        /// </summary>

        // POST Method

        /// <summary>
        /// Adds the client.
        /// </summary>
        /// <param name="client">The client.</param>
        //public async void AddClient(ClientDto client)
        //{
        //    var clientJson = JsonConvert.SerializeObject(client);

        //    try
        //    {
        //        var encodingToBytes = System.Text.Encoding.UTF8.GetBytes(clientJson);
        //        var byteContent = new ByteArrayContent(encodingToBytes);

        //        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //        var result = await client.PostAsync("api/Client", byteContent);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}
