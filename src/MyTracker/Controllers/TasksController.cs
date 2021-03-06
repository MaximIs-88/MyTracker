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
        private readonly IMapperConfig _mapper;
       
        public TasksController(IUnitOfWork unitOfWork, IMapperConfig mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var tasks = _unitOfWork.TasksRepository.GetAll();

            var viewModelList = tasks.Select(_mapper.Map<MyTask, TasksViewModel>);

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

            model.Author = _unitOfWork.IdentityRepository.GetCurrentUser(HttpContext.User);

            _unitOfWork.TasksRepository.Add(model);
            _unitOfWork.Commit();

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _unitOfWork.TasksRepository.Delete(id);
            _unitOfWork.Commit();

            return RedirectToAction(nameof(Index));
        }
    }
}