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
using Presentation.ViewModels.DataTables;

namespace Winform {
    public partial class ItemPnl : UserControl {
        private readonly IUnitOfWork _unitOfWork;

        private IList<Item> _items;
        private IList<Item> _itemSearch;
        private IList<ItemRelation> _relations;

        private int _selectedIndex = -1;
        private int _selectedSubIndex = -1;
        private bool _comboView = false;

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

            if (_comboView) this.gridItem.Columns["InStock"].Visible = false;
            else {
                this.gridItem.Columns["InStock"].DisplayIndex = 3;
                this.gridItem.Columns["InStock"].HeaderText = "Tồn kho";
            }

            this.gridItem.Columns["UnitPrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridItem.Columns["UnitPrice"].DisplayIndex = 3;
            this.gridItem.Columns["UnitPrice"].HeaderText = "Đơn giá";
            this.gridItem.Columns["UnitPrice"].Width = 120;
            this.gridItem.Columns["UnitPrice"].DefaultCellStyle.Format = "##,#";

            this.gridItem.Columns["Description"].DisplayIndex = 4;
            this.gridItem.Columns["Description"].HeaderText = "Mô tả";

            this.gridItem.Columns["StatusName"].DisplayIndex = 5;
            this.gridItem.Columns["StatusName"].HeaderText = "Trạng thái";
            this.gridItem.Columns["StatusName"].Width = 50;

            this.gridItem.Columns["Status"].Visible = false;
        }
        private void LoadItemData () {
            if (_comboView) _items = _unitOfWork.ItemRepos.GetAllCombo ();
            else _items = _unitOfWork.ItemRepos.GetAllNotCombo ();

            _itemSearch = _items.ToList ();
        }
        private void LoadGridItem (int selectedIndex = -1) {
            TblItem tbl = new TblItem (_itemSearch, _comboView);

            this.gridItem.DataSource = tbl;
            if (selectedIndex < 0) {
                this.gridItem.ClearSelection ();
                this.EnableItemButton (false);
            } else {
                this.gridItem.Rows[selectedIndex].Selected = true;

                this.SetUpGridItem ();
            }
        }
        private void LoadItemInfo () {
            if (this.gridItem.SelectedRows.Count > 0) {
                var row = this.gridItem.SelectedRows[0];
                _selectedIndex = row.Index;

                if ((ITEM_STATUS) row.Cells["Status"].Value == ITEM_STATUS.ACTIVE) {
                    btnChangeStatus.Text = "ẨN";
                    this.EnableItemButton (true);
                } else {
                    btnChangeStatus.Text = "KÍCH HOẠT";
                    this.EnableItemButton (true);
                }

                var itemId = (Int32) row.Cells["Id"].Value;
                var subItems = _items.Where (m => m.Id.Equals (itemId)).First ().ConsistOf;
                // this.LoadTourDetailGridView (dets);
                // var groups = _unitOfWork.Tours.GetGroupsByTourId (tourId);
                // this.LoadGroupGridView (groups);
                // this.SetUpGroupGridView ();
            } else {
                this.gridSubItem.DataSource = null;
                this.EnableSubItemButton (false);
            }
        }
        private void EnableItemButton (bool b) {
            btnChangeStatus.Enabled = b;
            btnEdit.Enabled = b;
            if (_comboView) {
                btnDelete.Enabled = b;
                btnAddRelation.Enabled = b;
            }
        }
        private void EnableSubItemButton (bool b) {
            if (_comboView) {
                btnDeleteRelation.Enabled = b;
                btnEditRelation.Enabled = b;
            }
        }

        public ItemPnl (IUnitOfWork unitOfWork) {
            InitializeComponent ();
            this.Dock = DockStyle.Fill;

            _unitOfWork = unitOfWork;
            LoadItemData ();
            LoadGridItem ();
            SetUpGridItem ();

            this.numberFrom.Minimum = 0;
            this.numberTo.Minimum = 0;
            this.numberFrom.Maximum = decimal.MaxValue;
            this.numberTo.Maximum = Decimal.MaxValue;
            this.numberTo.Value = 100000000;
        }

        private void gridItem_RowPrePaint (object sender, DataGridViewRowPrePaintEventArgs e) {
            var index = e.RowIndex;
            var cell = gridItem.Rows[index].Cells["Status"];
            var subCell = gridItem.Rows[index].Cells["StatusName"];
            if (cell.Value.ToString ().Equals (ITEM_STATUS.ACTIVE)) subCell.Style.BackColor = Color.Green;
            else subCell.Style.BackColor = Color.Red;
        }

        private void radItem_CheckedChanged (object sender, EventArgs e) {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked) {
                _comboView = false;
            } else {
                _comboView = true;

            }
            showSubItem (_comboView);
            LoadItemData ();
            LoadGridItem ();
        }
        private void showSubItem (bool b) {
            this.btnDelete.Visible = b;
            this.groupSubItem.Visible = b;

            this.btnAddRelation.Visible = b;
            this.btnDeleteRelation.Visible = b;
            this.btnEditRelation.Visible = b;
        }

        private void gridItem_SelectionChanged (object sender, EventArgs e) {
            LoadItemInfo ();
        }

        private void gridSubItem_SelectionChanged (object sender, EventArgs e) {

        }
    }
}