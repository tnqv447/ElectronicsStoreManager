using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AppCore;
using AppCore.Interfaces;
using AppCore.Models;

namespace Winform.DataTables {
    class TblImport : DataTable {
        private readonly IUnitOfWork _unit;
        public TblImport () {
            this.Create ();
        }
        public TblImport(IUnitOfWork unit, IList<Import> arr)
        {
            _unit = unit;
            this.Create ();
            this.Fill (arr);
            
        }

        public void Create(bool comboView = false, bool simple = false)
        {
            this.Columns.Add ("ImportDate", typeof (DateTime));
            this.Columns.Add("ItemName", typeof(string));
            this.Columns.Add ("Amount", typeof (int));

        }
        public void Fill (IList<Import> arr) {
            if (arr == null || arr.Count == 0) return;
            foreach (var t in arr) {
                this.Rows.Add(t.ImportDate.Date, t.Item.Name, t.Amount);
            }
        }

    }
}