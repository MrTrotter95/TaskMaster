using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskMasterWeb.Models;
using TaskMasterWeb.Repositories;
using TaskMasterWeb.ViewModels.AssignedProjects;

namespace TaskMasterWeb.ViewModels.Projects
{
    public class ProjectsViewModel
    {
        public int ProjectID;
        public string ProjectName;
        public ProjectStatus ProjectStatus;
        public List<AssignedProjectsViewModel> AssignedEmployees;
    }
}