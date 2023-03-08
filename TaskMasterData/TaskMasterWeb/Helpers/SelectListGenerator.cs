using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskMasterWeb.Repositories;

namespace TaskMasterWeb.Helpers
{
    public class SelectListGenerator
    {
        public static List<SelectListItem> GetEmployeeRoleSelectList()
        {
            var roles = EmployeeRepository.GetAllRoles();

            return roles.Select(r => new SelectListItem
            {
                Text = r.RoleName,
                Value = r.StaffRoleID.ToString()
            }).ToList();
        }

        public static List<SelectListItem> GetClientSelectList()
        {
            var clients = ClientRepository.GetAllClients();

            return clients.Select(c => new SelectListItem
            {
                Text = c.CompanyName,
                Value = c.ClientID.ToString()
            }).ToList();
        }

        public static List<SelectListItem> GetStaffSelectLIst()
        {
            var staff = EmployeeRepository.GetAllEmployees();

            return staff.Select(s => new SelectListItem
            {
                Text = s.FirstName + " " + s.LastName,
                Value = s.StaffID.ToString()
            }).ToList();

        }

        public static List<SelectListItem> GetStatusSelectList()
        {
            var projectStatuses = ProjectStatusRepository.GetAllProjectStatuses();

            return projectStatuses.Select(p => new SelectListItem
            {
                Text = p.StatusValue,
                Value = p.StatusID.ToString()
            }).ToList();
        }

    }
}