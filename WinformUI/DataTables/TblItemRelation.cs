using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AppCore;
using AppCore.Interfaces;
using AppCore.Models;

namespace Winform.DataTables {
    class TblItemRelation : DataTable {
        private readonly IUnitOfWork _unit;
        public TblItemRelation () {
            this.Create ();
        }
        public TblItemRelation (IUnitOfWork unit, IList<ItemRelation> arr) {
            this.Create ();
            this.Fill (arr);
            _unit = unit;
        }

        public void Create (bool comboView = false, bool simple = false) {  
            this.Columns.Add ("ChildId", typeof (int));
            this.Columns.Add ("ChildName", typeof (string));
            this.Columns.Add ("TypeName", typeof (string));
            this.Columns.Add("Amount", typeof(int));
            this.Columns.Add ("UnitPrice", typeof (decimal));
                
            
        }
        public void Fill (IList<ItemRelation> arr) {
            if (arr == null) return;
            foreach (var t in arr) {
                Item child = null;
                if (t.Child is null) child = _unit.ItemRepos.GetBy(t.ChildId);
                else child = t.Child;
                this.Rows.Add(t.ChildId, child.Name, child.TypeName, t.Amount, child.UnitPrice);
            }
        }

    }
}