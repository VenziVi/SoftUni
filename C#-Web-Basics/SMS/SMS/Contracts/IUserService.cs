using SMS.Models;
using SMS.Models.UserModels;
using System.Collections.Generic;

namespace SMS.Contracts
{
    public interface IUserService
    {
        (bool isValid, IEnumerable<ErrorViewModel> errors) IsValid(RegisterViewModel model);
        void Register(RegisterViewModel model);
        (string userId, bool userExists) UserExists(LoginViewModel model);

        string GetUserName(string userId);
    }
}
