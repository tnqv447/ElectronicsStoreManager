using AppCore.Models;

namespace AppCore.Interfaces {
    public interface IOrderRepos : IRepository<Order> 
    {
        IOrderDetailRepos OrderDetailRepos { get; }

        void Check (Order order);
        void Delivering (Order order);
        void Delivered (Order order);
        void Cancel(Order order);
    }
}