using System.ComponentModel.DataAnnotations;

namespace MyTracker.Models
{
    public class MyTask
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        public string Description { get; set; }

        public ApplicationUser Author { get; set; }

    }
}
