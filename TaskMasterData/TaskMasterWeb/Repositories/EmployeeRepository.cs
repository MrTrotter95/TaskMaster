using System.Collections.Generic;
using System.Linq;
using TaskMasterWeb.Models;

namespace TaskMasterWeb.Repositories
{
    public static class EmployeeRepository
    {
        private static TaskMasterDataEntities db = new TaskMasterDataEntities();

        public static List<Staff> GetAllEmployees()
        {
            return db.Staffs.ToList();
        }

        public static Staff GetEmployeeByID(int employeeID)
        {
            return db.Staffs.Find(employeeID);
        }

        public static List<StaffRole> GetAllRoles()
        {
            return db.StaffRoles.ToList();
        }

        public static string GetRoleByEmployeeID(int EmployeeID)
        {
            return db.StaffRoles
                .Where(r => r.StaffRoleID == EmployeeID)
                .Select(r => r.RoleName)
                .FirstOrDefault();
        }
    }
}