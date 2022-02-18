using CarShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Contracts
{
    public interface IUserService
    {
        bool Register(RegisterViewModel model);
        string Login(LoginViewModel model);
        bool IsUserMechanic(string id);
    }
}
