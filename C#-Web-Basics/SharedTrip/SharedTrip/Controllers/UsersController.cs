using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SharedTrip.Contracts;
using SharedTrip.Models;
using SharedTrip.Models.UsersViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        public UsersController(
            Request request,
            IUserService _userService) 
            : base(request)
        {
            userService = _userService;
        }

        public Response Login()
            => View();

        public Response Register()
            => View();

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            var (isValid, errors) = userService.IsValid(model);
            if (!isValid)
            {
                return View(errors, "/Error");
            }

            try
            {
                userService.RegisterUser(model);
            }
            catch (InvalidOperationException iex)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel(iex.Message) });
            }
            catch (Exception)
            {

                return View(new List<ErrorViewModel>() { new ErrorViewModel("Unexpected error!") });
            }


            return Redirect("/Users/Login");
        }

        [HttpPost]
        public Response Login(LoginViewModel model)
        {
            Request.Session.Clear();

            (string userId, bool userExists) = userService.UserExists(model);

            if (userExists)
            {
                SignIn(userId);
                CookieCollection cookies = new CookieCollection();
                cookies.Add(Session.SessionCookieName, Request.Session.Id);

                return Redirect("/Trips/All");
            }

            return View("/Users/Login");
        }

        [Authorize]
        public Response Logout()
        {
            SignOut();
            return View("/Users/Login");
        }
    }
}
