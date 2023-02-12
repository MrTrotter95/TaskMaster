using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskMasterWeb.Models;

namespace TaskMasterWeb.ViewModels.Projects
{
    public class AssignedProjectsViewModel
    {
        public AssignedProjectsViewModel()
        {

        }

        public List<AssignedProject> CopyToModel(ProjectCreateViewModel viewModel, int projectId)
        {
            var assignedProjects = viewModel.SelectedStaffIds.Select(id => new AssignedProject
            {
                FK_StaffID = id,
                FK_ProjectID = projectId
            });

            return assignedProjects.ToList();
        }

    }
}