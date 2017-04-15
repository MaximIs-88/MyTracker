using MyTracker.Data.Repositories;
using MyTracker.Data.Repositories.Abstract;

namespace MyTracker.Data
{
    public interface IUnitOfWork
    {
        void Commit();

        ITasksRepository TasksRepository { get; }

        IIdentityRepository IdentityRepository { get; }
    }
}