using JobOpenings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOpenings
{
    public class InitialData
    {
        public static void Initialize(JobOpeningsContext context)
        {
            if (!context.Vacancies.Any())
            {
                context.Vacancies.AddRange(
                    new Vacancy
                    {
                        Name = "Shop assistant",
                        PublicationDate = DateTime.Now,
                        Location = "Grodno",
                        Company = "Bershka"

                    },
                    new Vacancy
                    {
                        Name = ".NET Developer",
                        PublicationDate = DateTime.Now,
                        Location = "Grodno",
                        Company = "Epam"

                    }
                    );
                context.SaveChanges();
                     
                
                
            }
        }
    }
}
