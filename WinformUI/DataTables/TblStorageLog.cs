using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AppCore;
using AppCore.Interfaces;
using AppCore.Models;
using AppCore.Services.ServiceModels;

namespace Winform.DataTables {
    class TblStorageLog : DataTable {
        private readonly IUnitOfWork _unit;
        public TblStorageLog () {
            this.Create ();
        }
        public TblStorageLog(IUnitOfWork unit, IList<StorageLog> arr)
        {
            _unit = unit;
            this.Create ();
            this.Fill (arr);
            
        }

        public void Create(bool comboView = false, bool simple = false)
        {
            this.Columns.Add("LogDate", typeof(DateTime));
            this.Columns.Add ("LogStock", typeof (int));
            this.Columns.Add("ExportAmount", typeof(int));
            this.Columns.Add ("ImportAmount", typeof (int));

        }
        public void Fill (IList<StorageLog> arr) {
            if (arr == null || arr.Count == 0) return;
            foreach (var t in arr)
            {
                this.Rows.Add(t.LogDate, t.LogStock, t.ExportAmount.HasValue?t.ExportAmount.Value:0, t.ImportAmount.HasValue?t.ImportAmount.Value:0);
            }
        }

    }
}