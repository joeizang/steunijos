using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Steunijos.WebUI.ViewModels.Journal
{
    public class JournalInputModel
    {
        public IFormFile File { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        [Required(ErrorMessage = "Journal Volume is Required!")]
        [Display(Name = "Journal Volume")]
        public string JournalVolume { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Copyright Year")]
        [Required]
        public DateTimeOffset CopyrightYear { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        [Required]
        [Display(Name = "Journal ISSN Number")]
        public string JournalIssn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTimeOffset UploadDate { get; set; } = DateTimeOffset.UtcNow.LocalDateTime;

    }
}
