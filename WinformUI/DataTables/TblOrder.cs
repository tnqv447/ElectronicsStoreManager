using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AppCore;
using AppCore.Interfaces;
using AppCore.Models;

namespace Winform.DataTables {
    class TblOrder : DataTable {
        private readonly IUnitOfWork _unit;
        public TblOrder () {
            this.Create ();
        }
        public TblOrder(IUnitOfWork unit, IList<Order> arr)
        {
            _unit = unit;
            this.Create ();
            this.Fill (arr);
            
        }

        public void Create(bool comboView = false, bool simple = false)
        {
            this.Columns.Add ("Id", typeof (int));
            this.Columns.Add ("OrderDate", typeof (DateTime));
            this.Columns.Add("CustomerName", typeof(string));
            this.Columns.Add ("SumPrice", typeof (decimal));
            this.Columns.Add ("PhoneNumber", typeof (string));
            this.Columns.Add("Address", typeof(string));
            this.Columns.Add("Status", typeof(ORDER_STATUS));
            this.Columns.Add("StatusName", typeof(string));

        }
        public void Fill (IList<Order> arr) {
            if (arr == null || arr.Count == 0) return;
            foreach (var t in arr) {
                this.Rows.Add(t.Id, t.OrderDate.Date, t.Customer.Name, t.SumPrice, t.PhoneNumber, t.Address, t.Status, t.StatusName);
            }
        }

    }
}