using CarShop.ViewModels;

namespace CarShop.Contracts
{
    public interface IUserService
    {
        bool Register(RegisterViewModel model);
        string Login(LoginViewModel model);
        bool IsUserMechanic(string id);
    }
}
