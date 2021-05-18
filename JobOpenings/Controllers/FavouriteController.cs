using JobOpenings.Models;
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
        // GET: FavouriteController
        public ActionResult Index()
        {
            return View(db.Vacancies.Where(p => p.Favourite != null).ToList());
        }

        //// GET: FavouriteController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: FavouriteController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: FavouriteController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: FavouriteController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: FavouriteController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: FavouriteController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: FavouriteController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
