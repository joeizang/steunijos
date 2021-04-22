using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steunijos.Domain.Abstractions;

namespace Steunijos.Domain.DomainModels
{
    public class PaperAuthor : BaseDomainModel
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

        public List<PaperPayment> Payments { get; set; }

        public List<Paper> Papers { get; set; }

        public List<AuthorsPapers> AuthorsPapers { get; set; }
        
    }
}
