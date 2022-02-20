using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.ViewModels;
using System.Security.Cryptography;
using System.Text;

namespace FootballManager.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public UserService(
            IRepository _repo,
            IValidationService _validationService)
        {
            repo = _repo;
            validationService = _validationService;
        }

        public string Login(LoginViewModel model)
        {
            string userId = null;

            var user = repo.All<User>()
                .Where(u => u.Username == model.Username)
                .Where(u => u.Password == HashFunction(model.Password))
                .FirstOrDefault();

            if (user != null)
            {
                userId = user.Id;
            }

            return userId;
        }

        public bool Register(RegisterViewModel model)
        {
            bool success = false;

            (bool isValid, string errors) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return success;
            }

            User user = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Password = HashFunction(model.Password)
            };

            try
            {
                repo.Add(user);
                repo.SaveChanges();
                success = true;
            }
            catch (Exception)
            {
            }

            return success;
        }


        private string HashFunction(string password)
        {
            byte[] passworArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passworArray));
            }
        }
    }
}
