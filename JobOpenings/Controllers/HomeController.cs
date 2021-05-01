using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JobOpenings.Models;
using Microsoft.EntityFrameworkCore;

namespace JobOpenings.Controllers
{
    [Route("{Home}")]
    public class HomeController : Controller
    {
        JobOpeningsContext db;
        public HomeController(JobOpeningsContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            //var vacancies = db.Vacancies.Include(c => c.Company);
            return View(db.Vacancies.ToList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult VacancyInfo(int? id)
        {
            if (id == null)
            {
                throw new Exception("Id is null");
            }
            Vacancy vacancy = db.Vacancies.Find(id);
            if (vacancy == null)
            {
                throw new Exception("Vacancy is null");
            }
            return View(vacancy);
        }
    }
}
