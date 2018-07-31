using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Infrastructure.Repository.Contracts
{
    public interface IPolicyRepository<PolicyEntity>
    {
        PolicyEntity Add(PolicyEntity model);
        List<PolicyEntity> GetAll();
        PolicyEntity GetById(Guid id);
    }
}
