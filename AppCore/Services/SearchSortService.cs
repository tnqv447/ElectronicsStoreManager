using System.Collections.Generic;
using System.Linq;
using AppCore.Interfaces;
using AppCore.Models;

namespace AppCore.Services
{
    public class SearchSortService : ISearchSortService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SearchSortService (IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        //search

        //sort
        public IList<Customer> Sort(IList<Customer> arr, SORT_TYPE type = SORT_TYPE.ID, SORT_ORDER order = SORT_ORDER.ASCENDING){
            switch (type)
            {
                case SORT_TYPE.NAME:
                    arr = arr.OrderBy(m => m.Name).ToList();
                    break;
                case SORT_TYPE.STATUS:
                    arr = arr.OrderBy(m => m.Status).ToList();
                    break;
                case SORT_TYPE.SEX:
                    arr = arr.OrderBy(m => m.Sex).ToList();
                    break;
                default:
                    arr = arr.OrderBy(m => m.Id).ToList();
                    break;
            }
            if (order.Equals(SORT_ORDER.DESCENDING)) arr = arr.Reverse().ToList();
            return arr;
        }

        public IList<Item> Sort(IList<Item> arr, SORT_TYPE type = SORT_TYPE.ID, SORT_ORDER order = SORT_ORDER.ASCENDING){
            switch (type)
            {
                case SORT_TYPE.NAME:
                    arr = arr.OrderBy(m => m.Name).ToList();
                    break;
                case SORT_TYPE.STATUS:
                    arr = arr.OrderBy(m => m.Status).ToList();
                    break;
                case SORT_TYPE.UNIT_PRICE:
                    arr = arr.OrderBy(m => m.UnitPrice).ToList();
                    break;
                default:
                    arr = arr.OrderBy(m => m.Id).ToList();
                    break;
            }
            if (order.Equals(SORT_ORDER.DESCENDING)) arr = arr.Reverse().ToList();
            return arr;
        }

        public IList<Order> Sort(IList<Order> arr, SORT_TYPE type = SORT_TYPE.ID, SORT_ORDER order = SORT_ORDER.ASCENDING){
            switch (type)
            {
                case SORT_TYPE.STATUS:
                    arr = arr.OrderBy(m => m.Status).ToList();
                    break;
                case SORT_TYPE.SUM_PRICE:
                    arr = arr.OrderBy(m => m.SumPrice).ToList();
                    break;
                case SORT_TYPE.ORDER_DATE:
                    arr = arr.OrderBy(m => m.OrderDate).ToList();
                    break;
                default:
                    arr = arr.OrderBy(m => m.Id).ToList();
                    break;
            }
            if (order.Equals(SORT_ORDER.DESCENDING)) arr = arr.Reverse().ToList();
            return arr;
        }
    }
}