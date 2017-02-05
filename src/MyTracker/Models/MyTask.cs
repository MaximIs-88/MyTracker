using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTracker.Models
{
    public class MyTask
    {
        public int Id { get; set; }

     /*   [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(3)]*/
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
