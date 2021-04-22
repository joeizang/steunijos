using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Steunijos.WebUI.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string OtherNames { get; set; }

        [StringLength(150)]
        public string Title { get; set; }

        [StringLength(150)]
        public string AffiliatedSchool { get; set; }

        public bool IsDepartmentMember { get; set; }

        public bool IsHOD { get; set; }

        [StringLength(150)]
        public string SpecialtyField { get; set; }

        [StringLength(300)]
        public string ProfilePhoto { get; set; }

    }
}
