using CarShop.Constraints;
using System.ComponentModel.DataAnnotations;

namespace CarShop.ViewModels
{
    public class RegisterViewModel
    {
        [StringLength(20, MinimumLength = 4, ErrorMessage = ErrorMessiges.LengthErrorMessige)]
        public string Username { get; set; }

        public string Email { get; set; }

        [StringLength(20, MinimumLength = 5, ErrorMessage = ErrorMessiges.LengthErrorMessige)]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = ErrorMessiges.ConfirmPasswordMessage)]
        public string ConfirmPassword { get; set; }

        public string UserType { get; set; }
    }
}
