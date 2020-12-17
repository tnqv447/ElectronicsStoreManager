using System;
using System.Collections.Generic;
using AppCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcClient.Models
{
    public class HomeViewModel
    {
        public PaginatedList<Item> items { get; set; }
        public PaginatedList<Item> combos { get; set; }

        public Item item { get; set; }
        public IList<EnumCheckBox> CheckBoxValues { get; set; }
    }
    public class EnumCheckBox
    {
        public ITEM_TYPE types { get; set; }
        public bool IsSelected { get; set; }
        public EnumCheckBox()
        {

        }
        public EnumCheckBox(ITEM_TYPE types, bool isSelected)
        {
            this.types = types;
            this.IsSelected = isSelected;
        }
    }
}