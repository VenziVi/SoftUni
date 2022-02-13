using CarShop.Data.Models;
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
        (bool isRegistered, bool isMechanic) AddCar(AddViewModel model, string id);
        bool IsUserMechanic(string id);
        IEnumerable<Car> GetCars(string id);
    }
}
