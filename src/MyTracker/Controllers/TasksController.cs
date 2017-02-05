using Microsoft.AspNetCore.Mvc;
using MyTracker.Data;
using MyTracker.Models;
using MyTracker.ViewModels;
using System.Collections.Generic;

namespace MyTracker.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public TasksController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(IEnumerable<MyTask> model)
        {
            model = _dbContext.Tasks;

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MyTask model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _dbContext.Tasks.Add(model);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}