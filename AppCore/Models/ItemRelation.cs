namespace AppCore.Models {
    public class ItemRelation {
        public int Id { get; set; }

        public int ParentId { get; set; }
        public virtual Item Parent { get; set; }

        public int ChildId { get; set; }
        public virtual Item Child { get; set; }

        public ItemRelation (int parentId, int childId) {
            ParentId = parentId;
            ChildId = childId;
        }

        public ItemRelation () { }
        public ItemRelation (ItemRelation relation) {
            this.Copy (relation);
        }
        

        public void Copy (ItemRelation relation) {
            ParentId = relation.ParentId;
            ChildId = relation.ChildId;
        }
    }
}