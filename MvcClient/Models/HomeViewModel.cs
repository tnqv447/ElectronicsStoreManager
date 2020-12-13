using System;
using System.Collections.Generic;
using AppCore.Models;
namespace MvcClient.Models
{
    public class HomeViewModel
    {
        public PaginatedList<Item> items { get; set; }
        public PaginatedList<Item> combos { get; set; }
    }
}