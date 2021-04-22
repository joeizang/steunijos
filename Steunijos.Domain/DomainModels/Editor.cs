using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steunijos.Domain.Abstractions;

namespace Steunijos.Domain.DomainModels
{
    public class Editor : BaseDomainModel
    {
        [StringLength(150)]
        public string Designation { get; set; }

        [StringLength(200)]
        public string DepartmentName { get; set; }

        [StringLength(200)]
        public string FacultyName { get; set; }

        [StringLength(200)]
        public string UniversityName { get; set; }
    }
}
