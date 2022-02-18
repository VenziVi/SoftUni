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
    public class IssuesController : Controller
    {
        private readonly IIssueService issueService;
        private readonly ICarService carService;
        private readonly IUserService userService;

        public IssuesController(
            Request request,
            IIssueService _issueService,
            ICarService _carService,
            IUserService _userService) 
            : base(request)
        {
            issueService = _issueService;
            carService = _carService;
            userService = _userService;
        }

        [Authorize]
        public Response CarIssues(string carId)
        {
            CarIssuesViewModel car = carService.GetCar(carId);
            IEnumerable<IssueViewModel> issues = issueService.GetIssues(carId);

            CarWithIssuesViewModel carIssues = issueService.GetCarWithissues(carId);

            bool isMechanic = userService.IsUserMechanic(User.Id);

            return View(new 
            {
                Car = car,
                //CarIssues = carIssues,
                Issues = issues,
                IsAuthenticated = true,
                isMechanic = isMechanic,
            });
        }

        [Authorize]
        public Response Add(string carId)
        {
            return View(new { IsAuthenticated = true, CarId = carId });
        }

        [Authorize]
        [HttpPost]
        public Response Add(AddIssueViewModel model, string carId)
        {
            bool isAdded = issueService.addIssue(model, carId);

            if (isAdded)
            {
                return Redirect("/Issues/CarIssues");
            }

            return Redirect("/Issues/Add");
        }
    }
}
