using System.ComponentModel.DataAnnotations;

namespace JobOpenings.Models.Enumerations
{
    public enum Experience
    {
        [Display(Name = "Does not matter")] 
        DoesNotMatter,
        [Display(Name = "No Experience")]
        NoExperience,
        [Display(Name = "More than 1 year")]
        MoreThanOneYear,
        [Display(Name = "More than 2 years")]
        MoreThanTwoYears,
        [Display(Name = "More than 3 year")]
        MoreThanThreeYears,
        [Display(Name = "More than 5 year")]
        MoreThanFiveYears,
        [Display(Name = "More than 10 year")]
        MoreThanTenYears,


    }
}
