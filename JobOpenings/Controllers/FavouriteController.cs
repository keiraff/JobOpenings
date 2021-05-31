using JobOpenings.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOpenings.Controllers
{
    [Route("Favourite")]
    public class FavouriteController : Controller
    {
        JobOpeningsContext db;

        public FavouriteController(JobOpeningsContext context)
        {
            db = context;
        }

        [Authorize(Roles = "Admin, Customer")]
        public ActionResult Index()
        {
            ViewBag.User = HttpContext.User.Identity.Name;
            List<Favourite> favs = db.Favourites.Where(p=>p.User.Email == HttpContext.User.Identity.Name).ToList();
            return View(favs);
        }
    }
}
