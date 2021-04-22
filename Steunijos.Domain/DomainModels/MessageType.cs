using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steunijos.Domain.DomainModels
{
    public enum MessageType
    {
        [Display(Name = "Make Inquiry")]
        MakeInquiry,
        [Display(Name = "Report Incident")]
        ReportIncident,
        [Display(Name = "Reaching Out")]
        ReachingOut,
        [Display(Name = "Comments")]
        Comments
    }
}
