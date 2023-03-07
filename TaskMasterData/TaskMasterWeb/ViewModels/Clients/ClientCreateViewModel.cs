using System.ComponentModel.DataAnnotations;
using TaskMasterWeb.Models;

namespace TaskMasterWeb.ViewModels.Clients
{
    public class ClientCreateViewModel
    {
        [Display(Name = "Company")]
        public string CompanyName { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        [Display(Name = "Address")]
        public string StreetAddress { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public ClientCreateViewModel()
        {

        }

        public Client CopyToModel(ClientCreateViewModel viewModel)
        {
            var client = new Client
            {
                CompanyName = viewModel.CompanyName,
                EmailAddress = viewModel.EmailAddress,
                ContactNumber = viewModel.ContactNumber,
                StreetAddress = viewModel.StreetAddress,
                Suburb = viewModel.Suburb,
                City = viewModel.City,
                Country = viewModel.Country
            };

            return client;
        }
    }
}