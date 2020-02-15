using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steunijos.Web.Models
{
    public class SubjectArea
    {
        public string SubjectAreaId { get; set; }

        public string SubjectAreaName { get; set; }

        public List<Paper> Papers { get; set; }

    }
}
