using JobOpenings.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using Microsoft.AspNetCore.Authorization;
using JobOpenings.ViewModels;

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
            ViewBag.User = HttpContext.User.Identity.Name;
            return View(vacancy);
        }

        [Route("Create")]
        [Authorize(Roles = "Admin, Customer")]
        [HttpGet]
        public ActionResult Create()
        {
            //SelectList categories = new SelectList(db.Categories, "Id", "Name");
            //this.ViewBag.CategoryList = categories;
            ViewBag.CategoryList = db.Categories.ToList();
            ViewBag.User = HttpContext.User.Identity.Name;
            return View();
        }

        [Route("Create")]
        [HttpPost]
        [Authorize(Roles = "Admin, Customer")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name, PublicationDate, Salary, Company, Category, Schedule, Experience")] Vacancy model)
        {
            ViewBag.CategoryList = db.Categories.ToList();
            try
            {
                if (ModelState.IsValid)
                {
                    model.User= db.Users.FirstOrDefault(p => p.Email == HttpContext.User.Identity.Name);
                    model.PublicationDate = DateTime.Now;
                    Company company = new Company
                    {
                        Name = model.Company.Name,
                        Location = model.Company.Location,
                    };
                    Company company1 = db.Companies.Where(p => p.Name == company.Name && p.Location == company.Location).FirstOrDefault();
                    if (company1 != null)
                    {
                        int id = company1.Id;
                        model.Company = db.Companies.Find(id);
                    }
                    model.Category = db.Categories.FirstOrDefault(p=>p.Name==model.Category.Name);
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
        [Authorize(Roles = "Admin, Customer")]
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
            ViewBag.User = HttpContext.User.Identity.Name;
            return View(vacancy);
        }
        [Route("Delete/{id:int}")]
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin, Customer")]
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
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("Submit/{id:int}")]
        [Authorize(Roles = "Admin, Customer")]
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
            ViewBag.User = HttpContext.User.Identity.Name;
            return View(submit);
        }
        [Route("Submit/{id:int}")]
        [HttpPost]
        [Authorize(Roles = "Admin, Customer")]
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
                    model.User = db.Users.FirstOrDefault(p => p.Email == HttpContext.User.Identity.Name);
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
        [Authorize(Roles = "Admin, Customer")]
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
                Vacancy = vacancy,
            };
            ViewBag.User = HttpContext.User.Identity.Name;
            return View(fav);
        }
        [Route("Favourite/{id:int}")]
        [Authorize(Roles = "Admin, Customer")]
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
                    model.User = db.Users.FirstOrDefault(p=>p.Email==HttpContext.User.Identity.Name);
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
        [Authorize(Roles = "Admin, Customer")]
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
            ViewBag.User = HttpContext.User.Identity.Name;
            return View(vacancy.Favourites.FirstOrDefault(p=>p.User.Email==HttpContext.User.Identity.Name));
        }
        [Route("UnFavourite/{id:int}")]
        [Authorize(Roles = "Admin, Customer")]
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("UnFavourite")]
        public ActionResult UnFavouriteConfirmed(int? id)
        {
            if (id == null)
            {
                throw new Exception("Id is null");
            }
            Favourite fav = db.Vacancies.Find(id).Favourites.FirstOrDefault(p => p.User.Email == HttpContext.User.Identity.Name);
            if (fav == null)
            {
                throw new Exception("Favourite is null");
            }
            db.Favourites.Remove(fav);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin, Customer")]
        [Route("Edit/{id:int}")]
        [HttpGet]
        public ActionResult Edit(int? id)
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
            SelectList categories = new SelectList(db.Categories, "Id", "Name");
            this.ViewBag.CategoryList = categories;
            ViewBag.User = HttpContext.User.Identity.Name;
            return View(vacancy);
        }

        [Authorize(Roles = "Admin, Customer")]
        [Route("Edit/{id:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,Name, PublicationDate, Salary, Company, Category, Schedule, Experience,Favourite,Submits")] Vacancy model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.User= db.Users.FirstOrDefault(p => p.Email == HttpContext.User.Identity.Name);
                    model.PublicationDate = DateTime.Now;
                    Company company = new Company
                    {
                        Name = model.Company.Name,
                        Location = model.Company.Location,
                    };
                    Company company1 = db.Companies.Where(p => p.Name == company.Name && p.Location == company.Location).FirstOrDefault();
                    if (company1 != null)
                    {
                        int id = company1.Id;
                        model.Company = db.Companies.Find(id);
                    }
                    else
                    {
                        db.Companies.Add(company);
                        db.SaveChanges();
                        model.Company = company;
                    }
                    model.Category = db.Categories.Find(model.Category.Id);
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

        public async Task<IActionResult> Index(string sortOrder,string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CompanySortParm"] = sortOrder == "Company" ? "company_desc" : "Company";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["LocationSortParm"] = sortOrder == "Location" ? "location_desc" : "Location";
            ViewData["SalarySortParm"] = sortOrder == "Salary" ? "salary_desc" : "Salary";
            ViewData["CurrentFilter"] = searchString;
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            var vacancies = from s in db.Vacancies
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                vacancies = vacancies.Where(s => s.Name.Contains(searchString)
                                       || s.Company.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    vacancies = vacancies.OrderByDescending(s => s.Name);
                    break;
                case "Company":
                    vacancies = vacancies.OrderBy(s => s.Company.Name);
                    break;
                case "company_desc":
                    vacancies = vacancies.OrderByDescending(s => s.Company.Name);
                    break;
                case "Date":
                    vacancies = vacancies.OrderBy(s => s.PublicationDate);
                    break;
                case "date_desc":
                    vacancies = vacancies.OrderByDescending(s => s.PublicationDate);
                    break;
                    case "Location":
                    vacancies = vacancies.OrderBy(s => s.Company.Location);
                    break;
                case "location_desc":
                    vacancies = vacancies.OrderByDescending(s => s.Company.Location);
                    break;

                case "Salary":
                    vacancies = vacancies.OrderBy(s => s.Salary);
                    break;
                case "selary_desc":
                    vacancies = vacancies.OrderByDescending(s => s.Salary);
                    break;
                default:
                    vacancies = vacancies.OrderBy(s => s.Name);
                    break;
            }
            ViewBag.Amount = vacancies.ToList().Count;
            int pageSize = 5;
            return View(await PaginatedList<Vacancy>.CreateAsync(vacancies, pageNumber ?? 1, pageSize));
        }
        

    }
}
