using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using CarShop.Contracts;
using CarShop.Data.Models;
using CarShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService carService;
        public CarsController(Request request,
                        ICarService _carService) 
            : base(request)
        {
            carService = _carService;
        }

        [Authorize]
        public Response Add()
        {
            bool isUserMechanic = carService.IsUserMechanic(User.Id);

            if (isUserMechanic)
            {
                return Redirect("/Cars/All");
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public Response Add(AddViewModel model)
        {

            (bool isRegistered, bool isMechanic) = carService.AddCar(model, User.Id);

            if (isRegistered)
            {
                return Redirect("/Cars/All");
            }

            return Redirect("/Cars/Add");
        }

        [Authorize]
        public Response All()
        {
            IEnumerable<Car> cars = carService.GetCars(User.Id);

            return View(cars.Select(c => new AllCarsViewModel
            {
                Model = c.Model,
                PictureUrl = c.PictureUrl,
                PlateNumber = c.PlateNumber,
                Issues = c.Issues.Count()
            }));
        }

    }
}
