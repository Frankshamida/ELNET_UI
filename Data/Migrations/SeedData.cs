using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RETRA_Hotel_Management_System_UI.Models;
using System;
using System.Linq;

namespace RETRA_Hotel_Management_System_UI.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Only seed if database is empty
                if (context.Admins.Any() ||
                    context.FrontDesks.Any() ||
                    context.HousekeepingStaff.Any() ||
                    context.Guests.Any())
                {
                    return;
                }

                // Seed initial data
                SeedAdmins(context);
                SeedFrontDeskStaff(context);
                SeedHousekeepingStaff(context);
                SeedGuests(context);

                context.SaveChanges();
            }
        }

        private static void SeedAdmins(ApplicationDbContext context)
        {
            context.Admins.AddRange(
                new Admin
                {
                    Username = "admin",
                    Password = "admin123",
                    Email = "admin@retrahotel.com",
                    FullName = "System Administrator"
                }
            );
        }

        private static void SeedFrontDeskStaff(ApplicationDbContext context)
        {
            context.FrontDesks.AddRange(
                new FrontDesk
                {
                    Username = "frontdesk1",
                    Password = "fd123",
                    Email = "fd1@retrahotel.com",
                    FullName = "John Smith",
                    Shift = "Morning",
                    HireDate = DateTime.Now.AddMonths(-6)
                },
                new FrontDesk
                {
                    Username = "frontdesk2",
                    Password = "fd123",
                    Email = "fd2@retrahotel.com",
                    FullName = "Sarah Johnson",
                    Shift = "Evening",
                    HireDate = DateTime.Now.AddMonths(-3)
                }
            );
        }

        private static void SeedHousekeepingStaff(ApplicationDbContext context)
        {
            context.HousekeepingStaff.AddRange(
                new Housekeeping
                {
                    Username = "housekeeper1",
                    Password = "hk123",
                    Email = "hk1@retrahotel.com",
                    FullName = "Maria Garcia",
                    Section = "Floors",
                    HireDate = DateTime.Now.AddMonths(-8)
                },
                new Housekeeping
                {
                    Username = "housekeeper2",
                    Password = "hk123",
                    Email = "hk2@retrahotel.com",
                    FullName = "James Wilson",
                    Section = "Public Areas",
                    HireDate = DateTime.Now.AddMonths(-4)
                }
            );
        }

        private static void SeedGuests(ApplicationDbContext context)
        {
            context.Guests.AddRange(
                new Guest
                {
                    Username = "guest1",
                    Password = "guest123",
                    Email = "guest1@example.com",
                    FullName = "Michael Brown",
                    PhoneNumber = "555-123-4567",
                    Address = "123 Main St, Anytown, USA"
                },
                new Guest
                {
                    Username = "guest2",
                    Password = "guest123",
                    Email = "guest2@example.com",
                    FullName = "Emily Davis",
                    PhoneNumber = "555-987-6543",
                    Address = "456 Oak Ave, Somewhere, USA"
                }
            );
        }

        internal static async Task InitializeAsync(IServiceProvider services)
        {
            throw new NotImplementedException();
        }
    }
}