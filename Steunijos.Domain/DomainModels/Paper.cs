﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steunijos.Domain.Abstractions;

namespace Steunijos.Domain.DomainModels
{
    public class Paper : BaseDomainModel
    {
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(300)]
        public string SavedPath { get; set; }

        public List<PaperAuthor> Authors { get; set; }

        public List<AuthorsPapers> AuthorsPapers { get; set; }

        [StringLength(250)]
        public string PaperOriginalName { get; set; }

        [StringLength(300)]
        public string ActualPath { get; set; }

        [StringLength(250)]
        public string PaperTopic { get; set; }

        [StringLength(150)]
        public int JournalId { get; set; }

        public Journal Journal { get; set; }
        
        [StringLength(300)]
        public string ThumbnailPath { get; set; }
    }
}
