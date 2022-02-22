using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using CarShop.Contracts;
using CarShop.ViewModels;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IIssueService issueService;
        private readonly ICarService carService;
        private readonly IUserService userService;
        private static string id;

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
            if (carId == null)
            {
                carId = id;
            }

            CarIssuesViewModel car = carService.GetCar(carId);
            IEnumerable<IssueViewModel> issues = issueService.GetIssues(carId);

            CarWithIssuesViewModel carIssues = issueService.GetCarWithissues(carId);

            bool isMechanic = userService.IsUserMechanic(User.Id);

            return View(new 
            {
                CarId = carId,
                Model = car.Model,
                Year = car.Year,
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

            id = carId;

            if (isAdded)
            {
                return Redirect("/Issues/CarIssues");
            }

            return Redirect("/Issues/Add");
        }

        public Response Delete(string carId, string issueId)
        {
            id = carId;
            issueService.DeleteIssue(issueId);
            return Redirect("/Issues/CarIssues");
        }

        public Response Fix(string carId, string issueId)
        {
            id = carId;
            issueService.Fix(issueId);
            return Redirect("/Issues/CarIssues");
        }
    }
}
