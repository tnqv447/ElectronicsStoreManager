using AppCore.Models;

namespace AppCore.Services
{
    public interface IOrderService
    {
        bool StorageCheck(Order order);
    }
}