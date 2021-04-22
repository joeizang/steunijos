using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steunijos.Domain.DomainModels
{
    public class AuthorsPapers
    {
        public int PaperId { get; set; }

        public Paper Paper { get; set; }

        public PaperAuthor PaperAuthor { get; set; }

        public int PaperAuthorId { get; set; }

    }
}
