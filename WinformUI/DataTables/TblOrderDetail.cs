using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AppCore;
using AppCore.Interfaces;
using AppCore.Models;

namespace Winform.DataTables {
    class TblOrderDetail : DataTable {
        private readonly IUnitOfWork _unit;
        public TblOrderDetail () {
            this.Create ();
        }
        public TblOrderDetail(IUnitOfWork unit, IList<OrderDetail> arr)
        {
            _unit = unit;
            this.Create ();
            this.Fill (arr);
            
        }

        public void Create (bool comboView = false, bool simple = false) {  
            this.Columns.Add ("ItemId", typeof (int));
            this.Columns.Add ("ItemName", typeof (string));
            this.Columns.Add ("TypeName", typeof (string));
            this.Columns.Add ("UnitPrice", typeof (decimal));
            this.Columns.Add ("Amount", typeof (int));     
            
        }
        public void Fill (IList<OrderDetail> arr) {
            if (arr == null) return;
            foreach (var t in arr) {
                this.Rows.Add(t.ItemId, t.ItemName, t.Item.TypeName, t.ItemUnitPrice, t.Amount);
            }
        }

    }
}