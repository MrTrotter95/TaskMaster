using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskMasterWeb.Models;


namespace TaskMasterWeb.Repositories
{ 
    public class ClientRepository
    {
        private TaskMasterDataEntities db = new TaskMasterDataEntities();

        public List<Client> GetAllClients()
        {
            return db.Clients.ToList();
        }

        public Client GetClientById(int id)
        {
            return db.Clients.Find(id);
        }

    }
}