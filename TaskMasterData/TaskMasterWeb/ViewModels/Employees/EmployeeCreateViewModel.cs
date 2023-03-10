using System.Collections.Generic;
using System.Web.Mvc;
using TaskMasterWeb.Helpers;
using TaskMasterWeb.Models;

namespace TaskMasterWeb.ViewModels.Employees
{
    public class EmployeeCreateViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public int SelectedRoleId { get; set; }

        // Meta Data
        public List<SelectListItem> RoleSelectList;

        public EmployeeCreateViewModel()
        {
            RoleSelectList = SelectListGenerator.GetEmployeeRoleSelectList();
        }

        public Staff CopyToModel(EmployeeCreateViewModel viewModel)
        {
            var employee = new Staff
            {
                FK_StaffRoleID = viewModel.SelectedRoleId,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                ContactNumber = viewModel.ContactNumber,
                EmailAddress = viewModel.EmailAddress
            };

            return employee;
        }
    }
}