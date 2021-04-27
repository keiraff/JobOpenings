using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOpenings.Models
{
    [Keyless]
    public class Category
    {
        public int IdCategory { get; set; }
        public string CategoryName { get; set; }

    }
}
