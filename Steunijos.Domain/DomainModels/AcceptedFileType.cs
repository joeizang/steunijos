using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steunijos.Domain.DomainModels
{
    public enum AcceptedFileType
    {
        [Display(Name = "PDF")]
        PDF,
        [Display(Name = "WORD DOCUMENT")]
        DOC_DOCX,
        [Display(Name = "PNG IMAGE")]
        PNG
    }
}
