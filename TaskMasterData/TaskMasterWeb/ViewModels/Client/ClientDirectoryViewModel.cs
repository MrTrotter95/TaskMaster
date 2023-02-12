using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TaskMasterWeb.Models;
using TaskMasterWeb.Repositories;

namespace TaskMasterWeb.ViewModels
{
    public class ClientDirectoryViewModel
    {
        public int ClientID { get; set; }

        [Display(Name = "Company")]
        public string CompanyName { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }


    }
}