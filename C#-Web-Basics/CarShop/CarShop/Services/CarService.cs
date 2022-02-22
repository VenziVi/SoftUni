using CarShop.Contracts;
using CarShop.Data.Common;
using CarShop.Data.Models;
using CarShop.ViewModels;

namespace CarShop.Services
{
    public class CarService : ICarService
    {
        private readonly IValidationService validationService;
        private readonly IRepository repo;

        public CarService(
            IValidationService _validationService,
            IRepository _repo)
        {
            validationService = _validationService;
            repo = _repo;   
        }

        public bool CreateCar(AddViewModel model, string userId)
        {
            bool isCreated = false;

            (bool isVald, string error) = validationService.ValidateModel(model);

            if (!isVald)
            {
                return isCreated;
            }

            User owner = repo.All<User>().Where(u => u.Id == userId).FirstOrDefault();

            Car car = new Car()
            {
                Model = model.Model,
                Year = model.Year,
                PlateNumber = model.PlateNumber,
                PictureUrl = model.ImageUrl,
                Issues = new List<Issue>(),
                OwnerId = userId,
                Owner = owner
            };

            try
            {
                repo.Add(car);
                repo.SaveChanges();
                isCreated = true;
            }
            catch (Exception)
            {
            }

            return isCreated;
        }

        public IEnumerable<AllCarsViewModel> GetAllCars(string id)
        {
            return repo
                .All<Car>()
                .Where(c => c.Issues.Any(c => c.IsFixed == false))
                .Select(c => new AllCarsViewModel()
                {
                    CarId = c.Id,
                    Model = c.Model,
                    Year = c.Year.ToString(),
                    PictureUrl = c.PictureUrl,
                    PlateNumber = c.PlateNumber,
                    Issues = c.Issues.Where(i => i.IsFixed == false).Count(),
                    FixedIssues = c.Issues.Where(i => i.IsFixed == true).Count()
                })
                .ToList();
        }

        public IEnumerable<AllCarsViewModel> GetAllUserCars(string id)
        {
            return repo
                .All<Car>()
                .Where(c => c.OwnerId == id)
                .Select(c => new AllCarsViewModel()
                {
                    CarId = c.Id,
                    Model = c.Model,
                    Year = c.Year.ToString(),
                    PictureUrl= c.PictureUrl,
                    PlateNumber= c.PlateNumber,
                    Issues = c.Issues.Where(i => i.IsFixed == false).Count(),
                    FixedIssues = c.Issues.Where(i => i.IsFixed == true).Count()
                })
                .ToList();
        }

        public CarIssuesViewModel? GetCar(string carId)
        {
            return repo.All<Car>()
                .Where(c => c.Id == carId)
                .Select(c => new CarIssuesViewModel()
                {
                    Model = c.Model,
                    CarId = c.Id,
                    Year = c.Year,
                }).FirstOrDefault();
        }
    }
}
