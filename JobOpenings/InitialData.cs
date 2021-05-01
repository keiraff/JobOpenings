using JobOpenings.Models;
using JobOpenings.Models.Enumerations;
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
                        Company = new Company
                        {
                            Name = "Bershka",
                            Location = "Grodno",
                        },
                        Category = new Category
                        {
                            Name = "Trading"
                        },
                        Salary = 500,
                        Schedule = Schedule.FullTime,
                        Experience = Experience.DoesNotMatter,
                    },
                    new Vacancy
                    {
                        Name = ".NET Developer",
                        PublicationDate = DateTime.Now,
                        Company = new Company
                        {
                            Name = "Epam",
                            Location = "Grodno",
                        },
                        Category = new Category
                        {
                            Name = "Information Technologies"
                        },
                        Salary = 600,
                        Schedule = Schedule.FullTime,
                        Experience = Experience.MoreThanOneYear,
                    }
                    ); ;
                context.SaveChanges();
            }
        }
    }
}
