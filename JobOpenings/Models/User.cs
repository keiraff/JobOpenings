using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobOpenings.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //public string Salt { get; set; }
        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }

        public virtual ICollection<Submit> Submits { get; set; }
        public virtual ICollection<Favourite> Favourites { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
        public bool IsDeleted { get; set; }






    }
}
