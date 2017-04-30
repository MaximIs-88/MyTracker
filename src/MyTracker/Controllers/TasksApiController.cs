using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTracker.Data;

namespace MyTracker.Controllers
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string TaskName { get; set; }

    }


    [Produces("application/json")]
    [Route("api/taskUpdate")]
    public class TasksApiController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public TasksApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Update(TaskDto taskDto)
        {
            var task = _unitOfWork.TasksRepository.GetById(taskDto.Id);

            if (task == null)
            {
                return BadRequest("Task didn't exist.");
            }

            task.Name = taskDto.TaskName;
            _unitOfWork.Commit();
            return Ok();
        }
    }
}