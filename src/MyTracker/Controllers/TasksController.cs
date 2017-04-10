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
        private readonly IUnitOfWork _unitOfWork;

        public TasksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var tasks = _unitOfWork.TasksRepository.GetAll();

            var viewModelList = tasks.Select(task => new TasksViewModel
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                UserName = task.Author.UserName
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

            model.Author = _unitOfWork.IdentityManager.GetCurrentUser(HttpContext.User);

            _unitOfWork.TasksRepository.Add(model);
            _unitOfWork.Commit();

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Delete(MyTask task)
        {
            _unitOfWork.TasksRepository.Delete(task);
            _unitOfWork.Commit();

            return RedirectToAction("Index");
        }
    }
}