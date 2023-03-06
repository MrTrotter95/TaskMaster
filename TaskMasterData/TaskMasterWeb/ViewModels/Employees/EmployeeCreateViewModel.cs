using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskMasterWeb.Models;
using TaskMasterWeb.Repositories;

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
            var staffRepository = new EmployeeRepository();

            var roles = staffRepository.GetAllRoles();

            RoleSelectList = roles.Select(r => new SelectListItem
            {
                Text = r.RoleName,
                Value = r.StaffRoleID.ToString()
            }).ToList();
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