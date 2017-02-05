using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTracker.Data;

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
            var model = new ViewModels.TasksViewModel {MyTasks = _dbContext.Tasks};


            return View(model);
        }
    }
}