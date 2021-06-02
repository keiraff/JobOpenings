using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobOpenings.Models
{
    public class Submit
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your surname.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Please enter your mobile number.")]
        [RegularExpression(@"^([\+]?([0-9]{10,15}))$", ErrorMessage = "Mobile number is invalid.")]
        [DataType(DataType.PhoneNumber)]
        public string MobilePhone { get; set; }
        [Required(ErrorMessage = "Please enter your email.")]
        [EmailAddress(ErrorMessage = "Email address is incorrect.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public DateTime PublicationDate { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        //[ForeignKey("Vacancy")]
        public int VacancyId { get; set; }
        public virtual Vacancy Vacancy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
