using System;
using System.Collections.Generic;

namespace Steunijos.Web.Models
{
    public class PaperAuthor : ApplicationUser
    {
        public string Designation { get; set; }

        public string DepartmentName { get; set; }

        public string FacultyName { get; set; }

        public string UniversityName { get; set; }

        public bool IsValidAuthor { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public List<PaperPayment> Payments { get; set; }

        public List<AuthorsPapers> Papers { get; set; }



    }
};