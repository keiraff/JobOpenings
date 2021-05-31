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
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MobilePhone { get; set; }
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
