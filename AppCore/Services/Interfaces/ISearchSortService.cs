using System.Collections.Generic;
using AppCore.Models;

namespace AppCore.Services
{
    public interface ISearchSortService
    {
        //sort
        IList<Customer> Sort(IList<Customer> arr, SORT_TYPE type = SORT_TYPE.ID, SORT_ORDER order = SORT_ORDER.ASCENDING);
        IList<Item> Sort(IList<Item> arr, SORT_TYPE type = SORT_TYPE.ID, SORT_ORDER order = SORT_ORDER.ASCENDING);
        IList<Order> Sort(IList<Order> arr, SORT_TYPE type = SORT_TYPE.ID, SORT_ORDER order = SORT_ORDER.ASCENDING);
    }
}