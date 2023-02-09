using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskMasterWeb.Models;

namespace TaskMasterWeb.Repositories
{
    public class ProjectStatusRepository
    {
        private TaskMasterDataEntities db = new TaskMasterDataEntities();

        public List<ProjectStatus> GetAllProjectStatuses()
        {
            return db.ProjectStatus.ToList();
        }
    }
}