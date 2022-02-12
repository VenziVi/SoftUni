using Microsoft.EntityFrameworkCore;
using SharedTrip.Contracts;
using SharedTrip.Data;
using SharedTrip.Models;
using SharedTrip.Models.TripsViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SharedTrip.Services
{
    public class TripService : ITripService
    {
        private readonly DbContext context;

        public TripService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public void AddTrip(AddViewModel model)
        {
            Trip trip = new Trip()
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                Description = model.Description,
                Seats = model.Seats,
                ImagePath = model.ImagePath,
                DepartureTime = GetDate(model.DepartureTime)
            };

            context.Add(trip);
            context.SaveChanges();
        }

        private DateTime GetDate(string departureTime)
        {
            DateTime currDate;
            DateTime.TryParseExact(departureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out currDate);
            return currDate;
        }

        public (bool isValid, IEnumerable<ErrorViewModel> errors) IsValid(AddViewModel model)
        {
            bool IsValid = true;
            var errors = new List<ErrorViewModel>();
            DateTime currDate;

            if (string.IsNullOrWhiteSpace(model.StartPoint))
            {
                IsValid = false;
                errors.Add(new ErrorViewModel("Start point is required!"));
            }

            if (string.IsNullOrWhiteSpace(model.EndPoint))
            {
                IsValid = false;
                errors.Add(new ErrorViewModel("End point is required!"));
            }

            if (!DateTime.TryParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out currDate))
            {
                IsValid = false;
                errors.Add(new ErrorViewModel("Incorect date!"));
            }

            if (model.Seats < 2 || model.Seats > 6)
            {
                IsValid = false;
                errors.Add(new ErrorViewModel("Seats must be between 2 and 6!"));
            }

            if (string.IsNullOrWhiteSpace(model.Description) || model.Description.Length > 80)
            {
                IsValid = false;
                errors.Add(new ErrorViewModel("Description is required and must not be more than 80 characters!"));
            }

            return (IsValid, errors);
        }

        public IEnumerable<AllTripsViewModel> GetAllTrips()
        {
            return context.Set<Trip>()
                .Select(t => new AllTripsViewModel()
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Seats = t.Seats
                });
        }

        public DetailsViewModel GetTripDetails(string tripId)
        {
            return context.Set<Trip>()
                .Where(t => t.Id == tripId)
                .Select(t => new DetailsViewModel()
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    Description = t.Description,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Seats = t.Seats,
                    ImagePath = t.ImagePath
                })
                .FirstOrDefault();
        }

        public void AddUSerToTrip(string tripId, string id)
        {
            var user = context.Set<User>()
                .FirstOrDefault(u => u.Id == id);
            var trip = context.Set<Trip>()
                .FirstOrDefault(t => t.Id == tripId);

            if (user == null || trip == null)
            {
                throw new ArgumentException("User or trip not found!");
            }

            user.UserTrips.Add(new UserTrip()
            {
                TripId = tripId,
                Trip = trip,
                User = user,
                UserId = id
            });

            context.SaveChanges();
        }

        public bool IsAddedToTrip(string tripId, string id)
        {
            return context.Set<UserTrip>()
                .Any(t => t.TripId == tripId && t.UserId == id);
        }
    }
}
