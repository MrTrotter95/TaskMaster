using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskMasterWeb.Models;
using TaskMasterWeb.ViewModels.AssignedProjects;
using TaskMasterWeb.ViewModels.Projects;

namespace TaskMasterWeb.Repositories
{
    public static class AssignedProjectsRepository
    {
        private static TaskMasterDataEntities db = new TaskMasterDataEntities();

        public static List<ProjectsViewModel> GetEmployeesAssignedToProject(int clientID)
        {
            var assignedProjects = db.AssignedProjects
                .Where(ap => ap.Project.FK_ClientID == clientID)
                .Select(g => new ProjectsViewModel
                {
                    ProjectID = g.FK_ProjectID,
                    ProjectName = g.Project.ProjectName,
                    ProjectStatus = g.Project.ProjectStatus,
                    AssignedEmployees = g.Project.AssignedProjects
                                            .Select(ap => new AssignedProjectsViewModel
                                            {
                                                FirstName = ap.Staff.FirstName,
                                                LastName = ap.Staff.LastName,
                                            }).ToList()
                }).ToList();

            return assignedProjects;
        }
    }
}