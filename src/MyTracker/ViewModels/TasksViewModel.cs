using MyTracker.Models;
using System.ComponentModel.DataAnnotations;

namespace MyTracker.ViewModels
{
    public class TasksViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Author")]
        public string UserName { get; set; }
    }
}
