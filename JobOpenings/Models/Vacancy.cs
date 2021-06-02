using JobOpenings.Models.Enumerations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobOpenings.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter vacancy name.")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime PublicationDate { get; set; }
        [Required]
        public virtual Company Company { get; set;}
        public int CompanyId { get; set; }
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Please enter salary.")]
        [RegularExpression(@"^(0|-?\d+(\.\d{0,2})?)$", ErrorMessage= "Salary number is invalid. Maximum 2 decimal points.")]
        [Range(0.01, 9999999999999999.99, ErrorMessage = "Salary number is invalid.")]
        public Decimal? Salary { get; set; }
        [EnumDataType(typeof(Experience))]
        [Required(ErrorMessage = "Please enter experience.")]
        public Experience? Experience { get; set; }
        [EnumDataType(typeof(Schedule))]
        [Required(ErrorMessage = "Please enter schedule.")]
        public Schedule? Schedule { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public virtual Category Category { get; set; }
        public virtual ICollection<Submit> Submits { get; set; }
        public virtual ICollection<Favourite> Favourites { get; set;}
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public bool IsDeleted { get; set; }
    }
}
