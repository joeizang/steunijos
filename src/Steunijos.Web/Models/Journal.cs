using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Steunijos.Web.Models
{
    public class Journal
    {
        [Key] [StringLength(150)] public string JournalId { get; set; } = Guid.NewGuid().ToString();

        [StringLength(20)]
        public string IssnNo { get; set; }

        [StringLength(50)]
        public string VolumeName { get; set; }

        [StringLength(300)]
        public string ActualPath { get; set; }

        [StringLength(300)]
        public string SavedPath { get; set; }

        public DateTimeOffset CopyrightYear { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public JournalContent TableOfContents { get; set; }

        [StringLength(150)]
        public string JournalContentId { get; set; }


    }
}
