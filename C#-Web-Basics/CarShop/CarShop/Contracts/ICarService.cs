using CarShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Contracts
{
    public interface ICarService
    {
        bool CreateCar(AddViewModel model, string userId);
        IEnumerable<AllCarsViewModel> GetAllUserCars(string id);
        CarIssuesViewModel GetCar(string carId);
        IEnumerable<AllCarsViewModel> GetAllCars(string id);
    }
}
