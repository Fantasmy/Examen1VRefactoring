using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Vueling.Domain.Entities.ClientEntity;

namespace Vueling.Application.Dto
{
    public class PolicyDto
    {
        public Guid id { get; set; }
        public decimal amountInsured { get; set; }
        public string email { get; set; }
        public DateTime inceptionDate { get; set; }
        public bool installmentPayment { get; set; }
        public Guid clientId { get; set; }

    }
}
