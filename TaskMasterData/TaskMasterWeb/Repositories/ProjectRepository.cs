using System.Collections.Generic;
using System.Linq;
using TaskMasterWeb.Models;

namespace TaskMasterWeb.Repositories
{
    public static class ProjectRepository
    {
        private static TaskMasterDataEntities db = new TaskMasterDataEntities();

        public static List<Project> GetProjectsByClientId(int clientID)
        {
            var projects = db.Projects
                .Where(c => c.FK_ClientID == clientID)
                .ToList();

            return projects;
        }

        public static List<Project> GetProjectsAssignedToEmployeeByID(int employeeID)
        {
            var projects = db.AssignedProjects
                .Where(ap => ap.FK_StaffID == employeeID)
                .Select(ap => ap.Project)
                .ToList();

            return projects;
        }
    }
}