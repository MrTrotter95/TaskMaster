using System.Collections.Generic;
using TaskMasterWeb.Models;
using TaskMasterWeb.ViewModels.AssignedProjects;

namespace TaskMasterWeb.ViewModels.Projects
{
    public class ClientProjectsModel
    {
        public int ProjectID;
        public string ProjectName;
        public ProjectStatus ProjectStatus;
        public List<AssignedProjectsModel> AssignedEmployees;
    }
}