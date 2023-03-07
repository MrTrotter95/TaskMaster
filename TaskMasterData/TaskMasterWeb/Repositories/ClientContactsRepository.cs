using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskMasterWeb.Models;

namespace TaskMasterWeb.Repositories
{
    public class ClientContactsRepository
    {
        private TaskMasterDataEntities db = new TaskMasterDataEntities();

        public List<ClientContact> GetClientContactsByClientId(int clientID)
        {
            var contacts = db.ClientContacts.Where(c => c.FK_ClientID == clientID).ToList();

            return contacts;
        }
    }
}