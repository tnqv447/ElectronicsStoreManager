using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AppCore.Models {
    public class Order {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        public DateTime OrderDate { get; set; }
        
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string Address { get; set; }
        [RegularExpression (@"^[0-9]{10}$", ErrorMessage = "Số điện thoại phải có 10 chữ số")]
        public string PhoneNumber { get; set; }

        public ORDER_STATUS Status { get; set; }

        public virtual IList<OrderDetail> OrderDetails { get; set; }

        //notmapped--------------------------------------------------
        [NotMapped]
        public string StatusName { get { return EnumConverter.Convert(this.Status); } }
        [NotMapped]
        public IList<StorageChecker> StorageCheckers { get; private set; } = null;
        [NotMapped]
        public decimal SumPrice { 
            get {
                decimal sum = 0;
                if(OrderDetails == null || OrderDetails.Count == 0) return 0;
                foreach(OrderDetail detail in OrderDetails){
                    sum += detail.SumPrice;
                }
                return sum;
            } }
        //---------------------------------------------------------------

        public Order (int customerId, DateTime orderDate, string address, string phoneNumber, ORDER_STATUS status = ORDER_STATUS.NEW) {
            CustomerId = customerId;
            OrderDate = orderDate;
            Address = address;
            PhoneNumber = phoneNumber;
            Status = status;
        }

        public Order () { }
        public Order (Order order) {
            this.Copy (order);
        }

        public void Copy (Order order) {
            CustomerId = order.CustomerId;
            OrderDate = order.OrderDate;
            Address = order.Address;
            PhoneNumber = order.PhoneNumber;
            Status = order.Status;
        }

        public IList<StorageChecker> GetStorageChecker(){
            if(this.Id == 0) return null;
            var list = new List<StorageChecker>();
            
            foreach(OrderDetail detail in OrderDetails){
                var temp = detail.GetStorageChecker();
                foreach(StorageChecker store in temp){
                     var res = list.Where(m => m.ItemId.Equals(store.ItemId)).ToList();
                        if(res.Any()){
                            var s = res.First();
                            s.Amount += store.Amount;
                        }else{
                            list.Add(store);
                        }
                }
            }
            this.StorageCheckers = list;
            return list;
        }

    }
}