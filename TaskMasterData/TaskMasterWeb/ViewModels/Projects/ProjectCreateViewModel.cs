using System.Collections.Generic;
using System.Web.Mvc;
using TaskMasterWeb.Helpers;
using TaskMasterWeb.Models;

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
            ClientSelectList = SelectListGenerator.GetClientSelectList();
            StaffSelectList = SelectListGenerator.GetStaffSelectLIst();
            StatusSelectList = SelectListGenerator.GetStatusSelectList();
        }

        // Constructor to link the client to the project automatically so user doesn't have to select who it belongs to.
        public ProjectCreateViewModel(int clientID)
        {
            SelectedClientId = clientID;
            StaffSelectList = SelectListGenerator.GetStaffSelectLIst();
            StatusSelectList = SelectListGenerator.GetStatusSelectList();
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