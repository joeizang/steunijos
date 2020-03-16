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

        public string ActualPath { get; set; }

        public string SavedPath { get; set; }

        public DateTimeOffset CopyrightYear { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public JournalContent TableOfContents { get; set; }
        
        public string JournalContentId { get; set; }


    }
}
