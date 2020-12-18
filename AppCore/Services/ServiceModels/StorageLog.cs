using System;

namespace AppCore.Services.ServiceModels
{
    public class StorageLog
    {
        public StorageLog()
        {
        }

        public int ItemId { get; set; }
        public DateTime LogDate { get; set; }
        public int? ExportAmount { get; set; }
        public int? ImportAmount { get; set; }
        public int LogStock { get; set; }

        public StorageLog(int itemId, DateTime logDate, int? exportAmount, int? importAmount, int logStock)
        {
            ItemId = itemId;
            LogDate = logDate;
            ExportAmount = exportAmount;
            ImportAmount = importAmount;
            LogStock = logStock;
        }
        public StorageLog(StorageLog log) { this.Copy(log); }
        public void Copy(StorageLog log)
        {
            ItemId = log.ItemId;
            LogDate = log.LogDate;
            ExportAmount = log.ExportAmount;
            ImportAmount = log.ImportAmount;
            LogStock = log.LogStock;

        }
    }
}