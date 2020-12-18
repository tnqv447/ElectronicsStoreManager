using System.Collections.Generic;
using AppCore.Models;
using AppCore.Services.ServiceModels;

namespace AppCore.Services
{
    public interface IAnalyzeService
    {
        IList<StorageLog> Logs();
        IList<StorageLog> CalculateLogStock(IList<StorageLog> logs, Item item);
    }
}