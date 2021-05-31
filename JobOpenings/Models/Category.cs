using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOpenings.Models
{
   
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
        public bool IsDeleted { get; set; }
    }
}
