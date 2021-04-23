using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steunijos.WebUI.ViewModels.Paper
{
    public class PaperDetailsViewModel
    {
        public int PaperId { get; set; }

        public string SavedPath { get; set; }

        public string AuthorName { get; set; }

        public string PaperOriginalName { get; set; }

        public string SubjectArea { get; set; }

        public int JournalId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string ThumbnailPath { get; set; }
    }
}
