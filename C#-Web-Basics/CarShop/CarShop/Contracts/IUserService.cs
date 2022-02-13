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
        (bool isRegistered, string error) Register(RegisterViewModel model);
        string Login(LoginViewModel model);
    }
}
