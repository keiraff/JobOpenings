using JobOpenings.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JobOpenings.Controllers
{
      [Route("{Vacancy}")]
    public class VacancyController : Controller
    {
        JobOpeningsContext db;
        //private JobOpeningsContext db = new JobOpeningsContext();

        public VacancyController(JobOpeningsContext context)
        {
            db = context;
        }

        // GET: vacancies
        //[Route("{Vacancy}")]
        public IActionResult Index()
        {
            return View(db.Vacancies.ToList());
        }

        // GET: vacancies/info/5
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


        //  GET: VacanciesController/Create
        [Route("Create")]
        [HttpGet]
        public ActionResult Create()
        {
            SelectList categories=new SelectList(db.Categories, "Id", "Name");
            this.ViewBag.Categories = categories;
            return View();
        }

        // POST: VacanciesController/Create
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name, PublicationDate, Salary, Company, Category, Schedule, Experience")] Vacancy model/*IFormCollection collection*/)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.PublicationDate = DateTime.Now;
                    Company company = new Company
                        {
                        Name = model.Company.Name,
                        Location=model.Company.Location,
                    };
                    if (db.Companies.Where(p => p.Name == company.Name && p.Location == company.Location).FirstOrDefault() == null)
                    {
                        db.Companies.Add(company);
                    }
                    model.Category = db.Categories.Find(model.Category.Id);
                    model.Company = company;
                    db.Vacancies.Add(model);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DataException)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(model);
        }

            //// GET: VacanciesController/Edit/5
            //public ActionResult Edit(int id)
            //{
            //    return View();
            //}

            //// POST: VacanciesController/Edit/5
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

            //// GET: VacanciesController/Delete/5
            //public ActionResult Delete(int id)
            //{
            //    return View();
            //}

            //// POST: VacanciesController/Delete/5
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
