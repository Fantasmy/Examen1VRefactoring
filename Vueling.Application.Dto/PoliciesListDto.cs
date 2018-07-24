using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Application.Dto
{
    public class PoliciesListDto
    {
        [JsonProperty("policies")]
        public IEnumerable<PolicyDto> policyDto { get; set; }
    }
}
