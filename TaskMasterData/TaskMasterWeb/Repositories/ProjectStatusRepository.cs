using System.Collections.Generic;
using System.Linq;
using TaskMasterWeb.Models;
using TaskMasterWeb.ViewModels.Projects;

namespace TaskMasterWeb.Repositories
{
    public static class ProjectStatusRepository
    {
        private static TaskMasterDataEntities db = new TaskMasterDataEntities();

        public static List<ProjectStatus> GetAllProjectStatuses()
        {
            return db.ProjectStatus.ToList();
        }

        public static List<ProjectStatusSummaryModel> GetCountOfProjectsGroupedByStatus(int id)
        {
            var query = from project in db.Projects
                        join status in db.ProjectStatus on project.FK_StatusID equals status.StatusID
                        where project.FK_ClientID == id
                        group project by status.StatusValue into g
                        select new ProjectStatusSummaryModel
                        {
                            ProjectCount = g.Count(),
                            StatusValue = g.Key
                        };

            return query.ToList();
        }

        public static List<ProjectStatusSummaryModel> GetProjectStatusesByEmployee(int employeeID)
        {
            var query = db.AssignedProjects
                  .Where(ap => ap.FK_StaffID == employeeID)
                  .GroupBy(ap => ap.Project.ProjectStatus.StatusValue)
                  .Select(g => new ProjectStatusSummaryModel
                  {
                      ProjectCount = g.Count(),
                      StatusValue = g.Key
                  });

            return query.ToList();
        }
    }
}