using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steunijos.Domain.DomainModels
{
    public enum SubjectAreaEnum
    {
        [Display(Name = "Select a Subject Area")]
        SelectASubjectArea,

        [Display(Name = "Biology Education")]
        BiologyEducation,

        [Display(Name = "Building Education")]
        BuildingEducation,

        [Display(Name = "Chemistry Education")]
        ChemistryEducation,

        [Display(Name = "Computer Science")]
        ComputerScience,

        [Display(Name = "Electrical Technology")]
        ElectricalTechnology,

        [Display(Name = "Geography Education")]
        GeographyEducation,

        [Display(Name = "Integrated Science Education")]
        IntegratedScienceEducation,

        [Display(Name = "Mathematics Education")]
        MathematicsEducation,

        [Display(Name = "Welding Technology Education")]
        WeldingTechnologyEducation
    }
}
