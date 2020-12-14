using System;
using System.Collections.Generic;
using AppCore.Models;

namespace AppCore.Services
{
    public interface ISearchSortService
    {
        //search
        IList<Customer> Search(IList<Customer> customers, string searchString = null, SEX? sex = null, CUSTOMER_STATUS? status = null);
        IList<Order> Search(IList<Order> orders, DateTime? start, DateTime? end, ORDER_STATUS? status = null);
        IList<Item> Search(IList<Item> items, string searchString = null, IList<ITEM_TYPE> types = null, decimal? priceFrom = null, decimal? priceTo = null, ITEM_STATUS? status = null);
        //sort
        IList<Customer> Sort(IList<Customer> arr, SORT_TYPE type = SORT_TYPE.ID, SORT_ORDER order = SORT_ORDER.ASCENDING);
        IList<Item> Sort(IList<Item> arr, SORT_TYPE type = SORT_TYPE.ID, SORT_ORDER order = SORT_ORDER.ASCENDING);
        IList<Order> Sort(IList<Order> arr, SORT_TYPE type = SORT_TYPE.ID, SORT_ORDER order = SORT_ORDER.ASCENDING);
    }
}