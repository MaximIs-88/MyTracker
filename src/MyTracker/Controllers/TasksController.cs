using Microsoft.AspNetCore.Mvc;
using MyTracker.Data;
using MyTracker.Models;
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
            var viewModelList = _dbContext.Tasks.Select(task => new TasksViewModel
            {
                Name = task.Name,
                Description = task.Description,
                UserName = task.Author.UserName 
            });
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
           
            model.Author = _identityManager.GetCurrentUser(HttpContext.User);
            
            _dbContext.Tasks.Add(model);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

       /* [Authorize]
        [HttpPost]
        public IActionResult Delete(MyTask model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            model.Author = _identityManager.GetCurrentUser(HttpContext.User);

            _dbContext.Tasks.Add(model);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }*/
    }
}