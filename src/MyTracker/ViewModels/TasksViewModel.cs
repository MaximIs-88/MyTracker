using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTracker.Models;

namespace MyTracker.ViewModels
{
    public class TasksViewModel
    {
        public IEnumerable<MyTask> MyTasks { get; set; }
    }
}
