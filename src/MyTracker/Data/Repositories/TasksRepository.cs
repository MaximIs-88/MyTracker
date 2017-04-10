using MyTracker.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MyTracker.Data.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TasksRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<MyTask> GetAll()
        {
            return _dbContext.Tasks
                .Include(_ => _.Author)
                .AsEnumerable();
        }
    }

    public interface ITasksRepository
    {
        IEnumerable<MyTask> GetAll();
    }
}
