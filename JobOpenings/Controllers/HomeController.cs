using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JobOpenings.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace JobOpenings.Controllers
{
    //[Route("{Home}")]
    public class HomeController : Controller
    {
        JobOpeningsContext db;
        public HomeController(JobOpeningsContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            this.ViewBag.User = HttpContext.User.Identity.Name;
            User user= db.Users.FirstOrDefault(p => p.Email == HttpContext.User.Identity.Name);
            if(user!=null)
            {
                    this.ViewBag.Username = user.Name;
            }
                this.ViewData["Title"] = "Home";
                return View();
        }

    }
}
