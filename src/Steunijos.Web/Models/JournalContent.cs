namespace Steunijos.Web.Models
{
    public class JournalContent
    {
        public string JournalContentId { get; set; }

        public string ContentTitle { get; set; }

        public PaperAuthor Author { get; set; }

        public int JournalPosition { get; set; }

        public string JournalIssnNo { get; set; }

        public Journal Journal { get; set; }

    }
}