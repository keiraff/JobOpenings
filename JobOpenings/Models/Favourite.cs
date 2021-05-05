using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobOpenings.Models
{
    public class Favourite
    {
        [Key]
        [ForeignKey("Vacancy")]
        public int VacancyId { get; set; }
        public DateTime DateOfAdding { get; set; }
        public virtual Vacancy Vacancy { get; set; }
    }
}
