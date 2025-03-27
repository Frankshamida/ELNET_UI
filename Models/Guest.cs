using System.ComponentModel.DataAnnotations;

namespace RETRA_Hotel_Management_System_UI.Models
{
    public class Guest
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

        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }
}