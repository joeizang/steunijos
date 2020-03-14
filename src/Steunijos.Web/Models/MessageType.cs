using System.ComponentModel.DataAnnotations;

namespace Steunijos.Web.Models
{
    public enum MessageType
    {
        [Display(Name = "Make Inquiry")]
        Make_Inquiry,
        [Display(Name = "Report Incident")]
        Report_Incident,
        [Display(Name = "Reaching Out")]
        Reaching_Out,
        [Display(Name = "Comments")]
        Comments
    }
}