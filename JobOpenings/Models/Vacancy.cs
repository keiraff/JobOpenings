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
        [Required(ErrorMessage = "Field is required.")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime PublicationDate { get; set; }
        [Required]
        public virtual Company Company { get; set;}
        public int CompanyId { get; set; }
        public Decimal Salary { get; set; }
        [EnumDataType(typeof(Experience))]
        public Experience Experience { get; set; }
        [EnumDataType(typeof(Schedule))]
        public Schedule Schedule { get; set; }
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
