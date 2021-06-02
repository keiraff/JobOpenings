using JobOpenings.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JobOpenings.Controllers
{
    [Route("Category")]
    public class CategoryController : Controller
    {
        JobOpeningsContext db;

        public CategoryController(JobOpeningsContext context)
        {
            db = context;
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            ViewBag.User = HttpContext.User.Identity.Name;
            List<Category> categories = db.Categories.ToList();
            ViewBag.Amount = categories.Count;
            return View(categories);
        }

        [Route("Create")]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.User = HttpContext.User.Identity.Name;
            return View();
        }

        [Route("Create")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name")] Category model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Category category = db.Categories.FirstOrDefault(p => p.Name == model.Name);
                    if (category == null)
                    {
                        db.Categories.Add(model);
                    }
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(model);
        }

        [HttpGet]
        [Route("Delete/{id:int}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new Exception("Id is null");
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                throw new Exception("Category is null");
            }
            ViewBag.User = HttpContext.User.Identity.Name;
            return View(category);
        }
        [Route("Delete/{id:int}")]
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                throw new Exception("Id is null");
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                throw new Exception("Category is null");
            }
            db.Categories.Remove(category);
            ViewBag.User = HttpContext.User.Identity.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [Route("Edit/{id:int}")]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new Exception("Id is null");
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                throw new Exception("Category is null");
            }
            ViewBag.User = HttpContext.User.Identity.Name;
            return View(category);
            
        }

        [Authorize(Roles = "Admin")]
        [Route("Edit/{id:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,Name, Vacancies")] Category model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(model);
        }
    }
}
