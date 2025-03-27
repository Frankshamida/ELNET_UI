// Models/Account/LoginModel.cs
using System.ComponentModel.DataAnnotations;

namespace RETRA_Hotel_Management_System_UI.Models.Account
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

