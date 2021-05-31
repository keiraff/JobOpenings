using System.ComponentModel.DataAnnotations;

namespace JobOpenings.Models.Enumerations
{
    public enum Schedule
    {
        [Display(Name = "Full time")]
        FullTime,
        [Display(Name = "Part time")]
        PartTime,
        [Display(Name = "Shift work")]
        ShiftWork,

    }
}
