using AppCore.Models;

namespace AppCore.Interfaces {
    public interface IOrderRepos : IRepository<Order> 
    {
        IOrderDetailRepos OrderDetailRepos { get; }
    }
}