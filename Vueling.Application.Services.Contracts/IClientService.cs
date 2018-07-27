using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Application.Services.Contracts
{
    public interface IClientService<T>
    {
        T Add(T model);
        List<T> GetAll();
        T GetById(Guid id);
        List<T> GetByName(string name);
        T GetByEmail(string email);
    }
}
