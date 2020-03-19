using System;
using System.Collections.Generic;

namespace Steunijos.Web.Areas.Admin.ViewModels
{
    public class UsersViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherNames { get; set; }

        public string UserId { get; set; }

        public RolesViewModel Role { get; set; }
        
        public string Emailaddress { get; set; }

        public string Username { get; set; }

        public string LastLoginDate { get; set; }
    }
}