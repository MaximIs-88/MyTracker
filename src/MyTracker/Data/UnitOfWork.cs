using MyTracker.Controllers;
using MyTracker.Data.Repositories;
using MyTracker.Data.Repositories.Abstract;

namespace MyTracker.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext, ITasksRepository tasksRepository,
            IIdentityRepository identityRepository)
        {
            _dbContext = dbContext;
            IdentityRepository = identityRepository;
            TasksRepository = tasksRepository;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public ITasksRepository TasksRepository { get; }
        public IIdentityRepository IdentityRepository { get; }
    }
}
