using Microsoft.EntityFrameworkCore;
using HotelProjectAPI.Models;

namespace HotelProjectAPI.Data 
{
    public class Context : DbContext 
    {
        // DbSet properties for interacting with database tables
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }

        // Constructor accepting DbContextOptions for configuration
        public Context(DbContextOptions<Context> options) : base(options) {
        }

        // Method overridden to configure DbContext options
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=GroupProject;Trusted_connection=True;Trust Server Certificate=Yes");
        }

        // DbContextOptionsBuilder instance
        DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();

        // Parameterless constructor for configuration if options not provided
        public Context() 
        {
            // Check if options are not configured and configure DbContext for SQL Server
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=GroupProject;Trusted_connection=True;Trust Server Certificate=Yes");
            }
        }
    }   
}
