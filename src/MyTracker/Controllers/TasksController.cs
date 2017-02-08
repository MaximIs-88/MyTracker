using Microsoft.AspNetCore.Mvc;
using MyTracker.Data;
using MyTracker.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using MyTracker.ViewModels;

namespace MyTracker.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IIdentityManager _identityManager;

        public TasksController(ApplicationDbContext dbContext,
            IIdentityManager identityManager)
        {
            _dbContext = dbContext;
            _identityManager = identityManager;
        }

        public IActionResult Index()
        {
            IEnumerable<MyTask> model = _dbContext.Tasks;

            var userId = _identityManager.GetCurrentUser(HttpContext.User).Id;

            var viewModelList = model.Select(task => new TasksViewModel
            {
                Name = task.Name,
                Description = task.Description,
                UserName = _dbContext.Users.Single(u => u.Id == userId.ToString())
            }).ToList();

            return View(viewModelList);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
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