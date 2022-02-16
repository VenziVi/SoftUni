using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;
using SMS.Models.HomeModels;
using System.Collections.Generic;

namespace SMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService homeService;
        private readonly IUserService userService;

        public HomeController(Request request,
            IHomeService _homeService,
            IUserService _userService) 
            : base(request)
        {
            homeService = _homeService;
            userService = _userService;
        }

        public Response Index()
        {
            if (User.IsAuthenticated)
            {
                IEnumerable<AllProductsViewModel> products = homeService.GetProducts();
                var username = userService.GetUserName(User.Id);

                var model = new
                {
                    username = username,
                    products = products,
                    IsAuthenticated = true
                };

                return View(model, "/Home/IndexLoggedin");
            }

            return View(new { IsAuthenticated = false});
        }
    }
}