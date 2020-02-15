using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Steunijos.Web.Models
{
    public class Journal
    {
        [Key]
        public string IssnNo { get; set; }

        public string VolumeName { get; set; }

        public DateTimeOffset CopyrightYear { get; set; }

        public List<Editor> Editors { get; set; }

        public List<Paper> Papers { get; set; }

        public List<JournalContent> TableOfContents { get; set; }
    }
}
