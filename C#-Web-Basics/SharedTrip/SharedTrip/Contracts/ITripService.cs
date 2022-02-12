using SharedTrip.Models;
using SharedTrip.Models.TripsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Contracts
{
    public interface ITripService
    {
        (bool isValid, IEnumerable<ErrorViewModel> errors) IsValid(AddViewModel model);
        void AddTrip(AddViewModel model);
        IEnumerable<AllTripsViewModel> GetAllTrips();
    }
}
