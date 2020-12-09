using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Steunijos.Web.Models
{
    public class PaperAuthor : ApplicationUser
    {
        [StringLength(20)]
        public string Designation { get; set; }

        [StringLength(150)]
        public string DepartmentName { get; set; }

        [StringLength(150)]
        public string FacultyName { get; set; }

        [StringLength(150)]
        public string UniversityName { get; set; }

        public bool IsValidAuthor { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public List<PaperPayment> Payments { get; set; }

    }
};