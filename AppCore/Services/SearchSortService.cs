using System;
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
        public IList<Customer> Search(IList<Customer> customers, string searchString = null, SEX? sex = null, CUSTOMER_STATUS? status = null)
        {
            var arr = customers.ToList();
            if (status.HasValue)
            {
                arr = arr.Where(m => m.Status.Equals(status.Value)).ToList();
            }
            if(sex.HasValue){
                arr = arr.Where(m => m.Sex.Equals(sex.Value)).ToList();
            }
            if(!(searchString is null)){
                arr = arr.Where(m => m.Name.Contains(searchString.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return arr;
        }
        
        public IList<Order> Search(IList<Order> orders, DateTime? start, DateTime? end, ORDER_STATUS? status = null)
        {
            var arr = orders.ToList();
            if (status.HasValue)
            {
                arr = arr.Where(m => m.Status.Equals(status.Value)).ToList();
            }
            if(start.HasValue || end.HasValue){
                var tempStart = new DateTime();
                var tempEnd = new DateTime();

                if(start.HasValue)  tempStart = start.Value.Date;
                else tempStart = DateTime.MinValue.Date;
                if(end.HasValue)  tempEnd = end.Value.Date;
                else tempEnd = DateTime.MaxValue.Date;

                arr = arr.Where(m => DateTime.Compare(m.OrderDate, tempStart) >= 0 && DateTime.Compare(m.OrderDate, tempEnd) <= 0).ToList();
            }
            return arr;
        }
        public IList<Item> Search(IList<Item> items, string searchString = null, IList<ITEM_TYPE> types = null,decimal? priceFrom= null, decimal? priceTo = null, ITEM_STATUS? status = null)
        {
            var arr = items.ToList();
            if (status.HasValue)
            {
                arr = arr.Where(m => m.Status.Equals(status.Value)).ToList();
            }
            if(priceFrom.HasValue || priceTo.HasValue){
                var tempStart = new decimal(0);
                var tempEnd = new decimal(10000000000);

                if(priceFrom.HasValue)  tempStart = priceFrom.Value;
                
                if(priceTo.HasValue)  tempEnd = priceTo.Value;
            

                arr = arr.Where(m => m.UnitPrice >= tempStart && m.UnitPrice <= tempEnd).ToList();
            }
            if(!(types is null) && types.Count != 0){
                arr = arr.Where(m => !m.GetComboType().Except(types).Any()).ToList();
            }
            
            if(!(searchString is null)){
                arr = arr.Where(m => m.Name.Contains(searchString.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return arr;
        }


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