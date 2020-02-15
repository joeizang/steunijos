using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steunijos.Web.Models
{
    public class AuthorsPapers
    {
        public string PaperAuthorId { get; set; }

        public string PaperId { get; set; }

        public PaperAuthor PaperAuthor { get; set; }

        public Paper Paper { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

    }
}
