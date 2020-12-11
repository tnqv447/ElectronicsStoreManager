using AppCore.Models;

namespace AppCore.Services
{
    public interface ILoginService
    {
        Customer Login(string username, string password);
        bool isUsernameExists(string username);
    }
}