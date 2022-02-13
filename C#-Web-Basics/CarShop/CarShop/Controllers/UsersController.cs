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
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        public UsersController(Request request,
            IUserService _userService) 
            : base(request)
        {
            userService = _userService;
        }

        public Response Register() => View(new { IsAuthenticated = false });

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            (bool isRegistered, string error) = userService.Register(model);

            if (isRegistered)
            {
                return Redirect("/Users/Login");
            }

            return Redirect("/Users/Register");
        }

        public Response Login() => View(new { IsAuthenticated = false });

        [HttpPost]
        public Response Login(LoginViewModel model)
        {
            Request.Session.Clear();
            string id = userService.Login(model);

            if (id == null)
            {
                return Redirect("/Users/Login");
            }

            SignIn(id);

            CookieCollection cookies = new CookieCollection();
            cookies.Add(Session.SessionCookieName,
                Request.Session.Id);

            return Redirect("/Cars/All");
        }

        [Authorize]
        public Response Logout()
        {
            SignOut();

            return Redirect("/");
        }
    }
}
