using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TaskMasterWeb.Models;
using TaskMasterWeb.Repositories;

namespace TaskMasterWeb.ViewModels.Client
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
        public List<ClientContact> ClientContacts { get; set; }
        public List<Project> Projects { get; set; }
        public int[] ProjectCountInEachStatus { get; set; }
        public int TotalActiveProjects { get; set; }


        public ClientDetailsViewModel()
        {

        }

        public ClientDetailsViewModel(int id)
        {
            var clientRepository = new ClientRepository();
            var clientContactsRepository = new ClientContactsRepository();
            var projectsRepository = new ProjectRepository();

            var client = clientRepository.GetClientById(id);

            ClientID = client.ClientID;
            CompanyName = client.CompanyName;
            EmailAddress = client.EmailAddress;
            ContactNumber = client.ContactNumber;

            ClientContacts = clientContactsRepository.GetClientContactsByClientId(id);
            Projects = projectsRepository.GetProjectsByClientId(id);
            TotalActiveProjects = projectsRepository.GetActiveProjectsCount(id);
        }
    }
}