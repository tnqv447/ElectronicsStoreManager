using AppCore.Interfaces;
using AppCore.Models;

namespace Infrastructure.Repositories {
    public class OrderRepos : Repository<Order>, IOrderRepos {
        private readonly ElectronicsStoreContext _context;
        public IOrderDetailRepos OrderDetailRepos { get; private set; }

        public OrderRepos (ElectronicsStoreContext context) : base (context) {
            _context = context;
            OrderDetailRepos = new OrderDetailRepos (_context);
            
        }
    }
}