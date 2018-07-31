using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Infrastructure.Repository.Contracts
{
    public interface IClientRepository<ClientEntity>
    {
        ClientEntity Add(ClientEntity model);
        List<ClientEntity> GetAll();
        ClientEntity GetById(Guid id);
        List<ClientEntity> GetByName(string name);
        ClientEntity GetByEmail(string email);
    }
}
