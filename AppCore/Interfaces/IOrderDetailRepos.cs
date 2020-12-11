using AppCore.Models;

namespace AppCore.Interfaces
{
    public interface IOrderDetailRepos : IRepository<OrderDetail>
    {
        ISubOrderDetailRepos SubOrderDetailRepos { get; }

        OrderDetail GetOrderDetail(int orderId, int itemId);
    }
}