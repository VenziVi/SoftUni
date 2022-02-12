using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SharedTrip.Contracts;
using SharedTrip.Models;
using SharedTrip.Models.TripsViewModels;
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
            IEnumerable<AllTripsViewModel> trips = tripService.GetAllTrips();
            return View(trips);
        }

        [Authorize]
        public Response Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public Response Add(AddViewModel model)
        {
            var (isValid, errors) = tripService.IsValid(model);

            if (!isValid)
            {
                return View(errors, "/Error");
            }

            try
            {
                tripService.AddTrip(model);
            }
            catch (Exception)
            {

                return View(new List<ErrorViewModel>() { new ErrorViewModel("Unexpected error!") });
            }

            return Redirect("/Trips/All");
        }

        [Authorize]
        public Response Details(string tripId)
        {
            DetailsViewModel details = tripService.GetTripDetails(tripId);
            return View(details);
        }
    }
}
