using AppCore.Models;

namespace AppCore.Interfaces
{
    public interface IItemRelationRepos : IRepository<ItemRelation>
    {
         ItemRelation GetRelation(int parentItemId, int childItemId);
    }
}