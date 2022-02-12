using Microsoft.EntityFrameworkCore;
using SharedTrip.Contracts;
using SharedTrip.Data;
using SharedTrip.Models;
using SharedTrip.Models.UsersViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public class UserService : IUserService
    {
        private readonly DbContext dbContext;

        public UserService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public (bool isValid, IEnumerable<ErrorViewModel> errors) IsValid(RegisterViewModel model)
        {
            bool isValid = true;
            List<ErrorViewModel> errors = new List<ErrorViewModel>();

            if (model.Username == null ||
                model.Username.Length < 5 ||
                model.Username.Length > 20)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Username is required and must be between 5 and 20 characters!"));
            }

            if (string.IsNullOrWhiteSpace(model.Email))
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Email is required!"));
            }

            if (model.Password == null ||
                model.Password.Length < 6 ||
                model.Password.Length > 20)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Password is required and must be between 6 and 20 characters!"));
            }

            if (model.Password != model.ConfirmPassword)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Password and confirm password must be same!"));
            }

            return (isValid, errors);
        }

        public void RegisterUser(RegisterViewModel model)
        {
            var userExists = UserByUsername(model.Username) != null;

            if (userExists)
            {
                throw new InvalidOperationException("Username allready exists!");
            }

            User user = new User()
            {
                Username = model.Username,
                Email = model.Email
            };

            user.Password = HashPassword(model.Password);

            dbContext.Add(user);
            dbContext.SaveChanges();
        }

        private User UserByUsername(string username)
        {
            return dbContext.Set<User>().FirstOrDefault(u => u.Username == username);
        }

        public (string userId, bool userExists) UserExists(LoginViewModel model)
        {
            bool isExists = false;
            string userId = string.Empty;

            var user = UserByUsername(model.Username);

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

        private string HashPassword(string password)
        {
            byte[] passwordArr = Encoding.UTF8.GetBytes(password);

            using(SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passwordArr));
            }
        }
    }
}
