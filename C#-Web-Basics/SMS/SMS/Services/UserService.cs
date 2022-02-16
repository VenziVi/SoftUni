using Microsoft.EntityFrameworkCore;
using SMS.Constraints;
using SMS.Contracts;
using SMS.Data;
using SMS.Models;
using SMS.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SMS.Services
{
    public class UserService : IUserService
    {
        private readonly DbContext context;

        public UserService(SMSDbContext _context)
        {
            context = _context;
        }

        public (bool isValid, IEnumerable<ErrorViewModel> errors) IsValid(RegisterViewModel model)
        {
            bool isValid = true;
            var errors = new List<ErrorViewModel>();

            if (model.Username == null ||
                model.Username.Length < 5 ||
                model.Username.Length > 20)
            {
                isValid = false;
                errors.Add(new ErrorViewModel(ErrorMesages.UsernameErrorMessage));
            }

            if (string.IsNullOrEmpty(model.Username))
            {
                isValid = false;
                errors.Add(new ErrorViewModel(ErrorMesages.EmailErrorMessage));
            }

            if (model.Password == null ||
                model.Password.Length < 6 ||
                model.Password.Length > 20)
            {
                isValid = false;
                errors.Add(new ErrorViewModel(ErrorMesages.PasswordErrorMessage));
            }

            if (model.ConfirmPassword != model.Password)
            { 
                isValid = false;
                errors.Add(new ErrorViewModel(ErrorMesages.ConfirmPasswordErrorMessage));
            }

            return (isValid, errors);
        }

        public void Register(RegisterViewModel model)
        {
            User user = new User()
            {
                Username = model.Username,
                Password = HashPassword(model.Password),
                Email = model.Email,
                Cart = new Cart()
            };

            context.Add(user);
            context.SaveChanges();
        }

        public (string userId, bool userExists) UserExists(LoginViewModel model)
        {
            bool isExists = false;
            string userId = string.Empty;

            User user = UserByUsername(model.Username);

            if (user != null)
            {
                isExists = user.Password == HashPassword(model.Password);
            }

            if (isExists)
            {
                userId = user.Id;
            }

            return (userId, isExists);
        }

        private User UserByUsername(string username)
        {
            return context.Set<User>().FirstOrDefault(u => u.Username == username);
        }

        private string HashPassword(string password)
        {
            byte[] passwordArr = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passwordArr));
            }
        }

        public string GetUserName(string userId)
        {
            return context.Set<User>().FirstOrDefault(u => u.Id == userId).Username;
        }
    }
}
