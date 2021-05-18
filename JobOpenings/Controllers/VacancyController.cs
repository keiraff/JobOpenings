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
            //Vacancy model = new Vacancy
            //{
            //    CategoryList = new SelectList(db.Categories, "ID", "Name")
            //}
            SelectList categories=new SelectList(db.Categories, "Id", "Name");
            this.ViewBag.CategoryList = categories;
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
        [HttpGet]
        [Route("Delete/{id:int}")]
        public ActionResult Delete(int? id)
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
        [Route("Delete/{id:int}")]
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
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
            db.Remove(vacancy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("{Submit}/{id:int}")]
        public IActionResult Submit(int? id)
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
            Submit submit = new Submit
            {
                Vacancy = vacancy,
            };
            return View(submit);
        }
        [Route("Submit/{id:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Submit([Bind("Name,Surname,MobilePhone,Email,Vacancy")] Submit model/*IFormCollection collection*/)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Vacancy vacancy = db.Vacancies.Find(model.Vacancy.Id);
                    model.Vacancy = vacancy;
                    model.PublicationDate = DateTime.Now;
                    db.Submits.Add(model);
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
