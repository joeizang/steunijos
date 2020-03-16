using System;

namespace Steunijos.Web.ViewModels.Paper
{
    public class PaperDetailsViewModel
    {
        public string PaperId { get; set; }

        public string SavedPath { get; set; }

        public string AuthorName { get; set; }

        public string PaperOriginalName { get; set; }

        public string SubjectArea { get; set; }

        public string JournalId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string ThumbnailPath { get; set; }
    }
}