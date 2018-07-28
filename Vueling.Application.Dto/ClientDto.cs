using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static Vueling.Domain.Entities.PolicyEntity;

namespace Vueling.Application.Dto
{
    public class ClientDto
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string role { get; set; }

    }
}
