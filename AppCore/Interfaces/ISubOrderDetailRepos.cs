using AppCore.Models;

namespace AppCore.Interfaces
{
    public interface ISubOrderDetailRepos : IRepository<SubOrderDetail>
    {
        SubOrderDetail GetSubOrderDetail(int orderDetailId, int subItemId);
    }
}