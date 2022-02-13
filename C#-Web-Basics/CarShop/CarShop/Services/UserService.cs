using CarShop.Contracts;
using CarShop.Data.Common;
using CarShop.Data.Models;
using CarShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        private readonly IValidationService validationService;

        public UserService(IRepository _repo,
            IValidationService _validationService)
        {
            repo = _repo;
            validationService = _validationService;
        }


        public (bool isRegistered, string error) Register(RegisterViewModel model)
        {
            bool registered = false;
            string error = null;

            var (isValid, validationError) = 
                validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, validationError);
            }

            User user = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Password = HashFunction(model.Password),
                IsMechanic = IsMechanic(model.UserType)
            };

            try
            {
                repo.Add(user);
                repo.SaveChanges();
                registered = true;
            }
            catch (Exception)
            {
                error = "Could not save user in DB";
            }

            return (registered, error);
        }

        private bool IsMechanic(string userType)
        {
            bool isMechanic = true;

            if (userType == "Client")
            {
                isMechanic = false;
            }

            return isMechanic;
        }

        private string HashFunction(string password)
        {
            byte[] passworArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passworArray));
            }
        }

        public string Login(LoginViewModel model)
        {
            var user = repo.All<User>()
                .Where(u => u.Username == model.Username)
                .Where(u => u.Password == HashFunction(model.Password))
                .SingleOrDefault();

            return user?.Id;
        }
    }
}
