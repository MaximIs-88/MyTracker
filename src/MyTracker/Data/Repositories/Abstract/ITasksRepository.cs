using System.Collections.Generic;
using MyTracker.Models;

namespace MyTracker.Data.Repositories.Abstract
{
    public interface ITasksRepository
    {
        void Add(MyTask task);

        void Delete(MyTask model);

        IEnumerable<MyTask> GetAll();
    }
}