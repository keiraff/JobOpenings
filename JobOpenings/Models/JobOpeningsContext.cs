using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOpenings.Models
{
    public class JobOpeningsContext : DbContext
    {
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Submit> Submits { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public JobOpeningsContext(DbContextOptions<JobOpeningsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    string adminRoleName = "admin";
        //    string userRoleName = "user";

        //    string adminEmail = "admin@mail.ru";
        //    string adminPassword = "123456";

        //    // добавляем роли
        //    Role adminRole = new Role { Id = 1, Name = adminRoleName };
        //    Role userRole = new Role { Id = 2, Name = userRoleName };
        //    User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };

        //    modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
        //    modelBuilder.Entity<User>().HasData(new User[] { adminUser });
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
