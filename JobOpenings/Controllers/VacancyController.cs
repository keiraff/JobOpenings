﻿using JobOpenings.Models;
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

        public VacancyController(JobOpeningsContext context)
        {
            db = context;
        }

        //[Route("{Vacancy}")]
        public IActionResult Index()
        {
            return View(db.Vacancies.ToList());
        }

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

        [Route("Create")]
        [HttpGet]
        public ActionResult Create()
        {
            SelectList categories=new SelectList(db.Categories, "Id", "Name");
            this.ViewBag.CategoryList = categories;
            return View();
        }

        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name, PublicationDate, Salary, Company, Category, Schedule, Experience")] Vacancy model)
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
            db.Vacancies.Remove(vacancy);
            //db.Submits.RemoveAll(p => p.Vacancy.Id == vacancy.Id).ToList().RemoveAll();
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("Submit/{id:int}")]
        public ActionResult Submit(int? id)
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
        public ActionResult Submit([Bind("Name,Surname,MobilePhone,Email,Vacancy")] Submit model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Vacancy vacancy = db.Vacancies.Find(model.Vacancy.Id);
                    model.Vacancy = vacancy;
                    model.VacancyId = vacancy.Id;
                    model.PublicationDate = DateTime.Now;
                    db.Submits.Add(model);
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
        [Route("Favourite/{id:int}")]
        public ActionResult Favourite(int? id)
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
            Favourite fav = new Favourite
            {
                VacancyId = vacancy.Id,
                Vacancy = vacancy,
            };
            return View(fav);
        }
        [Route("Favourite/{id:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Favourite([Bind("VacancyId,Vacancy")] Favourite model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Vacancy vacancy = db.Vacancies.Find(model.Vacancy.Id);
                    model.Vacancy = vacancy;
                    model.VacancyId = vacancy.Id;
                    model.DateOfAdding = DateTime.Now;
                    db.Favourites.Add(model);
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
        [Route("UnFavourite/{id:int}")]
        public ActionResult UnFavourite(int? id)
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
            return View(vacancy.Favourite);
        }
        [Route("UnFavourite/{id:int}")]
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("UnFavourite")]
        public ActionResult UnFavouriteConfirmed(int? id)
        {
            if (id == null)
            {
                throw new Exception("Id is null");
            }
            Favourite fav = db.Favourites.Find(id);
            if (fav == null)
            {
                throw new Exception("Favourite is null");
            }
            db.Favourites.Remove(fav);
            db.SaveChanges();
            return RedirectToAction("Index");
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
