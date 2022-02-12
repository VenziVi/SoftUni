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


        public Response All()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Home");
            }

            IEnumerable<AllTripsViewModel> trips = tripService.GetAllTrips();
            return View(trips);
        }

        
        public Response Add()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Home");
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public Response Add(AddViewModel model)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Home");
            }

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

        public Response AddUserToTrip(string tripId)
        {
            var isAdded = tripService.IsAddedToTrip(tripId, User.Id);

            if (isAdded)
            {
                return Redirect($"/Trips/Details?tripId={tripId}");
                ///Trips/Details?tripId=65235c4e-ddf8-4ced-b184-174ed09edacf
            }

            try
            {
                tripService.AddUSerToTrip(tripId, User.Id);
            }
            catch(ArgumentException aex)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel(aex.Message) });
            }
            catch (Exception)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel("Unexpected error!") });
            }

            return Redirect("/Trips/All");
        }
    }
}
