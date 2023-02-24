using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mission08_Group07.Models
{
    public class TaskContext : DbContext
    {
            //Constructor
            public TaskContext(DbContextOptions<TaskContext> options) : base(options)
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

            mb.Entity<NewTask>().HasData(
            new NewTask
            {
                TaskID = 1,
                Task = "Clean dishes",
                DueDate = DateTime.Now.AddDays(1),
                QuadrantNumber = 1,
                Completed = false,
                CategoryID = 1
            },
             new NewTask
            {
                TaskID = 2,
                Task = "Go for a run",
                DueDate = DateTime.Now.AddDays(3),
                QuadrantNumber = 2,
                Completed = false,
                CategoryID = 2
            },
            new NewTask
            {
                TaskID = 3,
                Task = "Read a book",
                DueDate = DateTime.Now.AddDays(2),
                QuadrantNumber = 3,
                Completed = false,
                CategoryID = 3
            },
            new NewTask
            {
                TaskID = 4,
                Task = "Call a friend",
                DueDate = DateTime.Now.AddDays(4),
                QuadrantNumber = 4,
                Completed = false,
                CategoryID = 4
            });
        }
    }
}



