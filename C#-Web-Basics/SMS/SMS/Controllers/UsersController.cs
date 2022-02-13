using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;
using SMS.Models;
using SMS.Models.UserModels;
using System;
using System.Collections.Generic;

namespace SMS.Controllers
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

        public Response Login() => View();

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

                return Redirect("/Home/IndexLoggedin");
            }

            return Redirect("/Users/Login");
        }

        public Response Register() => View();

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            (bool isValid, IEnumerable<ErrorViewModel> errors) = userService.IsValid(model);

            if (!isValid)
                return View(errors, "/Error");

            try
            {
                userService.Register(model);
            }
            catch (Exception)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel("Something went wrong!")}, "/Error");
            }

            return Redirect("/Users/Login");
        }

        public Response Logout()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Home/Index");
            }

            SignOut();
            return View("/Home/Index");
        }
    }
}
