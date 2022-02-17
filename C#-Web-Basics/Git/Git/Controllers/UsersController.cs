using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using Git.Contracts;
using Git.Data.ViewModels;

namespace Git.Controllers
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

        public Response Register()
        {
            if (User.IsAuthenticated)
            {
                return View(new { IsAuthenticated = false }, "/Repositories/All");
            }

            return View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            bool isRegistred = userService.IsRegistred(model);

            if (isRegistred)
            {
                return Redirect("/Users/Login");
            }

            return Redirect("/Users/Register");
        }

        public Response Login()
        {
            //if (User.IsAuthenticated)
            //{
            //    return Redirect("/Repositories/All");
            //}

            return View(new { IsAuthenticated = false});
        }

        [HttpPost]
        public Response Login(LoginViewModel model)
        {
            //if (User.IsAuthenticated)
            //{
            //    return Redirect("/Repositories/All");
            //}

            string id = userService.IsLogged(model);

            if (id == null)
            {
                return Redirect("/Users/Login");
            }

            SignIn(id);

            CookieCollection cookies = new CookieCollection();
            cookies.Add(Session.SessionCookieName,
                Request.Session.Id);

            return View(new { IsAuthenticated = true }, "/Repositories/All");
        }

        public Response Logout()
        {
            SignOut();

            return View(new { IsAuthenticated = false }, "/Home/Index");
        }
    }
}
