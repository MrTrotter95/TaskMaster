using TaskMasterWeb.Models;

namespace TaskMasterWeb.ViewModels.ClientContacts
{
    public class ClientContactCreateViewModel
    {
        public int FK_ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }

        public ClientContactCreateViewModel()
        {

        }

        // Constructor to link the parent client to the client contact so user doesn't have to select who they belong to.
        public ClientContactCreateViewModel(int fk_ClientID)
        {
            FK_ClientID = fk_ClientID;
        }

        public ClientContact CopyToModel(ClientContactCreateViewModel viewModel)
        {
            var clientContact = new ClientContact
            {
                FK_ClientID = viewModel.FK_ClientID,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                EmailAddress = viewModel.EmailAddress,
                ContactNumber = viewModel.ContactNumber
            };

            return clientContact;
        }
    }
}