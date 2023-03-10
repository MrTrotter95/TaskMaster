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
        public List<ProjectStatusSummaryModel> ProjectStatusCount;

        public EmployeeDashboardViewModel(int employeeID)
        {
            var employee = EmployeeRepository.GetEmployeeByID(employeeID);
            
            StaffID = employee.StaffID;
            FK_StaffRoleID = employee.FK_StaffRoleID;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            ContactNumber = employee.ContactNumber;
            EmailAddress = employee.EmailAddress;
            RoleName = EmployeeRepository.GetRoleByEmployeeID(employeeID);
            Projects = ProjectRepository.GetProjectsAssignedToEmployeeByID(employeeID);
            ProjectStatusCount = ProjectStatusRepository.GetCountOfProjectsGroupedByStatus(employeeID);
        }
    }
}