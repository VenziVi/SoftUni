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
        public Response CarIssues(string CarId)
        {
            CarIssuesViewModel car = carService.GetCar(CarId);
            IEnumerable<IssueViewModel> issues = issueService.GetIssues(CarId);

            CarWithIssuesViewModel carIssues = issueService.GetCarWithissues(CarId);

            bool isMechanic = userService.IsUserMechanic(User.Id);

            return View(new 
            {
                CarId = CarId,
                Model = car.Model,
                Year = car.Year,
                //CarIssues = carIssues,
                Issues = issues,
                IsAuthenticated = true,
                isMechanic = isMechanic,
            });
        }

        [Authorize]
        public Response Add(string CarId)
        {
            return View(new { IsAuthenticated = true, CarId = CarId });
        }

        [Authorize]
        [HttpPost]
        public Response Add(AddIssueViewModel model, string CarId)
        {
            bool isAdded = issueService.addIssue(model, CarId);

            if (isAdded)
            {
                return Redirect("/Issues/CarIssues");
            }

            return Redirect("/Issues/Add");
        }

        public Response Delete(string CarId, string issueId)
        {
            issueService.DeleteIssue(CarId, issueId);
            return Redirect("/Issues/CarIssues");
        }
    }
}
