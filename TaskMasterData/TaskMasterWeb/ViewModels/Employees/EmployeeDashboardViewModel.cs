using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TaskMasterWeb.Models;
using TaskMasterWeb.Repositories;
using TaskMasterWeb.ViewModels.Projects;

namespace TaskMasterWeb.ViewModels.Employees
{
    public class EmployeeDashboardViewModel
    {
        public int StaffID { get; set; }

        [Display(Name = "Role")]
        public int FK_StaffRoleID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        // Meta Data
        public string RoleName;
        public List<Project> Projects;
        public List<ProjectStatusSummaryViewModel> ProjectStatusCount;

        public EmployeeDashboardViewModel(int employeeID)
        {
            var employeeRepository = new EmployeeRepository();
            var projectsRespository = new ProjectRepository();
            var projectStatusRepository = new ProjectStatusRepository();

            var employee = employeeRepository.GetEmployeeByID(employeeID);
            var assignedProjects = projectsRespository.GetProjectsAssignedToEmployeeByID(employeeID);
            
            StaffID = employee.StaffID;
            FK_StaffRoleID = employee.FK_StaffRoleID;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            ContactNumber = employee.ContactNumber;
            EmailAddress = employee.EmailAddress;
            RoleName = employeeRepository.GetRoleByEmployeeID(employeeID);
            Projects = assignedProjects;
            ProjectStatusCount = projectStatusRepository.GetCountOfProjectsGroupedByStatus(employeeID);
        }
    }
}