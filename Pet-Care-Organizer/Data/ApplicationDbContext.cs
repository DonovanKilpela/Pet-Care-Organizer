using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pet_Care_Organizer.Models;

namespace Pet_Care_Organizer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Supplies> Supplies { get; set; }
        public DbSet<Appointments> Appointments { get; set; }
        public DbSet<DailyTasks> DailyTasks { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial Status data
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = "NEW", Name = "Not Started" },
                new Status { StatusId = "INP", Name = "In Progress" },
                new Status { StatusId = "COM", Name = "Completed" }
            );
        }
    }
}