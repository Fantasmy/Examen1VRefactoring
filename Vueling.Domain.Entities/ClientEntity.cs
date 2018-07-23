using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Vueling.Domain.Entities.PolicyEntity;

namespace Vueling.Domain.Entities
{
    public class ClientEntity
    {
        public class Clients
        {
            public Guid id { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string role { get; set; }

            //public virtual ICollection<Policies> Policies { get; set; }
        }
    }
}
