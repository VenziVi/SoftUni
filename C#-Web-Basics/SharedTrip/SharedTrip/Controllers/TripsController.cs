using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SharedTrip.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        public readonly ITripService tripService;
        public TripsController(
            Request request,
            ITripService _tripService) 
            : base(request)
        {
            tripService = _tripService;
        }

        [Authorize]
        public Response All()
        {
            return View();
        }

        [Authorize]
        public Response Add()
        {
            return View();
        }

        [Authorize]
        public Response Details()
        {
            return View();
        }
    }
}
