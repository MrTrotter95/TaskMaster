using System.Collections.Generic;
using System.Linq;
using TaskMasterWeb.Models;

namespace TaskMasterWeb.Repositories
{
    public static class ClientContactsRepository
    {
        private static TaskMasterDataEntities db = new TaskMasterDataEntities();

        public static List<ClientContact> GetClientContactsByClientId(int clientID)
        {
            var contacts = db.ClientContacts.Where(c => c.FK_ClientID == clientID).ToList();

            return contacts;
        }
    }
}