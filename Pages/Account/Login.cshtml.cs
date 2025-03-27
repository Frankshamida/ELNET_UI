// Pages/Account/Login.cshtml.cs
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RETRA_Hotel_Management_System_UI.Data;
using RETRA_Hotel_Management_System_UI.Models;

namespace RETRA_Hotel_Management_System_UI.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public LoginInputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public LoginModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(string returnUrl = null)
        {
            if (HttpContext.Session.GetString("Username") != null)
            {
                return RedirectToDashboard(HttpContext.Session.GetString("Role"));
            }

            ReturnUrl = returnUrl;
            return Page();
        }

        public IActionResult OnPost(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Check Admin table first
            var admin = _context.Admins.FirstOrDefault(a => a.Username == Input.Username && a.Password == Input.Password);
            if (admin != null)
            {
                SetSessionAndRedirect(admin.Username, "Admin", admin.Id);
                return RedirectToDashboard("Admin");
            }

            // Check FrontDesk table
            var frontDesk = _context.FrontDesks.FirstOrDefault(f => f.Username == Input.Username && f.Password == Input.Password);
            if (frontDesk != null)
            {
                SetSessionAndRedirect(frontDesk.Username, "FrontDesk", frontDesk.Id);
                return RedirectToDashboard("FrontDesk");
            }

            // Check Housekeeping table
            var housekeeping = _context.HousekeepingStaff.FirstOrDefault(h => h.Username == Input.Username && h.Password == Input.Password);
            if (housekeeping != null)
            {
                SetSessionAndRedirect(housekeeping.Username, "Housekeeping", housekeeping.Id);
                return RedirectToDashboard("Housekeeping");
            }

            // Check Guest table
            var guest = _context.Guests.FirstOrDefault(g => g.Username == Input.Username && g.Password == Input.Password);
            if (guest != null)
            {
                SetSessionAndRedirect(guest.Username, "Guest", guest.Id);
                return RedirectToDashboard("Guest");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }

        private void SetSessionAndRedirect(string username, string role, int userId)
        {
            HttpContext.Session.SetString("Username", username);
            HttpContext.Session.SetString("Role", role);
            HttpContext.Session.SetInt32("UserId", userId);
        }

        private IActionResult RedirectToDashboard(string role)
        {
            return role switch
            {
                "Admin" => RedirectToPage("/Admin/Dashboard"),
                "FrontDesk" => RedirectToPage("/FrontDesk/Dashboard"),
                "Housekeeping" => RedirectToPage("/Housekeeping/Dashboard"),
                "Guest" => RedirectToPage("/Guest/Dashboard"),
                _ => RedirectToPage("/Index"),
            };
        }
    }

    public class LoginInputModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}