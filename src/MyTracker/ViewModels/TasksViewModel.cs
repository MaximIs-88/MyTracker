using MyTracker.Models;
using System.ComponentModel.DataAnnotations;

namespace MyTracker.ViewModels
{
    public class TasksViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Author")]
        public ApplicationUser UserName { get; set; }
    }
}
