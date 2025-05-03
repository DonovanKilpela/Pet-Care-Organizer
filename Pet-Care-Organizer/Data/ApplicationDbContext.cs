using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pet_Care_Organizer.Models;

namespace Pet_Care_Organizer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add your DbSet for Supplies
        public DbSet<Supplies> Supplies { get; set; }
    }
}