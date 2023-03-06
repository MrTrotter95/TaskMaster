using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskMasterWeb.Models;
using TaskMasterWeb.Repositories;

namespace TaskMasterWeb.ViewModels
{
    public class ProjectCreateViewModel
    {
        public string ProjectName { get; set; }
        public int SelectedClientId { get; set; }
        public int[] SelectedStaffIds { get; set; }
        public int SelectedStatusId { get; set; }


        // Meta Data
        public List<SelectListItem> ClientSelectList;
        public List<SelectListItem> StaffSelectList;
        public List<SelectListItem> StatusSelectList;

        public ProjectCreateViewModel()
        {
            var clientRepository = new ClientRepository();
            var staffRepository = new EmployeeRepository();
            var projectStatusRepository = new ProjectStatusRepository();

            var clients = clientRepository.GetAllClients();
            var staff = staffRepository.GetAllEmployees();
            var projectStatuses = projectStatusRepository.GetAllProjectStatuses();

            ClientSelectList = clients.Select(c => new SelectListItem
            {
                Text = c.CompanyName,
                Value = c.ClientID.ToString()
            }).ToList();

            StaffSelectList = staff.Select(s => new SelectListItem
            {
                Text = s.FirstName + " " + s.LastName,
                Value = s.StaffID.ToString()
            }).ToList();
            
            StatusSelectList = projectStatuses.Select(p => new SelectListItem
            {
                Text = p.StatusValue,
                Value = p.StatusID.ToString()
            }).ToList();
        }

        // Create project from Client/Details/ID view
        public ProjectCreateViewModel(int clientID)
        {
            var staffRepository = new EmployeeRepository();
            var projectStatusRepository = new ProjectStatusRepository();

            var staff = staffRepository.GetAllEmployees();
            var projectStatuses = projectStatusRepository.GetAllProjectStatuses();

            SelectedClientId = clientID;

            StaffSelectList = staff.Select(s => new SelectListItem
            {
                Text = s.FirstName + " " + s.LastName,
                Value = s.StaffID.ToString()
            }).ToList();

            StatusSelectList = projectStatuses.Select(p => new SelectListItem
            {
                Text = p.StatusValue,
                Value = p.StatusID.ToString()
            }).ToList();
        }

        public Project CopyToModel(ProjectCreateViewModel viewModel)
        {
            var project = new Project
            {
                ProjectName = viewModel.ProjectName,
                FK_ClientID = viewModel.SelectedClientId,
                FK_StatusID = viewModel.SelectedStatusId,
                CreationDate = null
            };

            return project;
        }

    }




}