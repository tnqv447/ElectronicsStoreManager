using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppCore.Models {
    public class Item {
        public int Id { get; set; }

        [Required (ErrorMessage = "Không được để trống tên")]
        public string Name { get; set; }

        [DataType (DataType.Currency)]
        public decimal UnitPrice { get; set; }
        public ITEM_TYPE Type { get; set; }
        public string Description { get; set; }
        public ITEM_STATUS Status { get; set; }
        
        //la so luong hien co trong kho hang
        public int InStock { get; set; }


        //combo bao gồm
        public virtual IList<ItemRelation> ConsistOf { get; set; }
        //thuôc combo nào
        public virtual IList<ItemRelation> PartOf { get; set; }

        //notmapped--------------------------------------------------
        [NotMapped]
        public string TypeName { get { return EnumConverter.Convert(this.Type); } }
        [NotMapped]
        public string StatusName { get { return EnumConverter.Convert(this.Status); } }
        [NotMapped]
        public bool IsCombo { get { return !(ConsistOf == null || ConsistOf.Count == 0); } }
        [NotMapped]
        public bool IsPartOf { get { return !(PartOf == null || PartOf.Count == 0); } }
        //---------------------------------------------------------------

        public Item (string name, ITEM_TYPE type,  decimal unitPrice, string description, int stock = 0, ITEM_STATUS status = ITEM_STATUS.ACTIVE) {
            Name = name;
            Type = type;
            UnitPrice = unitPrice;
            Description = description;
            InStock = stock;
            Status = status;
        }

        public Item () { }
        public Item (Item item) {
            this.Copy (item);
        }
        public Item (Item item, int id) {
            this.Copy (item);
            item.Id = id;
        }
        
        public void Copy (Item item) {
            Name = item.Name;
            Type = item.Type;
            UnitPrice = item.UnitPrice;
            Description = item.Description;
            InStock = item.InStock;
            Status = item.Status;
        }

    }
}