using RegisterClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterClient.Services.Interface
{
    public interface IClientService
    {
        Task<List<Client>> FindAllAsync();
        Task<Client> FindByIdAsync(int id);
        Task InsertAsync(Client client);
        Task DeleteAsync(int id);
        Task UpdateAsync(Client client);
    }
}
