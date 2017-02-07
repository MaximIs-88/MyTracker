using MyTracker.Models;
using System.ComponentModel;

namespace MyTracker.ViewModels
{
    public class TasksViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [DisplayName("Author")]
        public ApplicationUser UserName { get; set; }
    }
}
