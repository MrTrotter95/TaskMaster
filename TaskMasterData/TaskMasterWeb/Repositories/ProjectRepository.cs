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
            var projects = db.Projects.Where(c => c.FK_ClientID == id).ToList();

            return projects;
        }

        public int GetActiveProjectsCount(int id)
        {
            var projectCount = db.Projects.Where(c => c.FK_ClientID == id).Count();

            return projectCount;
        }
    }
}