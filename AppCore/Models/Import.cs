using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AppCore.Models
{
    public class Import
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public int Amount { get; set; }
        public DateTime ImportDate { get; set; }

        public Import(int itemId, int amount, DateTime importDate)
        {
            ItemId = itemId;
            Amount = amount;
            ImportDate = importDate;
        }

        public Import()
        {
        }
        public Import(Import import)
        {
            this.Copy(import);
        }

        public void Copy(Import import){
            ItemId = import.ItemId;
            Amount = import.Amount;
            ImportDate = import.ImportDate;
        }
    }
}