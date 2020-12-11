using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppCore.Models {
    public class SubOrderDetail {
        public int Id { get; set; }

        public int OrderDetailId { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }

        public int SubItemId { get; set; }
        public virtual Item SubItem { get; set; }

        public int Amount { get; set; }
        public string ItemName { get; set; }

        [DataType (DataType.Currency)]
        public decimal ItemUnitPrice { get; set; }

        public SubOrderDetail (int orderDetailId, int subItemId, int amount, string itemName, decimal itemUnitPrice) {
            OrderDetailId = orderDetailId;
            SubItemId = subItemId;
            Amount = amount;
            ItemName = itemName;
            ItemUnitPrice = itemUnitPrice;
        }

        //notmapped--------------------------------------------------
        [NotMapped]
        public decimal SumPrice { get { return Amount * ItemUnitPrice; } }
        //---------------------------------------------------------------

        public SubOrderDetail () { }
        public SubOrderDetail (SubOrderDetail detail) {
            this.Copy (detail);
        }

        public void Copy (SubOrderDetail detail) {
            OrderDetailId = detail.OrderDetailId;
            SubItemId = detail.SubItemId;
            Amount = detail.Amount;
            ItemName = detail.ItemName;
            ItemUnitPrice = detail.ItemUnitPrice;
        }
        
        public StorageChecker? GetStorageChecker(){
            if(this.Id == 0) return null;
            return new StorageChecker(this.SubItemId, this.Amount);
        }
    }
}