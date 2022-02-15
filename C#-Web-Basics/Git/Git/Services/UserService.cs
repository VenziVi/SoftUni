using Git.Contracts;
using Git.Data.Common;
using Git.Data.Models;
using Git.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Git.Services
{
    public class UserService : IUserService
    {
        private readonly IDbRepository repo;

        private readonly IValidationService validationService;

        public UserService(
            IDbRepository _repo,
            IValidationService _validationService
            )
        {
            repo = _repo;
            validationService = _validationService;
        }

        public string IsLogged(LoginViewModel model)
        {
            var user = repo.All<User>()
                .Where(u => u.Username == model.Username)
                .Where(u => u.Password == GetHash(model.Password))
                .FirstOrDefault();

            return user.Id;
        }

        public bool IsRegistred(RegisterViewModel model)
        {
            bool isRegistred = false;

            var isValid = validationService.ValidateModel(model);

            if (string.IsNullOrWhiteSpace(model.Username) ||
                string.IsNullOrWhiteSpace(model.Email) ||
                string.IsNullOrWhiteSpace(model.Password))
            {
                isValid = false;
            }

            if (!isValid)
            {
                return isRegistred;
            }

            User user = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Password = GetHash(model.Password)
            };

            try
            {
                repo.Add(user);
                repo.SaveChanges();
                isRegistred = true;
            }
            catch (Exception)
            {
            }

            return isRegistred;
        }

        private string GetHash(string password)
        {
            byte[] passworArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passworArray));
            }
        }
    }
}
