using JobOpenings.Models.Enumerations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOpenings.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublicationDate { get; set; }
        public virtual Company Company { get; set;}
        public Decimal Salary { get; set; }
        public Experience Experience { get; set; }
        public Schedule Schedule { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<Submit> Submits { get; set; }
    }
}
