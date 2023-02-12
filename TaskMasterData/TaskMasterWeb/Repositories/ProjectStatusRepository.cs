﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskMasterWeb.Models;
using TaskMasterWeb.ViewModels.Projects;

namespace TaskMasterWeb.Repositories
{
    public class ProjectStatusRepository
    {
        private TaskMasterDataEntities db = new TaskMasterDataEntities();

        public List<ProjectStatus> GetAllProjectStatuses()
        {
            return db.ProjectStatus.ToList();
        }

        public List<ProjectStatusCountViewModel> GetCountOfProjectsGroupedByStatus(int id)
        {
            var query = from project in db.Projects
                        join status in db.ProjectStatus on project.FK_StatusID equals status.StatusID
                        where project.FK_ClientID == id
                        group project by status.StatusValue into g
                        select new ProjectStatusCountViewModel
                        {
                            ProjectCount = g.Count(),
                            StatusValue = g.Key
                        };

            return query.ToList();
        }
    }
}