using System.Collections.Generic;
using MyTracker.Models;

namespace MyTracker.Data.Repositories.Abstract
{
    public interface ITasksRepository
    {
        void Add(MyTask task);

        void Delete(int id);

        IEnumerable<MyTask> GetAll();
    }
}