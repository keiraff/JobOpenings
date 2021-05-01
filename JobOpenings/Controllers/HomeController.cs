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
    public class HomeController : Controller
    {
        JobOpeningsContext db;
        public HomeController(JobOpeningsContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var vacancies = db.Vacancies.Include(c => c.Company);
            return View(vacancies.ToList());
        }
    }
}
