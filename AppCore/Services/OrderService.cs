using System;
using System.Linq;
using System.Collections.Generic;
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
        public IList<StorageChecker> GetAllStorageChecker()
        {
            var orders = _unitOfWork.OrderRepos.GetAll().Where(m => m.Status.Equals(ORDER_STATUS.CHECKED)
                                                                                                                    || m.Status.Equals(ORDER_STATUS.DELIVERING)
                                                                                                                    || m.Status.Equals(ORDER_STATUS.DELIVERED)).ToList();
            var list = new List<StorageChecker>();
            foreach (Order order in orders)
            {
                var tempArr = order.GetStorageChecker();
                foreach (StorageChecker store in tempArr)
                {
                    var res = list.Where(m => m.ItemId.Equals(store.ItemId) && DateTime.Compare(m.OrderDate, store.OrderDate) == 0);
                    if (res.Any())
                    {
                        var temp = res.First();
                        temp.Amount += store.Amount;
                    }
                    else list.Add(store);
                }
            }
            return list;
        }
    }
}