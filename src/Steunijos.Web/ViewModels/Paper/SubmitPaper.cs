using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Steunijos.Web.Models;

namespace Steunijos.Web.ViewModels.Paper
{
    public class SubmitPaper
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Every Paper must have a Title!")]
        [StringLength(100)]
        public string Title { get; set; }
        
        [Display(Name = "Subject Area")]
        [EnumDataType(typeof(SubjectAreaEnum))]
        public SubjectAreaEnum SubjectArea { get; set; }

        public string SubjectAreaSelected { get; set; }

        [Required(ErrorMessage = "Every Paper must have at least one author!")]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string Author { get; set; }

        public DateTimeOffset DateUploaded => DateTimeOffset.UtcNow.LocalDateTime;

        public IFormFile File { get; set; }
    }


}
