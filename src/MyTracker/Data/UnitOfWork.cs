using MyTracker.Data.Repositories;

namespace MyTracker.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ApplicationDbContext context)
        {
            TasksRepository = new TasksRepository(context);
        }

        public ITasksRepository TasksRepository { get; set; }
    }

    public interface IUnitOfWork
    {
        ITasksRepository TasksRepository { get; }
    }
}
