using System;
using System.Collections.Generic;
using AppCore.Models;
namespace MvcClient.Models
{
    public class HomeViewModel
    {
        public IList<Item> items { get; set; }
    }
}