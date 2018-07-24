using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Application.Dto
{
    public class ClientsListDto
    {
        [JsonProperty("clients")]
        public IEnumerable<ClientDto> clientDto { get; set; }
    }
}
