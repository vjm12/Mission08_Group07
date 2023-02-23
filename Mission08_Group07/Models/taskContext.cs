using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mission08_Group07.Models
{
    public class taskContext : DbContext
    {
            //Constructor
            public taskContext(DbContextOptions<taskContext> options) : base(options)
            {
                // leave blank for now
            }

            public DbSet<NewTask> Responses { get; set; }
            public DbSet<Category> Categories { get; set; }

            // Seed Data

            protected override void OnModelCreating(ModelBuilder mb)
            {
                mb.Entity<Category>().HasData(
                        new Category { CategoryID = 1, CategoryName = "Home" },
                        new Category { CategoryID = 2, CategoryName = "School" },
                        new Category { CategoryID = 3, CategoryName = "Work" },
                        new Category { CategoryID = 4, CategoryName = "Church" }
                    );               
            }
        }
    }



