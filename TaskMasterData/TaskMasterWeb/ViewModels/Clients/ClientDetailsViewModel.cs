using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TaskMasterWeb.Models;
using TaskMasterWeb.Repositories;
using TaskMasterWeb.ViewModels.AssignedProjects;
using TaskMasterWeb.ViewModels.Projects;

namespace TaskMasterWeb.ViewModels.Clients
{
    public class ClientDetailsViewModel
    {
        public int ClientID { get; set; }

        [Display(Name = "Company")]
        public string CompanyName { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        [Display(Name = "Address")]
        public string StreetAddress { get; set; }

        [Display(Name = "Suburb")]
        public string Suburb { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        // Meta Data
        public List<ClientContact> ClientContacts;
        public List<ClientProjectsModel> Projects;
        public List<ProjectStatusSummaryModel> ProjectStatusCount;

        public ClientDetailsViewModel(int clientID)
        {
            var client = ClientRepository.GetClientById(clientID);

            ClientID = client.ClientID;
            CompanyName = client.CompanyName;
            EmailAddress = client.EmailAddress;
            ContactNumber = client.ContactNumber;
            StreetAddress = client.StreetAddress;
            Suburb = client.Suburb;
            City = client.City;
            Country = client.Country;
            ClientContacts = ClientContactsRepository.GetClientContactsByClientId(client.ClientID);
            Projects = AssignedProjectsRepository.GetEmployeesAssignedToProject(client.ClientID);
            ProjectStatusCount = ProjectStatusRepository.GetCountOfProjectsGroupedByStatus(client.ClientID);
        }
    }
}