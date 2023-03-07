using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskMasterWeb.Models;

namespace TaskMasterWeb.Repositories
{
    public class EmployeeRepository
    {
        private TaskMasterDataEntities db = new TaskMasterDataEntities();

        public List<Staff> GetAllEmployees()
        {
            return db.Staffs.ToList();
        }

        public Staff GetEmployeeByID(int employeeID)
        {
            return db.Staffs.Find(employeeID);
        }

        public List<StaffRole> GetAllRoles()
        {
            return db.StaffRoles.ToList();
        }

        public string GetRoleByEmployeeID(int EmployeeID)
        {
            return db.StaffRoles
                .Where(r => r.StaffRoleID == EmployeeID)
                .Select(r => r.RoleName)
                .FirstOrDefault();
        }

        public List<SelectListItem> GetEmployeeRoleSelectList()
        {
            var roles = GetAllRoles();

            return roles.Select(r => new SelectListItem
            {
                Text = r.RoleName,
                Value = r.StaffRoleID.ToString()
            }).ToList();
        }
    }
}