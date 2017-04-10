using MyTracker.Controllers;
using MyTracker.Data.Repositories;

namespace MyTracker.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext, ITasksRepository tasksRepository,
            IIdentityManager identityManager)
        {
            _dbContext = dbContext;
            IdentityManager = identityManager;
            TasksRepository = tasksRepository;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public ITasksRepository TasksRepository { get; }
        public IIdentityManager IdentityManager { get; }
    }

    public interface IUnitOfWork
    {
        void Commit();

        ITasksRepository TasksRepository { get; }

        IIdentityManager IdentityManager { get; }
    }
}
