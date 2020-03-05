using System;
using System.Collections.Generic;

namespace Steunijos.Web.Models
{
    public class Paper
    {
        public string PaperId { get; set; }

        public string Title { get; set; }

        public string SavedPath { get; set; }

        public string AuthorName { get; set; }

        public string PaperOriginalName { get; set; }

        public string ActualPath { get; set; }

        public SubjectArea SubjectArea { get; set; }

        public string SubjectAreaId { get; set; }

        public string PaperTopic { get; set; }

        public string JournalId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public string ThumbnailPath { get; set; }

    }
}