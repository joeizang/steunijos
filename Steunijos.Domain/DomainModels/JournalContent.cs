using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steunijos.Domain.Abstractions;

namespace Steunijos.Domain.DomainModels
{
    public class JournalContent : BaseDomainModel
    {
        [StringLength(150)]
        public string ContentTitle { get; set; }

        public PaperAuthor Author { get; set; }

        public int JournalPosition { get; set; }

        [StringLength(150)]
        public string JournalId { get; set; }

        public Journal Journal { get; set; }
    }
}
