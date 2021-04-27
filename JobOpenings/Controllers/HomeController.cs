using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JobOpenings.Models;

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
            return View(db.Vacancies.ToList());
        }
    }
}
