using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyTracker.Data.Repositories.Abstract;
using MyTracker.Models;

namespace MyTracker.Data.Repositories.Concrete
{
    public class TasksRepository : ITasksRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TasksRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(MyTask task)
        {
            _dbContext.Tasks.Add(task);
        }

        public void Delete(int id)
        {
            var myTask = _dbContext.Tasks.FirstOrDefault(task => task.Id == id);
            myTask.IsDeleted = true;
        }

        public IEnumerable<MyTask> GetAll()
        {
            return _dbContext.Tasks
                .Where(_ => !_.IsDeleted)
                .Include(_ => _.Author)
                .AsEnumerable();
        }

        public MyTask GetById(int id)
        {
            return _dbContext.Tasks
                .Where(_ => !_.IsDeleted && _.Id == id)
                .Include(_ => _.Author)
                .FirstOrDefault();
        }
    }
}
