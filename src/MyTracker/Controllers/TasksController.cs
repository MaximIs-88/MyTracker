using Microsoft.AspNetCore.Mvc;
using MyTracker.Data;
using MyTracker.Models;
using System.Collections.Generic;
using System.Linq;
using MyTracker.ViewModels;

namespace MyTracker.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public TasksController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<MyTask> model = _dbContext.Tasks;

                        var viewModelList = model.Select(task => new TasksViewModel
            {
                Name = task.Name,
                Description = task.Description,
                UserName = _dbContext.Users.Single(u => u.Id == "a0214baf-c96f-4731-8f02-b9ed102fab0e")
            }).ToList();

            return View(viewModelList);
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