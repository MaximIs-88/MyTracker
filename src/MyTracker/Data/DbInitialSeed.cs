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

            var applicationUser = new ApplicationUser { UserName = "Max" };
            _db.Tasks.AddRange(
                new MyTask
                {
                    Name = "First",
                    Description = "First task",
                    Author = applicationUser
                }, 
                new MyTask
                {
                    Name = "Second",
                    Description = "Second task",
                    Author = applicationUser
                });
            
            _db.SaveChanges();
        }
    }
}
