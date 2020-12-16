using System;
using System.Collections.Generic;
using AppCore.Interfaces;
using AppCore.Models;
using AppCore.Services.ServiceModels;
using System.Linq;

namespace AppCore.Services
{
    public class AnalyzeService : IAnalyzeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderService _orderService;
        public AnalyzeService(IUnitOfWork unitOfWork, IOrderService orderService)
        {
            _unitOfWork = unitOfWork;
            _orderService = orderService;
        }

        public IList<StorageLog> Logs()
        {///  from to date
            var stores = _orderService.GetAllStorageChecker();
            var imports = _unitOfWork.ImportRepos.GetAll()
                .GroupBy(m => new { m.ItemId, m.ImportDate.Date })
                .Select(o => new Import(o.First().ItemId, o.Sum(m => m.Amount), o.First().ImportDate.Date));

            var list = new List<StorageLog>();
            var leftJoin =
                from m in stores
                join o in imports on new { m.ItemId, m.OrderDate.Date } equals new { o.ItemId, o.ImportDate.Date } into temp
                from o in temp.DefaultIfEmpty()
                select new StorageLog(m.ItemId, m.OrderDate.Date, m.Amount, o?.Amount, 0);
            var rightJoin =
                from o in imports
                join m in stores on new { o.ItemId, o.ImportDate.Date } equals new { m.ItemId, m.OrderDate.Date } into temp
                from m in temp.DefaultIfEmpty()
                select new StorageLog(o.ItemId, o.ImportDate.Date, m?.Amount, o.Amount, 0);
            list = leftJoin.Union(rightJoin).ToList();
            return list;
        }

        public IList<StorageLog> CalculateLogStock(IList<StorageLog> logs, Item item)
        {
            var arr = logs.Where(m => m.ItemId.Equals(item.Id)).OrderByDescending(m => m.LogDate.Date).ToList();
            var currentStock = 0 + item.InStock;
            foreach (StorageLog log in arr)
            {
                log.LogStock = currentStock;
                if (log.ExportAmount.HasValue) log.LogStock += log.ExportAmount.Value;
                if (log.ImportAmount.HasValue) log.LogStock -= log.ImportAmount.Value;
                currentStock = log.LogStock;
            }
            return arr;
        }
    }
}