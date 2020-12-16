using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AppCore;
using AppCore.Models;

namespace Presentation.ViewModels.DataTables {
    class TblItem : DataTable {
        public TblItem () {
            this.Create ();
        }
        public TblItem (IList<Item> arr, bool comboView = false) {
            this.Create (comboView);
            this.Fill (arr, comboView);
        }

        public void Create (bool comboView = false) {
            this.Columns.Add ("Id", typeof (int));
            this.Columns.Add ("Name", typeof (string));
            this.Columns.Add ("TypeName", typeof (string));
            if (!comboView) this.Columns.Add ("InStock", typeof (int));
            this.Columns.Add ("UnitPrice", typeof (decimal));
            this.Columns.Add ("Description", typeof (string));
            this.Columns.Add ("Status", typeof (ITEM_STATUS));
            this.Columns.Add ("StatusName", typeof (string));
        }
        public void Fill (IList<Item> arr, bool comboView = false) {
            if (arr == null) return;
            foreach (var t in arr) {
                if (comboView) this.Rows.Add (t.Id, t.Name, t.TypeName, t.UnitPrice, t.Description, t.Status, "");
                else this.Rows.Add (t.Id, t.Name, t.TypeName, t.InStock, t.UnitPrice, t.Description, t.Status, "");
            }
        }

    }
}