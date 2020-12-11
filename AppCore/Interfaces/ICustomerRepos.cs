using AppCore.Models;

namespace AppCore.Interfaces
{
    public interface ICustomerRepos : IRepository<Customer>
    {
        void Activate (Customer customer);
        void Disable (Customer customer);

        Customer GetByAccount (string username, string password);
        bool IsUserNameExists (string username);
    }
}