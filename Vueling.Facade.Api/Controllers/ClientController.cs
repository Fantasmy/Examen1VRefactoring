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
using Vueling.Application.Dto;
using Vueling.Infrastructure.Repository.DataModel;

namespace Vueling.Facade.Api.Controllers
{
    public class ClientController : ApiController
    {
        /// <summary>
        /// The client
        /// </summary>
        static HttpClient client;
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientController"/> class.
        /// </summary>
        public ClientController() { }
        /// <summary>
        /// Initializes the <see cref="ClientController"/> class.
        /// </summary>
        static ClientController()
        {
            //var uriClient = ConfigurationManager.AppSettings["UriClient"];
            client = new HttpClient();
            client.BaseAddress = new Uri("www.mocky.io/v2/5808862710000087232b75ac");
        }

        /// <summary>
        /// Gets all clients.
        /// </summary>
        /// <returns></returns>
        public async Task<Object> GetAllClients()
        {
            //IEnumerable<Clients> clientsList = new List<Clients>();

            List<Object> clientsList = new List<Object>();
            try
            {
                //var defApi = ConfigurationManager.AppSettings["DefApi"];

                HttpResponseMessage response = client.GetAsync("DefaultApi").Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(Resource.ReqMsgInfo + response.RequestMessage + Resource.n);
                    Console.WriteLine(Resource.ReqMsgHeader + response.Content.Headers + Resource.n);

                    var clientJsonString = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(Resource.RespData + clientJsonString);

                    //var deserialized = JsonConvert.DeserializeObject<IEnumerable<Clients>>(clientJsonString);
                    //clientsList = deserialized;

                    DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(clientJsonString);

                    DataTable dataTable = dataSet.Tables["clients"];

                    Console.WriteLine(dataTable.Rows.Count);
                    // 2

                    foreach (DataRow row in dataTable.Rows)
                    {
                        Console.WriteLine(row["id"] + " - " + row["name"] + " - " + row["email"] + " - " + row["role"]);
                        clientsList.Add(row);
                    }

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return clientsList;

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
