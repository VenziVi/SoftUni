using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;

namespace Git.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(Request request)
            : base(request)
        {
        }

        public Response Index()
        {
            if (!User.IsAuthenticated)
            {
                return View(new { IsAuthenticated = false }, "/Home/Index");
            }

            return this.View(new { IsAuthenticated = true}, "/Home/Index");
        }
    }
}
