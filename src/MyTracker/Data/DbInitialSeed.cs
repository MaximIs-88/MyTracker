using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MyTracker.Models;

namespace MyTracker.Data
{
    public class DbInitialSeed
    {
        private readonly ApplicationDbContext _db;

        public DbInitialSeed(IApplicationBuilder app)
        {
            _db = app.ApplicationServices.GetService<ApplicationDbContext>();
        }

        public void Seed()
        {
            if (_db.Tasks.Any()) return;

            _db.Tasks.AddRange(
                new MyTask
                {
                    Name = "First",
                    Description = "First task",
                    Author = new ApplicationUser { UserName = "Max" }
                }, 
                new MyTask
                {
                    Name = "Second",
                    Description = "Second task",
                    Author = new ApplicationUser { UserName = "Max" }
                });
            
            _db.SaveChanges();
        }
    }
}
