using JobTracker.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobTracker.Persistence.DataContexts
{
    public class JobTrackerDbContext : DbContext
    {
        public JobTrackerDbContext(DbContextOptions<JobTrackerDbContext> options) : base(options)
        {
            
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(options =>
            {

            });
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
