using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MyTracker.Models;

namespace MyTracker.ViewModels
{
    public class TasksViewModel
    {
        public IEnumerable<MyTask> MyTasks { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
