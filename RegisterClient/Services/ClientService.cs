using Microsoft.EntityFrameworkCore;
using RegisterClient.Data;
using RegisterClient.Models;
using RegisterClient.Services.Exceptions;
using RegisterClient.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterClient.Services
{
    public class ClientService : IClientService
    {
        private readonly DBContext dBContext;

        public ClientService(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<List<Client>> FindAllAsync()
        {
            return await dBContext.Client.ToListAsync();
        }

        public async Task InsertAsync(Client client)
        {
            dBContext.Add(client);
            await dBContext.SaveChangesAsync(); 
        }

        public async Task<Client> FindByIdAsync(int id)
        {
            return await dBContext.Client.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var client = await dBContext.Client.FindAsync(id);
            dBContext.Client.Remove(client);
            await dBContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Client client)
        {
            bool existe = await dBContext.Client.AnyAsync(c => c.Id == client.Id);
            if (!existe)
                throw new NotFoundException("Cliente não encontrado!");

            try
            {
                dBContext.Update(client);
                await dBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbException(e.Message);
            }
        }
    }
}
