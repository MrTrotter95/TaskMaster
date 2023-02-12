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

        public List<ClientContact> GetClientContactsByClientId(int id)
        {
            var contacts = db.ClientContacts.Where(c => c.FK_ClientID == id).ToList();

            return contacts;
        }
    }
}