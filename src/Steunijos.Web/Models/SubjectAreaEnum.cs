using System.ComponentModel.DataAnnotations;

namespace Steunijos.Web.Models
{
    public enum SubjectAreaEnum
    {
        [Display(Name = "Select a Subject Area")]
        Select_a_Subject_Area,
        
        [Display(Name = "Biology Education")]
        Biology_Education,
        
        [Display(Name = "Building Education")]
        Building_Education,
        
        [Display(Name = "Chemistry Education")]
        Chemistry_Education,
        
        [Display(Name = "Computer Science")]
        Computer_Science,
        
        [Display(Name = "Electrical Technology")]
        Electrical_Technology,
        
        [Display(Name = "Geography Education")]
        Geography_Education,
        
        [Display(Name = "Integrated Science Education")]
        Integrated_Science_Education,
        
        [Display(Name = "Mathematics Education")]
        Mathematics_Education,

        Welding_Technology_Education
    }
}