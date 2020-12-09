using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Steunijos.Web.Models
{
    public class Paper
    {
        [Key]
        [StringLength(150)]
        public string PaperId { get; set; } = Guid.NewGuid().ToString();

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(300)]
        public string SavedPath { get; set; }

        [StringLength(150)]
        public string AuthorName { get; set; }

        [StringLength(250)]
        public string PaperOriginalName { get; set; }

        [StringLength(300)]
        public string ActualPath { get; set; }

        public SubjectArea SubjectArea { get; set; }

        [StringLength(150)]
        public string SubjectAreaId { get; set; }

        [StringLength(250)]
        public string PaperTopic { get; set; }

        [StringLength(150)]
        public string JournalId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        [StringLength(300)]
        public string ThumbnailPath { get; set; }

    }
}