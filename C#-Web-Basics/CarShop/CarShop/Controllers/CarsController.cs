using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        public CarsController(Request request) 
            : base(request)
        {
        }

        [Authorize]
        public Response All() => View(new { IsAuthenticated = true});  
    }
}
