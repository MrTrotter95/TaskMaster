using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskMasterWeb.Models;

namespace TaskMasterWeb.ViewModels
{
    public class ProjectCreateViewModel
    {
        public string ProjectName { get; set; }
        public int SelectedClientId { get; set; }
        //public int[] SelectedStaffIds { get; set; }
        public int SelectedStatusId { get; set; }



        // Meta Data
        public List<SelectListItems> ClientSelectList;

        public List<SelectListItems> StaffSelectList;

        public List<SelectListItems> StatusSelectList;



        public ProjectCreateViewModel()
        {
            var clients = ClientRepository.GetAllClients();
        }

        public void CopyToModel(Project project)
        {
        

        }

    }




}