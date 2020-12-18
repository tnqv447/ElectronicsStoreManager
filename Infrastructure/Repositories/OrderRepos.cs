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

        public void Check (Order order){
            this.UpdateStatus(order, ORDER_STATUS.CHECKED);
        }
        public void Delivering (Order order){
            this.UpdateStatus(order, ORDER_STATUS.DELIVERING);
        }
        public void Delivered (Order order){
            this.UpdateStatus(order, ORDER_STATUS.DELIVERED);
        }
        public void Cancel(Order order){
            this.UpdateStatus(order, ORDER_STATUS.CANCELLED);
        }
        public void CancelDelivery(Order order){
            this.UpdateStatus(order, ORDER_STATUS.CANCELLED_DELIVERY);
        }

        private void UpdateStatus(Order order, ORDER_STATUS status)
        {
            order.Status = status;
            this.Update(order);
        }
    }
}