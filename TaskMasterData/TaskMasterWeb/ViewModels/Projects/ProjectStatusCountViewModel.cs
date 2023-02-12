using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskMasterWeb.ViewModels.Projects
{
    public class ProjectStatusCountViewModel
    {
        public int ProjectCount { get; set; }
        public string StatusValue { get; set; }

        public ProjectStatusCountViewModel()
        {

        }
    }
}