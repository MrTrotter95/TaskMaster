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

        public List<Project> GetProjectsByClientId(int id)
        {
            var projects = db.Projects
                .Where(c => c.FK_ClientID == id)
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

        public int GetActiveProjectsCount(int id)
        {
            var projectCount = db.Projects
                .Where(c => c.FK_ClientID == id)
                .Count();

            return projectCount;
        }

        public int GetActiveProjectsCountForEmployee(int EmployeeID)
        {
            var projectCount = db.AssignedProjects
                .Where(c => c.FK_StaffID == EmployeeID)
                .Count();

            return projectCount;
        }
    }
}