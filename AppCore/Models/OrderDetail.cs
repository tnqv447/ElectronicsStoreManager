using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AppCore.Models {
    public class OrderDetail {
        public int Id { get; set; }

        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public virtual IList<SubOrderDetail> SubOrderDetails { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int Amount { get; set; }
        public string ItemName { get; set; }

        [DataType (DataType.Currency)]
        public decimal ItemUnitPrice { get; set; }

        public OrderDetail (int orderId, int itemId, int amount, string itemName, decimal itemUnitPrice) {
            OrderId = orderId;
            ItemId = itemId;
            Amount = amount;
            ItemName = itemName;
            ItemUnitPrice = itemUnitPrice;
        }

        //notmapped--------------------------------------------------
        [NotMapped]
        public decimal SumPrice { get { 
            if(IsCombo) {
                    decimal sum = 0;
                    foreach(SubOrderDetail sub in SubOrderDetails) sum += sub.SumPrice;
                    return Amount * sum;
                }
            return Amount * ItemUnitPrice; } }
        
        [NotMapped]
        public bool IsCombo { get { return !(SubOrderDetails == null || SubOrderDetails.Count == 0); } }
        //---------------------------------------------------------------

        public OrderDetail () { }
        public OrderDetail (OrderDetail detail) {
            this.Copy (detail);
        }

        public void Copy (OrderDetail detail) {
            OrderId = detail.OrderId;
            ItemId = detail.ItemId;
            Amount = detail.Amount;
            ItemName = detail.ItemName;
            ItemUnitPrice = detail.ItemUnitPrice;
        }

        public IList<StorageChecker> GetStorageChecker(){
            if(this.Id == 0) return null;
            var list = new List<StorageChecker>();
            if(IsCombo){
                foreach(SubOrderDetail sub in SubOrderDetails){
                    var temp = sub.GetStorageChecker();
                    if(temp.HasValue){
                        var res = list.Where(m => m.ItemId.Equals(temp.Value.ItemId)).ToList();
                        if(res.Any()){
                            var s = res.First();
                            s.Amount += this.Amount * temp.Value.Amount;
                        }
                        else
                        {
                            list.Add(new StorageChecker(temp.Value.ItemId, this.Amount * temp.Value.Amount));
                        }
                    }
                }
            }
            else{
                var res = list.Where(m => m.ItemId.Equals(this.ItemId)).ToList();
                if(res.Any()){
                    var s = res.First();
                    s.Amount += this.Amount;
                }
                else{
                    list.Add(new StorageChecker(this.ItemId, this.Amount));
                }
            }
            return list;
        }
    }
}