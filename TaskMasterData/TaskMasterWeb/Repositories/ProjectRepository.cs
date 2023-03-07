using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskMasterWeb.Models;

namespace TaskMasterWeb.Repositories
{
    public class ProjectRepository
    {
        private TaskMasterDataEntities db = new TaskMasterDataEntities();

        public List<Project> GetProjectsByClientId(int clientID)
        {
            var projects = db.Projects
                .Where(c => c.FK_ClientID == clientID)
                .ToList();

            return projects;
        }

        public List<Project> GetProjectsAssignedToEmployeeByID(int employeeID)
        {
            var projects = db.AssignedProjects
                .Where(ap => ap.FK_StaffID == employeeID)
                .Select(ap => ap.Project)
                .ToList();

            return projects;
        }
    }
}