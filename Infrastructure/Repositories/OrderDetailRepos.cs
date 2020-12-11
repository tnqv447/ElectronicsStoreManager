using System.Reflection.Metadata;
using System.Linq;
using AppCore.Interfaces;
using AppCore.Models;

namespace Infrastructure.Repositories
{
    public class OrderDetailRepos : Repository<OrderDetail>, IOrderDetailRepos
    {
        private readonly ElectronicsStoreContext _context;
        public ISubOrderDetailRepos SubOrderDetailRepos { get; private set; }
        public OrderDetailRepos(ElectronicsStoreContext context) : base(context)
        {
            _context = context;
            SubOrderDetailRepos = new SubOrderDetailRepos (_context);
        }

        public OrderDetail GetOrderDetail(int orderId, int itemId){
            var arr =  _context.OrderDetails.Where(m => m.OrderId.Equals(orderId) && m.ItemId.Equals(itemId));
            if(arr == null || arr.Count() == 0 ) return null;
            else return arr.First();
        }

        public override OrderDetail Add(OrderDetail detail){
            var tracked = base.Add(detail);
            if(tracked.Item.IsCombo){
                foreach(ItemRelation relation in tracked.Item.ConsistOf){
                    var temp = relation.Child;
                    this.SubOrderDetailRepos.Add(new SubOrderDetail(tracked.Id, temp.Id, temp.ComboAmount, temp.Name, temp.UnitPrice));
                }
            }
            return tracked;
        }
    }
}