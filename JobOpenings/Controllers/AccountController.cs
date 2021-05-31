using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using JobOpenings.ViewModels;
using JobOpenings.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace JobOpenings.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        public ClaimsPrincipal claimsPrincipal;
        private JobOpeningsContext db;
        public AccountController(JobOpeningsContext context)
        {
            db = context;
        }
        [Route("Register")]
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.User = HttpContext.User.Identity.Name;
            return View();
        }
        [HttpPost]
        [Route("Register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    user = new User { Name=model.Name, Email = model.Email, Password = model.Password };
                    Role userRole = await db.Roles.FirstOrDefaultAsync(r => r.Name == "Customer");
                    if (userRole != null)
                        user.Role = userRole;
                    db.Users.Add(user);
                    await db.SaveChangesAsync();
                    await Authenticate(user); 
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            ViewBag.User = HttpContext.User.Identity.Name;
            return View();
        }
        [HttpPost]
        [Route("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(user); 

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Login or password are incorrect.");
            }
            return View(model);
        }
        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            claimsPrincipal = new ClaimsPrincipal(id);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
        }
        [HttpGet]
        [Authorize(Roles = "Admin, Customer")]
        [Route("Logout")]
        public IActionResult Logout()
        {
            ViewBag.User = HttpContext.User.Identity.Name;
            return View();
        }
        [HttpPost, ActionName("Logout")]
        [Route("Logout")]
        [Authorize(Roles = "Admin, Customer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogoutConfirmed()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }

}

