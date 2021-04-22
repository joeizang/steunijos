using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steunijos.Domain.DomainModels
{
    public class Journal
    {
        [StringLength(20)]
        public string IssnNo { get; set; }

        [StringLength(50)]
        public string VolumeName { get; set; }

        [StringLength(300)]
        public string ActualPath { get; set; }

        [StringLength(300)]
        public string SavedPath { get; set; }

        public DateTimeOffset? CopyrightYear { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow.LocalDateTime;

        public JournalContent TableOfContents { get; set; }

        public int JournalContentId { get; set; }

        public List<Paper> Papers { get; set; }
    }
}
