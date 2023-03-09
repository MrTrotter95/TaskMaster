using System.Collections.Generic;
using System.Linq;
using TaskMasterWeb.Models;

namespace TaskMasterWeb.ViewModels.Projects
{
    public class AssignProjectToEmployeesModel
    {
        public AssignProjectToEmployeesModel()
        {

        }

        public static List<AssignedProject> CopyToModel(ProjectCreateViewModel viewModel, int projectId)
        {
            var assignedProjects = viewModel.SelectedStaffIds.Select(id => new AssignedProject
            {
                FK_StaffID = id,
                FK_ProjectID = projectId
            }).ToList();

            return assignedProjects;
        }

    }
}