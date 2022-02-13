using CarShop.Contracts;
using CarShop.Data.Common;
using CarShop.Data.Models;
using CarShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository repo;

        private readonly IValidationService validationService;

        public CarService(IRepository _repo,
            IValidationService _validationService)
        {
            repo = _repo;
            validationService = _validationService;
        }

        public (bool isRegistered, bool isMechanic) AddCar(AddViewModel model, string userId)
        {
            bool registered = false;
            bool isMechani = false;

            var user = repo.All<User>()
                .Where(u => u.Id == userId)
                .FirstOrDefault();

            if (user.IsMechanic)
            {
                isMechani = true;
            }

            var (isValid, validationError) =
                validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, isMechani);
            }

            var car = new Car() 
            {
                Model = model.Model,
                Year = model.Year,
                PlateNumber = model.PlateNumber,
                PictureUrl = model.ImageUrl,
                OwnerId = userId
            };

            try
            {
                repo.Add(car);
                repo.SaveChanges();
                registered = true;
            }
            catch (Exception)
            {
            }

            return (registered, isMechani);
        }

        public IEnumerable<Car> GetCars(string id)
        {
            IEnumerable<Car> cars = repo.All<Car>()
                .Where(c => c.OwnerId == id)
                .ToList();

            return cars;
        }

        public bool IsUserMechanic(string id)
        {
            bool isMechani = false;

            var user = repo.All<User>()
                .Where(u => u.Id == id)
                .FirstOrDefault();

            if (user.IsMechanic)
            {
                isMechani = true;
            }

            return isMechani;
        }
    }
}
