using AppCore.Interfaces;
using AppCore.Models;

namespace AppCore.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LoginService (IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public Customer Login (string username, string password) {
            return _unitOfWork.CustomerRepos.GetByAccount (username, password);
        }
        public bool isUsernameExists (string username) {
            return _unitOfWork.CustomerRepos.IsUserNameExists (username);
        }
    }
}