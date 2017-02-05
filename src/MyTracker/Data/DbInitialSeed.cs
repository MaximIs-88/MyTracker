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
                    Description = "First task"
                }, 
                new MyTask
                {
                    Name = "Second",
                    Description = "Second task"
                });

            _db.SaveChanges();
        }
    }
}
