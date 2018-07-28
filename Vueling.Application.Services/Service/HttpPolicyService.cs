using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Vueling.Application.Dto;
using Vueling.Common.Layer;

namespace Vueling.Application.Services.Service
{
    public static class HttpPolicyService
    {
        /// <summary>
        /// The client
        /// </summary>
        static HttpClient policy;
        
        /// <summary>
        /// Initializes the <see cref="ClientController"/> class.
        /// </summary>
        static HttpPolicyService()
            {
                var uriPolicy = ConfigurationManager.AppSettings["UriPolicy"];
                policy = new HttpClient();
                policy.BaseAddress = new Uri(uriPolicy);
                policy.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            }

        /// <summary>
        /// Gets all policies from json url.
        /// </summary>
        /// <returns>Returns all policies data from url</returns>
        public static async Task<PoliciesListDto> GetAllPolicies()
            {
                PoliciesListDto policiesListDto = null;

                try
                {
                    HttpResponseMessage response = policy.GetAsync(policy.BaseAddress).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine(Resource2.ReqMsgInfo + response.RequestMessage + Resource2.n);
                        Console.WriteLine(Resource2.ReqMsgHeader + response.Content.Headers + Resource2.n);

                        var policyJsonString = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(Resource2.RespData + policyJsonString);

                        policiesListDto = JsonConvert.DeserializeObject<PoliciesListDto>(policyJsonString);
                        
                    }

                }
                catch (HttpRequestException ex)
                {

                    throw new VuelingException();
                }

                return policiesListDto;

            }
        }
    }

