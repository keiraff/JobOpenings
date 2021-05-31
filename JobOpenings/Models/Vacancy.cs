using JobOpenings.Models.Enumerations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Please enter salary.")]
        [Range(1, 100000000, ErrorMessage = "Salary number is invalid.")]
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
