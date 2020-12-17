using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AppCore;
using AppCore.Models;

namespace Winform.DataTables {
    class TblItem : DataTable {
        public TblItem () {
            this.Create ();
        }
        public TblItem (IList<Item> arr, bool comboView = false, bool simple = false) {
            this.Create (comboView, simple);
            this.Fill (arr, comboView, simple);
        }

        public void Create (bool comboView = false, bool simple = false) {
            if(simple){
                this.Columns.Add ("Id", typeof (int));
                this.Columns.Add ("Name", typeof (string));
                this.Columns.Add ("TypeName", typeof (string));
                this.Columns.Add ("UnitPrice", typeof (decimal));
                this.Columns.Add ("Description", typeof (string));
            }
            else{
                this.Columns.Add ("Id", typeof (int));
                this.Columns.Add ("Name", typeof (string));
                this.Columns.Add ("TypeName", typeof (string));
                if (!comboView) this.Columns.Add ("InStock", typeof (int));
                this.Columns.Add ("UnitPrice", typeof (decimal));
                this.Columns.Add ("Description", typeof (string));
                this.Columns.Add ("Status", typeof (ITEM_STATUS));
                this.Columns.Add ("StatusName", typeof (string));
            }
            
        }
        public void Fill (IList<Item> arr, bool comboView = false, bool simple = false) {
            if (arr == null) return;
            foreach (var t in arr) {
                if(simple){
                    this.Rows.Add(t.Id, t.Name, t.TypeName, t.UnitPrice, t.Description);
                }
                if (comboView) this.Rows.Add (t.Id, t.Name, t.TypeName, t.UnitPrice, t.Description, t.Status, "");
                else this.Rows.Add (t.Id, t.Name, t.TypeName, t.InStock,  t.UnitPrice, t.Description, t.Status, "");
            }
        }

    }
}