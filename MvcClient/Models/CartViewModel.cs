using System.Collections.Generic;
using AppCore.Models;
namespace MvcClient.Models
{
    public class CartViewModel
    {
        public IEnumerable<CartItem> Cart { get; set; }
        public decimal TotalPrice { get; set; }
        public bool GetInfo { get; set; } = false;
        public Customer Cus { get; set; }
    }
    public class CartItem
    {
        public Product Item { get; set; }
        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
        public CartItem(Product item, int quantity)
        {
            this.Item = item;
            Quantity = quantity;
            TotalPrice = quantity * item.Price;
        }
    }
    public class Product
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public ITEM_TYPE Type { get; set; }
    }

}