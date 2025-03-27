using System.ComponentModel.DataAnnotations;

// Use ONLY ONE of these namespace declarations - choose one and be consistent
namespace RETRA_Hotel_Management_System_UI.Models // Recommended
// OR
// namespace RETRA_Hotel_Management_System_UI.Models.Account
{
    public class FrontDesk
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
        public string FullName { get; set; }

        public string Shift { get; set; }
        public DateTime HireDate { get; set; }
    }
}