using System.Linq;
using AppCore.Interfaces;
using AppCore.Models;

namespace Infrastructure.Repositories
{
    public class CustomerRepos : Repository<Customer>, ICustomerRepos
    {
        private readonly ElectronicsStoreContext _context;
        public CustomerRepos(ElectronicsStoreContext context) : base(context)
        {
            _context = context;
        }

        public void Activate (Customer customer){
            this.UpdateStatus(customer, CUSTOMER_STATUS.ACTIVE);
        }
        public void Disable (Customer customer){
            this.UpdateStatus(customer, CUSTOMER_STATUS.DISABLED);
        }
        private void UpdateStatus(Customer customer, CUSTOMER_STATUS status)
        {
            customer.Status = status;
            this.Update(customer);
        }

        public Customer GetByAccount (string username, string password){
            var cus = _context.Customers.Where(m => m.Username.Equals(username) && m.Password.Equals(password));
            if (cus.Any()) return cus.First();
            return null;
        }

        public bool IsUserNameExists (string username){
            return _context.Customers.Select(m => m.Username).Where(m => m.Equals(username)).Any();
        }
        
    }
}