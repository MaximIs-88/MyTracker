using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

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

            _db.Tasks.Add(new Models.MyTask
            {
                Name = "First",
                Description = "First task"
            });

            _db.SaveChanges();
        }
    }
}
