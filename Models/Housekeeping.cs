using System.ComponentModel.DataAnnotations;

namespace RETRA_Hotel_Management_System_UI.Models
{
    public class Housekeeping
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

        public string Section { get; set; }
        public DateTime HireDate { get; set; }
    }
}