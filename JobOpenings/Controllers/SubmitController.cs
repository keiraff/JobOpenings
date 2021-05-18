using JobOpenings.Models;
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
        public ActionResult Index()
        {
            return View(db.Submits.ToList());
        }

        // GET: SubmitController/Details/5
        [HttpGet]
        [Route("{id:int}")]
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
            return View(submit);
        }
        [HttpGet]
        [Route("Delete/{id:int}")]
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
            return View(submit);
        }
        [Route("Delete/{id:int}")]
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
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
            db.Submits.Remove(submit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //// GET: SubmitController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: SubmitController/Create
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

        //// GET: SubmitController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: SubmitController/Delete/5
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
