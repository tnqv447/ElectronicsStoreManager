using System.Collections.Generic;
using AppCore.Models;

namespace AppCore.Interfaces {
    public interface IItemRepos : IRepository<Item> 
    {
        IItemRelationRepos ItemRelationRepos { get; }

        IList<Item> GetAllCombo();
        IList<Item> GetAllNotCombo();

        Item AddCombo(Item combo, IList<Item> elements);

    }
}