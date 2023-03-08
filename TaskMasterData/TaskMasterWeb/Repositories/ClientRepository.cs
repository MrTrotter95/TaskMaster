using System.Collections.Generic;
using System.Linq;
using TaskMasterWeb.Models;


namespace TaskMasterWeb.Repositories
{
    public static class ClientRepository
    {
        private static TaskMasterDataEntities db = new TaskMasterDataEntities();

        public static List<Client> GetAllClients()
        {
            return db.Clients.ToList();
        }

        public static Client GetClientById(int clientID)
        {
            return db.Clients.Find(clientID);
        }

    }
}