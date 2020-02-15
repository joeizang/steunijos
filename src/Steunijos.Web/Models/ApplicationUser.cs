using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steunijos.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherNames { get; set; }

        public string Title { get; set; }

        public string AffiliatedSchool { get; set; }

        public bool IsDepartmentMember { get; set; }

        public bool IsHOD { get; set; }

        public string SpecialtyField { get; set; }

        public string ProfilePhoto { get; set; }

    }
}
