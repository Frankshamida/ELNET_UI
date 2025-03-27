using Microsoft.EntityFrameworkCore;
using RETRA_Hotel_Management_System_UI.Models;
using RETRA_Hotel_Management_System_UI.Models.Account; // Or .Models.Account if you chose Option A

namespace RETRA_Hotel_Management_System_UI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Models.FrontDesk> FrontDesks { get; set; }
        public DbSet<Housekeeping> HousekeepingStaff { get; set; }
        public DbSet<Guest> Guests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed initial admin data
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 1,
                    Username = "admin",
                    Password = "admin123",
                    Email = "admin@retrahotel.com",
                    FullName = "System Administrator"
                }
            );
        }
    }
}