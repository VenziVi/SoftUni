using SharedTrip.Models;
using SharedTrip.Models.UsersViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Contracts
{
    public interface IUserService
    {
        (bool isValid, IEnumerable<ErrorViewModel> errors) IsValid(RegisterViewModel model);
        void RegisterUser(RegisterViewModel model);
        (string userId, bool userExists) UserExists(LoginViewModel model);
    }
}
