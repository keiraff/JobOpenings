using JobOpenings.Models;
using JobOpenings.Controllers;
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
                context.Roles.AddRange(
                    new Role
                    {
                        Name = "Admin",
                        IsDeleted = false,
                    },
                    new Role
                    {
                        Name = "Customer",
                        IsDeleted = false,
                    });
                context.SaveChanges();
                context.Users.AddRange(
                    new User
                    {
                        Name = "Admin",
                        Email = "admin@gmail.com",
                        Password = AccountController.GetHash("admin" + AccountController.Salt),
                        Role = context.Roles.FirstOrDefault(x => x.Name == "Admin"),
                        IsDeleted = false,
                    }
                    );
                context.Vacancies.AddRange(
                    new Vacancy
                    {
                        Name = "Shop assistant",
                        PublicationDate = DateTime.Now,
                        Company = new Company
                        {
                            Name = "Bershka",
                            Location = "Grodno",
                            IsDeleted = false,
                        },
                        Category = new Category
                        {
                            Name = "Trading",
                            IsDeleted = false,
                        },
                        User = new User
                        {
                            Name = "Customer1",
                            Email = "sk.xxx@gmail.com",
                            Password = AccountController.GetHash("xxx" + AccountController.Salt),
                            Role = context.Roles.FirstOrDefault(x => x.Name == "Customer"),
                            IsDeleted = false,
                        },
                        Salary = 500,
                        Schedule = Schedule.FullTime,
                        Experience = Experience.DoesNotMatter,
                        IsDeleted = false,
                    },
                    new Vacancy
                    {
                        Name = ".NET Developer",
                        PublicationDate = DateTime.Now,
                        Company = new Company
                        {
                            Name = "Epam",
                            Location = "Grodno",
                            IsDeleted = false,
                        },
                        Category = new Category
                        {
                            Name = "Information Technologies",
                            IsDeleted = false,
                        },
                        User = new User
                        {
                            Name = "Sasageo",
                            Email = "sasageo@gmail.com",
                            Password = AccountController.GetHash("sasageo" + AccountController.Salt),
                            Role = context.Roles.FirstOrDefault(x => x.Name == "Customer"),
                            IsDeleted = false,
                        },
                        Salary = 600,
                        Schedule = Schedule.FullTime,
                        Experience = Experience.MoreThanOneYear,
                        IsDeleted = false,
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
