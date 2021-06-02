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
    [Route("Submit")]
    public class SubmitController : Controller
    {
        JobOpeningsContext db;

        public SubmitController(JobOpeningsContext context)
        {
            db = context;
        }
        [Authorize(Roles = "Admin, Customer")]
        public ActionResult Index()
        {
            ViewBag.User = HttpContext.User.Identity.Name;
            List<Submit> submits = db.Submits.Where(p => p.User.Email == HttpContext.User.Identity.Name).ToList();
            return View(submits);
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin, Customer")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new Exception("Id is null");
            }
            Submit submit = db.Submits.Find(id);
            if (submit == null)
            {
                throw new Exception("Submit is null");
            }
            ViewBag.User = HttpContext.User.Identity.Name;
            return View(submit);
        }
        [HttpGet]
        [Route("Delete/{id:int}")]
        [Authorize(Roles = "Admin, Customer")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new Exception("Id is null");
            }
            Submit submit = db.Submits.Find(id);
            if (submit == null)
            {
                throw new Exception("Submit is null");
            }
            ViewBag.User = HttpContext.User.Identity.Name;
            return View(submit);
        }
        [Route("Delete/{id:int}")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Customer")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            ViewBag.User = HttpContext.User.Identity.Name;
            if (id == null)
            {
                throw new Exception("Id is null");
            }
            Submit submit = db.Submits.Find(id);
            if (submit == null)
            {
                throw new Exception("Submit is null");
            }
            db.Submits.Remove(submit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //// GET: SubmitController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: SubmitController/Edit/5
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
    }
}
