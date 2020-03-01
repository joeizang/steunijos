using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steunijos.Web.ViewModels.Paper
{
    public class SubmitPaper
    {
        public string Title { get; set; }

        public List<SelectListItem> SubjectArea { get; set; }

        public string SubjectAreaSelected { get; set; }
        public string Author { get; set; }

        public DateTimeOffset DateUploaded => DateTimeOffset.UtcNow.LocalDateTime;

        public IFormFile File { get; set; }
    }


}
// new List<string>{
//             "Biology Education",
//             "Building Education",
//             "Chemistry Education",
//             "Computer Science",
//             "Electrical Technology",
//             "Geography Education",
//             "Integrated Science Education",
//             "Mathematics Education",
//             "Welding Technology Education"
//         };