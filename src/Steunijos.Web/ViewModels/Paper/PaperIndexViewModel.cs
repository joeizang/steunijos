using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steunijos.Web.ViewModels.Paper
{
    public class PaperIndexViewModel
    {
        public string PaperTitle { get; set; }

        public string AuthorName { get; set; }

        public DateTimeOffset SubmissionDate { get; set; }

        public string SubjectArea { get; set; }

        public string PaperId { get; set; }
    }
}
