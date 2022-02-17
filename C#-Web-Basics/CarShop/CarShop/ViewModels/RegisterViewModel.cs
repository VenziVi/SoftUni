using CarShop.Constraints;
using System.ComponentModel.DataAnnotations;

namespace CarShop.ViewModels
{
    public class RegisterViewModel
    {
        [StringLength(20, MinimumLength = 4)]
        public string Username { get; set; }

        public string Email { get; set; }

        [StringLength(20, MinimumLength = 5)]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public string UserType { get; set; }
    }
}
