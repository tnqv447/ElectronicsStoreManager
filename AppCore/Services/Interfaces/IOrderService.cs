using System.Collections.Generic;
using AppCore.Models;

namespace AppCore.Services
{
    public interface IOrderService
    {
        bool StorageCheck(Order order);
        bool UpdateStorage(Order order, bool toAdd = true);
        IList<StorageChecker> GetAllStorageChecker();
    }
}