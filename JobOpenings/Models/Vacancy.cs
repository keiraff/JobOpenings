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
        public string Location { get; set; }
        public string Company { get; set; }
        public Decimal Payment { get; set; }
        public string Education { get; set; }//enum
        public string Experience { get; set; }// enum
        public string Schedule { get; set; }//enum
        public Category Category { get; set; }



    
}
}
