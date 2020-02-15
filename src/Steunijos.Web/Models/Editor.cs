using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steunijos.Web.Models
{
    public class Editor : ApplicationUser
    {
        public string Designation { get; set; }

        public string DepartmentName { get; set; }

        public string FacultyName { get; set; }

        public string UniversityName { get; set; }
    }
}
