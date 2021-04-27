﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOpenings.Models
{
    public class JobOpeningsContext:DbContext
    {
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Vacancy> Favourites { get; set; }
        public DbSet<Category> Categories { get; set; }

        public JobOpeningsContext(DbContextOptions<JobOpeningsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}