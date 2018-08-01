using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Application.Services.Contracts
{
    public interface IClientService<ClientDto>
    {
        ClientDto Add(ClientDto model);
        List<ClientDto> GetAll();
        ClientDto GetById(Guid id);
        List<ClientDto> GetByName(string name);
        ClientDto GetByEmail(string email);
    }
}
