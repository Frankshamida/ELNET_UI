// Models/Account/User.cs
using System.ComponentModel.DataAnnotations;

namespace RETRA_Hotel_Management_System_UI.Models.Account
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; } // "Admin", "Housekeeping", "FrontDesk", "Guest"
    }
}