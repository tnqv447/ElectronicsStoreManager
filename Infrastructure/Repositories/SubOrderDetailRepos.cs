using System.Linq;
using AppCore.Interfaces;
using AppCore.Models;

namespace Infrastructure.Repositories
{
    public class SubOrderDetailRepos : Repository<SubOrderDetail>, ISubOrderDetailRepos
    {
        private readonly ElectronicsStoreContext _context;
        public SubOrderDetailRepos(ElectronicsStoreContext context) : base(context)
        {
            _context = context;
        }

        public SubOrderDetail GetSubOrderDetail(int orderDetailId, int subItemId){
            var arr =  _context.SubOrderDetails.Where(m => m.OrderDetailId.Equals(orderDetailId) && m.SubItemId.Equals(subItemId));
            if(arr == null || arr.Count() == 0 ) return null;
            else return arr.First();
        }
    }
}