using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using CarShop.Contracts;
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
        private readonly IUserService userService;
        private readonly ICarService carService;
        public CarsController(
            Request request,
            IUserService _userService,
            ICarService _carService) 
            : base(request)
        {
            userService = _userService;
            carService = _carService;
        }

        [Authorize]
        public Response All()
        {
            bool isMechanic = userService.IsUserMechanic(User.Id);

            if (!isMechanic)
            {
                IEnumerable<AllCarsViewModel> allUserCars = carService.GetAllUserCars(User.Id);

                return View(new
                {
                    IsAuthenticated = true,
                    cars = allUserCars
                }, "/Cars/All");
            }

            IEnumerable<AllCarsViewModel> allCars = carService.GetAllCars(User.Id);

            return View(new
            {
                IsAuthenticated = true,
                cars = allCars
            }, "/Cars/All");
        }

        [Authorize]
        public Response Add()
        {
            bool isMechanic = userService.IsUserMechanic(User.Id);

            if (isMechanic)
            {
                return Redirect("/Cars/All");
            }

            return View(new { IsAuthenticated = true });
        }

        [Authorize]
        [HttpPost]
        public Response Add(AddViewModel model)
        {
            bool isCreated = carService.CreateCar(model, User.Id);

            if (!isCreated)
            {
                return Redirect("/Cars/Add");
            }
            return Redirect("/Cars/All");
        }
    }
}
