using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCore.Interfaces;
using AppCore.Models;
using Winform.DataTables;

namespace Winform.Dialogs
{
    public partial class AddItemRelationDialog : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        private ItemRelation _model = new ItemRelation();
        private IList<ItemRelation> _modifieds;
        private IList<ItemRelation> _relations;
        private int _selectedIndex = -1;
        private int _selectedItemId = 0;
        private IList<Item> _items;

        private void SetUpGridItem () {
            this.gridItem.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridItem.Columns["Id"].DisplayIndex = 0;
            this.gridItem.Columns["Id"].HeaderText = "ID";
            this.gridItem.Columns["Id"].Width = 30;

            this.gridItem.Columns["Name"].DisplayIndex = 1;
            this.gridItem.Columns["Name"].HeaderText = "Tên";

            this.gridItem.Columns["TypeName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridItem.Columns["TypeName"].DisplayIndex = 2;
            this.gridItem.Columns["TypeName"].HeaderText = "Loại";
            this.gridItem.Columns["TypeName"].Width = 150;

            this.gridItem.Columns["UnitPrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridItem.Columns["UnitPrice"].DisplayIndex = 3;
            this.gridItem.Columns["UnitPrice"].HeaderText = "Đơn giá";
            this.gridItem.Columns["UnitPrice"].Width = 120;
            this.gridItem.Columns["UnitPrice"].DefaultCellStyle.Format = "##,#";

            this.gridItem.Columns["Description"].DisplayIndex = 4;
            this.gridItem.Columns["Description"].HeaderText = "Mô tả";

        }
        private void LoadGridItem (int selectedIndex = -1) {
            TblItem tbl = new TblItem (_items, false, true);

            this.gridItem.DataSource = tbl;
            if (selectedIndex < 0) {
                this.gridItem.ClearSelection ();
            } else {
                this.gridItem.Rows[selectedIndex].Selected = true;
            }
        }
        public AddItemRelationDialog(IUnitOfWork unitOfWork, IList<ItemRelation> relations, IList<ItemRelation> modifieds)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _modifieds = modifieds;
            _relations = relations;
            _items = _unitOfWork.ItemRepos.GetAllNotCombo();
            var filter = _relations.Select(m => m.ChildId);
            _items = _items.Where(m => !filter.Contains(m.Id)).ToList();

            LoadGridItem();
            SetUpGridItem();
        }

        private void gridItem_SelectionChanged(object sender, EventArgs e)
        {
            if (this.gridItem.SelectedRows.Count > 0) {
                var row = this.gridItem.SelectedRows[0];
                _selectedIndex = row.Index;
                _selectedItemId = (Int32)row.Cells["Id"].Value;
                btnOk.Enabled = true;

            }
            else
            {
                btnOk.Enabled = false;
                _selectedIndex = -1;
                _selectedItemId = 0;
                _model = null;
            }
        }

        private void btnOk_Click (object sender, EventArgs e) {
            var amount = (int) this.numberAmount.Value;
            var check = MessageBox.Show ("Xác nhận số lượng nhập là " + amount + " ?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (check.Equals (DialogResult.Cancel)) return;

            _model = new ItemRelation(0, _selectedItemId, amount);
            _relations.Add(_model);
            var res = _modifieds.Where(m => m.ChildId.Equals(_model.ChildId));
            if (res.Any()) res.First().Amount = amount;
            else _modifieds.Add(_model);

            this.DialogResult = DialogResult.OK;
            this.Close ();
        }

        private void btnCancel_Click (object sender, EventArgs e) {
            var check = MessageBox.Show ("Hủy thao tác?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (check.Equals (DialogResult.Cancel)) return;

            this.DialogResult = DialogResult.Cancel;
            this.Close ();
        }
    }
}
