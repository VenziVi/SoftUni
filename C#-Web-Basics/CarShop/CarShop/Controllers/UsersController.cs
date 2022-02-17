using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using CarShop.Contracts;
using CarShop.ViewModels;

namespace CarShop.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        public UsersController(Request request,
            IUserService _userService) 
            : base(request)
        {
            userService = _userService;
        }

        public Response Register() => View(new {IsAuthenticated = false});

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            bool isRegistred = userService.Register(model);

            if (!isRegistred)
            {
                return View(new { IsAuthenticated = false });
            }

            return Redirect("/Users/Login");
        }

        public Response Login() => View(new { IsAuthenticated = false });

        [HttpPost]
        public Response Login(LoginViewModel model)
        {
            Request.Session.Clear();

            string userId = userService.Login(model);

            if (userId == null)
            {
                return View(new { IsAuthenticated = false });
            }

            SignIn(userId);

            CookieCollection cookies = new CookieCollection();
            cookies.Add(Session.SessionCookieName,
                Request.Session.Id);

            return View(new { IsAuthenticated = true }, "/Cars/All");
        }

        [Authorize]
        public Response Logout()
        {
            SignOut();

            return View(new { IsAuthenticated = false }, "/Home/Index"); ;
        }
    }
}
