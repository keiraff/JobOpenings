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
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime PublicationDate { get; set; }
        public virtual Company Company { get; set;}
        public Decimal Salary { get; set; }
        [EnumDataType(typeof(Experience))]
        public Experience Experience { get; set; }
        [EnumDataType(typeof(Schedule))]
        public Schedule Schedule { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Submit> Submits { get; set; }
        public virtual Favourite Favourite { get; set;}
    }
}
