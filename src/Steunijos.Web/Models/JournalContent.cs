using System.ComponentModel.DataAnnotations;

namespace Steunijos.Web.Models
{
    public class JournalContent
    {
        [StringLength(150)]
        public string JournalContentId { get; set; }

        [StringLength(150)]
        public string ContentTitle { get; set; }

        public PaperAuthor Author { get; set; }

        public int JournalPosition { get; set; }

        [StringLength(150)]
        public string JournalId { get; set; }

        public Journal Journal { get; set; }

    }
}