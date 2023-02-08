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
        public int[] SelectedStaffIds { get; set; }
        public int SelectedStatusId { get; set; }
        public int FK_ClientID { get; set; }
        public int FK_StatusID { get; set; }
        public int FK_StaffID { get; set; }

        public List<Client> Clients { get; set; }
        public List<Staff> Staff { get; set; }
        public List<ProjectStatus> Statuses { get; set; }



        public ProjectCreateViewModel()
        {
            
        }

        public void CopyToModel(Project project)
        {
        

        }

    }




}