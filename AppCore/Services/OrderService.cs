using AppCore.Interfaces;
using AppCore.Models;

namespace AppCore.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService (IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public bool StorageCheck(Order order){
            if(!_unitOfWork.OrderRepos.Exists(order.Id)) return false;
            var checker = order.GetStorageChecker();
            var res = true;
            foreach(StorageChecker store in checker){
                var item = _unitOfWork.ItemRepos.GetBy(store.ItemId);
                if(item == null || store.Amount > item.InStock){
                    res = false; break;
                }
            }
            return res;
        }
    }
}