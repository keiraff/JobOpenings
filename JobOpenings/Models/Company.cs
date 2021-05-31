using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobOpenings.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter company name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter company location.")]
        public string Location { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
        public bool IsDeleted { get; set; }
    }
}
