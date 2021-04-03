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

        public List<Client> FindAll()
        {
            return dBContext.Client.ToList();
        }

        public void Insert(Client client)
        {
            dBContext.Add(client);
            dBContext.SaveChanges(); 
        }

        public Client FindById(int id)
        {
            return dBContext.Client.Where(c => c.Id == id).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var client = dBContext.Client.Find(id);
            dBContext.Client.Remove(client);
            dBContext.SaveChanges();
        }

        public void Update(Client client)
        {
            if(!dBContext.Client.Any(c => c.Id == client.Id))
                throw new NotFoundException("Cliente não encontrado!");

            try
            {
                dBContext.Update(client);
                dBContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbException(e.Message);
            }
        }
    }
}
