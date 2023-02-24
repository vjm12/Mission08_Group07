using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission08_Group07.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mission08_Group07.Controllers
{
    public class HomeController : Controller
    {
        private TaskContext daContext { get;  set; }
        
        public HomeController(TaskContext tc)
        {
            daContext = tc;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Quadrant()
        {
            var Task = daContext.Responses.Where(x => x.Completed != true).Include(x => x.Category).OrderBy(x => x.DueDate).ToList();
            return View(Task);
        }

        [HttpGet]
        public IActionResult AddEditTask()
        {
            ViewBag.Categories = daContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddEditTask(NewTask nt)
        {
            if (ModelState.IsValid)
            {
                daContext.Add(nt);
                daContext.SaveChanges();
                return View("Confirmation", nt);
            }
            else
            {
                ViewBag.Categories = daContext.Categories.ToList();

                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int taskID)
            {
                ViewBag.Categories = daContext.Categories.ToList();

                var taskView = daContext.Responses.Single(x => x.TaskID == taskID);

                return View("AddEditTask", taskView);
            }

        [HttpPost]
        public IActionResult Edit(NewTask blah)
            {
                daContext.Update(blah);
                daContext.SaveChanges();
                // redirects 
                return RedirectToAction("Quadrant");
            }

            [HttpGet]
            public IActionResult Delete(int taskID)
            {
                var task = daContext.Responses.Single(x => x.TaskID == taskID);

                return View(task);
            }

            [HttpPost]
            public IActionResult Delete(NewTask nt)
            {
                daContext.Responses.Remove(nt);
                daContext.SaveChanges();

                return RedirectToAction("Quadrant");
            }

        }
    
}
