using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyTracker.Models;

namespace MyTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<MyTask> Tasks { get; set; } 

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
                
        protected override void OnModelCreating(ModelBuilder builder)
        {
            /*var propertyBuilder = builder.Entity<MyTask>().Property(_ => _.Name)
                .HasAnnotation("Display", "test2")
                .IsRequired();*/

            base.OnModelCreating(builder);

          

        }
    }
}
