﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Steunijos.Web.Areas.Identity.Pages.Account
{
    public enum Designation
    {
        [Display(Name = "Select a Designation")]
        Select_A_Designation,
        [Display(Name = "Dr. (Phd)")]
        Dr,
        [Display(Name = "Mr.")]
        Mr,
        [Display(Name = "Miss")]
        Ms,
        [Display(Name = "Mrs.")]
        Mrs,
        [Display(Name = "Professor")]
        Prof,
        [Display(Name = "Engineer")]
        Eng,
    }
}
