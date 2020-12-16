using System.Collections.Generic;
using System.Linq;
using AppCore.Interfaces;
using AppCore.Models;

namespace Infrastructure.Repositories
{
    public class ItemRepos : Repository<Item>, IItemRepos
    {
        private readonly ElectronicsStoreContext _context;
        public IItemRelationRepos ItemRelationRepos { get; private set; }

        public ItemRepos(ElectronicsStoreContext context) : base(context)
        {
            _context = context;
            ItemRelationRepos = new ItemRelationRepos(_context);
        }

        public IList<Item> GetAllCombo()
        {
            return _context.Items.Where(m => m.Type.Equals(ITEM_TYPE.COMBO)).ToList();
        }

        public IList<Item> GetAllNotCombo()
        {
            return _context.Items.Where(m => !m.Type.Equals(ITEM_TYPE.COMBO)).ToList();
        }

        public Item AddCombo(Item combo, IList<ComboChild> elements)
        {
            var tracked = base.Add(combo);
            foreach (ComboChild ele in elements)
            {
                if (ele.Item.Id != 0) this.ItemRelationRepos.Add(new ItemRelation(tracked.Id, ele.Item.Id, ele.Amount));
            }
            return tracked;
        }

        public override void Delete(Item item)
        {
            if (item == null) return;
            if (item.ConsistOf == null) return;
            else
            {
                this.ItemRelationRepos.DeleteRange(item.ConsistOf);
            }
            this.Delete(item);
        }

        public override void DeleteRange(IList<Item> items)
        {
            if (items == null) return;
            foreach (Item item in items)
            {
                if (item.ConsistOf == null) return;
                else
                {
                    this.ItemRelationRepos.DeleteRange(item.ConsistOf);
                }
            }
            this.DeleteRange(items);
        }
        public void Activate (Item item){
            this.UpdateStatus(item, ITEM_STATUS.ACTIVE);
        }
        public void Disable (Item item){
            this.UpdateStatus(item, ITEM_STATUS.DISABLED);
        }
        private void UpdateStatus(Item item, ITEM_STATUS status)
        {
            item.Status = status;
            this.Update(item);
        }
    }
}