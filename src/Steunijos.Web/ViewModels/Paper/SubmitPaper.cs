using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steunijos.Web.ViewModels.Paper
{
    public class SubmitPaper
    {
        public string Title { get; set; }

        public string PaperTopic { get; set; }

        public IFormFile File { get; set; }
    }
}
