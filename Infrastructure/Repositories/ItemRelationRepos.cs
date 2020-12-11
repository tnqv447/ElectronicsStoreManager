using System.Linq;
using AppCore.Interfaces;
using AppCore.Models;

namespace Infrastructure.Repositories
{
    public class ItemRelationRepos : Repository<ItemRelation>, IItemRelationRepos
    {
        private readonly ElectronicsStoreContext _context;
        public ItemRelationRepos(ElectronicsStoreContext context) : base(context)
        {
            _context = context;
        }

        public ItemRelation GetRelation(int parentItemId, int childItemId){
            var arr =  _context.ItemRelations.Where(m => m.ParentId.Equals(parentItemId) && m.ChildId.Equals(childItemId));
            if(arr == null || arr.Count() == 0 ) return null;
            else return arr.First();
        }
    }
}