using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskMasterWeb.Models;

namespace TaskMasterWeb.Repositories
{
    public class StaffRepository
    {
        private TaskMasterDataEntities db = new TaskMasterDataEntities();

        public List<Staff> GetAllStaff()
        {
            return db.Staffs.ToList();
        }
    }
}