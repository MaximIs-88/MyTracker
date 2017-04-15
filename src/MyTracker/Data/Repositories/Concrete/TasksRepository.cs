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

        public void Delete(MyTask model)
        {
            _dbContext.Tasks.Remove(model);
        }

        public IEnumerable<MyTask> GetAll()
        {
            return _dbContext.Tasks
                .Include(_ => _.Author)
                .AsEnumerable();
        }
    }
}
