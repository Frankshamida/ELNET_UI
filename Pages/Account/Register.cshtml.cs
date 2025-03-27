using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RETRA_Hotel_Management_System_UI.Data;
using RETRA_Hotel_Management_System_UI.Models; // Or .Models.Account if you choose Option A

namespace RETRA_Hotel_Management_System_UI.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public RegisterInputModel Input { get; set; }

        public RegisterModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (UsernameExists(Input.Username))
            {
                ModelState.AddModelError(string.Empty, "Username already exists.");
                return Page();
            }

            if (EmailExists(Input.Email))
            {
                ModelState.AddModelError(string.Empty, "Email already exists.");
                return Page();
            }

            switch (Input.Role)
            {
                case "FrontDesk":
                    var frontDesk = new Models.FrontDesk
                    {
                        Username = Input.Username,
                        Password = Input.Password,
                        Email = Input.Email,
                        FullName = Input.FullName,
                        Shift = "Morning",
                        HireDate = DateTime.Now
                    };
                    _context.FrontDesks.Add(frontDesk);
                    break;

                case "Housekeeping":
                    var housekeeping = new Models.Housekeeping
                    {
                        Username = Input.Username,
                        Password = Input.Password,
                        Email = Input.Email,
                        FullName = Input.FullName,
                        Section = "Floors",
                        HireDate = DateTime.Now
                    };
                    _context.HousekeepingStaff.Add(housekeeping);
                    break;

                case "Guest":
                    var guest = new Models.Guest
                    {
                        Username = Input.Username,
                        Password = Input.Password,
                        Email = Input.Email,
                        FullName = Input.FullName,
                        PhoneNumber = Input.PhoneNumber,
                        Address = Input.Address
                    };
                    _context.Guests.Add(guest);
                    break;

                default:
                    ModelState.AddModelError(string.Empty, "Invalid role selected.");
                    return Page();
            }

            _context.SaveChanges();
            return RedirectToPage("/Account/Login");
        }

        private bool UsernameExists(string username)
        {
            return _context.Admins.Any(a => a.Username == username) ||
                   _context.FrontDesks.Any(f => f.Username == username) ||
                   _context.HousekeepingStaff.Any(h => h.Username == username) ||
                   _context.Guests.Any(g => g.Username == username);
        }

        private bool EmailExists(string email)
        {
            return _context.Admins.Any(a => a.Email == email) ||
                   _context.FrontDesks.Any(f => f.Email == email) ||
                   _context.HousekeepingStaff.Any(h => h.Email == email) ||
                   _context.Guests.Any(g => g.Email == email);
        }
    }

    public class RegisterInputModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Role { get; set; }

        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}