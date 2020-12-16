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
using AppCore.Services;
using Presentation.ViewModels.DataTables;

namespace Winform {
    public partial class ItemPnl : UserControl {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISearchSortService _searchSortService;

        private IList<Item> _items;
        private IList<Item> _itemSearch;
        private IList<ItemType> _types;

        private int _selectedIndex = -1;
        private bool _comboView = false;
        
        // private void LoadComboItemType()
        // {
        //     comboType.Items.Clear();

        //     comboType.DisplayMember = "TypeName";
        //     comboType.ValueMember = "Type";
        //     comboType.DataSource = _types;
        // }
        private void LoadCheckBoxType()
        {
            checkedTypeBox.Items.Clear();
            
            checkedTypeBox.DataSource = _types;
            checkedTypeBox.DisplayMember = "TypeName";
            checkedTypeBox.ValueMember = "Type";
            
        }
         private void SetUpGridSubItem () {
            this.gridSubItem.Columns["ChildId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridSubItem.Columns["ChildId"].DisplayIndex = 0;
            this.gridSubItem.Columns["ChildId"].HeaderText = "ID";
            this.gridSubItem.Columns["ChildId"].Width = 30;

            this.gridSubItem.Columns["ChildName"].DisplayIndex = 1;
            this.gridSubItem.Columns["ChildName"].HeaderText = "Tên";

            this.gridSubItem.Columns["TypeName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridSubItem.Columns["TypeName"].DisplayIndex = 2;
            this.gridSubItem.Columns["TypeName"].HeaderText = "Loại";
            this.gridSubItem.Columns["TypeName"].Width = 150;

            this.gridSubItem.Columns["UnitPrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridSubItem.Columns["UnitPrice"].DisplayIndex = 3;
            this.gridSubItem.Columns["UnitPrice"].HeaderText = "Số lượng";
            this.gridSubItem.Columns["UnitPrice"].Width = 120;

            this.gridSubItem.Columns["UnitPrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridSubItem.Columns["UnitPrice"].DisplayIndex = 4;
            this.gridSubItem.Columns["UnitPrice"].HeaderText = "Đơn giá";
            this.gridSubItem.Columns["UnitPrice"].Width = 120;
            this.gridSubItem.Columns["UnitPrice"].DefaultCellStyle.Format = "##,#";
        }
        private void LoadGridSubItem (IList<ItemRelation> relations) {
            TblItemRelation tbl = new TblItemRelation (relations);

            this.gridSubItem.DataSource = tbl;
            this.gridSubItem.ClearSelection ();
            this.SetUpGridSubItem ();
            
        }
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

            if (!_comboView) {
                this.gridItem.Columns["InStock"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                this.gridItem.Columns["InStock"].DisplayIndex = 3;
                this.gridItem.Columns["InStock"].HeaderText = "Tồn kho";
                this.gridItem.Columns["InStock"].Width = 100;
            }

            this.gridItem.Columns["IsOutOfStock"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridItem.Columns["IsOutOfStock"].DisplayIndex = 4;
            this.gridItem.Columns["IsOutOfStock"].HeaderText = "Hết hàng";
            this.gridItem.Columns["IsOutOfStock"].Width = 50;

            this.gridItem.Columns["UnitPrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridItem.Columns["UnitPrice"].DisplayIndex = 5;
            this.gridItem.Columns["UnitPrice"].HeaderText = "Đơn giá";
            this.gridItem.Columns["UnitPrice"].Width = 120;
            this.gridItem.Columns["UnitPrice"].DefaultCellStyle.Format = "##,#";

            this.gridItem.Columns["Description"].DisplayIndex = 6;
            this.gridItem.Columns["Description"].HeaderText = "Mô tả";

            this.gridItem.Columns["StatusName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridItem.Columns["StatusName"].DisplayIndex = 7;
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
                
            }
            this.SetUpGridItem ();
            
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
                var item = _items.Where(m => m.Id.Equals(itemId)).First();
                var subItems = item.ConsistOf;
                LoadModel(item);
                LoadGridSubItem(subItems);
            } else {
                LoadModel(null);
                this.gridSubItem.DataSource = null;
                this.EnableSubItemButton (false);
            }
        }
        private void LoadModel(Item item){
            if(item is null){
                this.txtId.Text = "";
                this.txtName.Text = "";
                this.txtType.Text = "";
                if(!_comboView){
                    this.txtInStock.Text = "";
                }
                checkIsOutOfStock.Checked = false;

                this.txtUnitPrice.Text = "";
                this.txtDescription.Text = "";
                return;
            }
            this.txtId.Text = item.Id.ToString();
            this.txtName.Text = item.Name;
            this.txtType.Text = item.TypeName;
            if(!_comboView){
                this.txtInStock.Text = item.InStock.ToString();
            }
            if(item.IsOutOfStock) this.checkIsOutOfStock.Checked = true;
            else checkIsOutOfStock.Checked = false;

            this.txtUnitPrice.Text = item.UnitPrice.ToString("#,##0.00");
            this.txtDescription.Text = item.Description;
        }
        private void EnableItemButton (bool b) {
            btnChangeStatus.Enabled = b;
            btnEdit.Enabled = b;
            btnImport.Enabled = b;
        }
        private void EnableSubItemButton (bool b) {
            
        }
        private void SearchItem()
        {
            var search = this.txtSearch.Text;
            var priceFrom = this.numberFrom.Value;
            var priceTo = this.numberTo.Value;
            var types = this.checkedTypeBox.CheckedItems.OfType<ItemType>().Select(m => m.Type).ToList();
            MessageBox.Show(priceFrom + " " + priceTo);

            _itemSearch = _searchSortService.Search(_items, search, types, priceFrom, priceTo);
        }

        public ItemPnl (IUnitOfWork unitOfWork, ISearchSortService searchSortService) {
            InitializeComponent ();
            this.Dock = DockStyle.Fill;

            _unitOfWork = unitOfWork;
            _searchSortService = searchSortService;
            _types = ListEnum.GetListItemType();
            LoadCheckBoxType();
            LoadItemData ();
            LoadGridItem ();
            //SetUpGridItem ();

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
            if (((ITEM_STATUS)cell.Value).Equals (ITEM_STATUS.ACTIVE)) subCell.Style.BackColor = Color.Green;
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
            this.groupSubItem.Visible = b;
            this.lblStock.Visible = b;
            this.txtInStock.Visible = b;
        }

        private void gridItem_SelectionChanged (object sender, EventArgs e) {
            LoadItemInfo ();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadItemData();
            this.SearchItem();
            this.LoadGridItem();
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            var toShow = btnChangeStatus.Text.Equals("ẨN") ? false : true;
            DialogResult check;
            string temp = _comboView ? "combo" : "sản phẩm";
            if (toShow)
            {
                check = MessageBox.Show("Kích hoạt " + temp + " này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else check = MessageBox.Show("Ẩn "+ temp +" này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(check == DialogResult.Yes)
            {
                var row = gridItem.Rows[_selectedIndex];
                var item = _unitOfWork.ItemRepos.GetBy(Int32.Parse(row.Cells[0].Value.ToString()));

                if (!toShow)
                {
                    _unitOfWork.ItemRepos.Disable(item);
                }
                else
                {
                    _unitOfWork.ItemRepos.Activate(item);
                }

                LoadItemData();
                this.SearchItem();
                this.LoadGridItem(_selectedIndex);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}