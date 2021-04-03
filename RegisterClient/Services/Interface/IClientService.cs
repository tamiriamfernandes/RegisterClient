using RegisterClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterClient.Services.Interface
{
    public interface IClientService
    {
        List<Client> FindAll();
        Client FindById(int id);
        void Insert(Client client);
        void Delete(int id);
        void Update(Client client);
    }
}
