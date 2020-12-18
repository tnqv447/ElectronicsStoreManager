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

        public bool UpdateStorage(Order order, bool toAdd = true)
        {
            if (order is null) return false;
            if (order.StorageCheckers is null)
            {
                if(!this.StorageCheck(order) && !toAdd) return false;
            }
            foreach (StorageChecker store in order.StorageCheckers)
            {
                var item = _unitOfWork.ItemRepos.GetBy(store.ItemId);
                if (toAdd) item.InStock += store.Amount;
                else item.InStock -= store.Amount;
                _unitOfWork.ItemRepos.Update(item);
            }
            return true;
        }
    }
}