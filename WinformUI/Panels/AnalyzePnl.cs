using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCore.Interfaces;
using AppCore.Services;
using AppCore.Services.ServiceModels;
using AppCore.Models;
using Winform.DataTables;

namespace Winform
{
    public partial class AnalyzePnl: UserControl
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISearchSortService _searchSortService;
        private readonly IAnalyzeService _analyzeService;

        private IList<StorageLog> _logs = null;
        private IList<StorageLog> _subLogs = null;
        private IList<StorageLog> _subLogSearch = null;
        private IList<Item> _items = null;
        private IList<Item> _itemSearch;
        private int _selectedIndex = -1;

        private void LoadCheckBoxType () {
            checkedTypeBox.Items.Clear ();

            checkedTypeBox.DataSource = ListEnum.GetListItemType();
            checkedTypeBox.DisplayMember = "TypeName";
            checkedTypeBox.ValueMember = "Type";

        }
        private void SetUpGridLog()
        {
            //this.gridLog.Columns["LogDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridLog.Columns["LogDate"].DisplayIndex = 0;
            this.gridLog.Columns["LogDate"].HeaderText = "Ngày";
            this.gridLog.Columns["LogDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

            this.gridLog.Columns["LogStock"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridLog.Columns["LogStock"].DisplayIndex = 1;
            this.gridLog.Columns["LogStock"].HeaderText = "Số tồn kho";
            this.gridLog.Columns["LogStock"].Width = 140;

            this.gridLog.Columns["ExportAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridLog.Columns["ExportAmount"].DisplayIndex = 2;
            this.gridLog.Columns["ExportAmount"].HeaderText = "Số lượng bán ra";
            this.gridLog.Columns["ExportAmount"].Width = 140;

            this.gridLog.Columns["ImportAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridLog.Columns["ImportAmount"].DisplayIndex = 3;
            this.gridLog.Columns["ImportAmount"].HeaderText = "Số lượng nhập vào";
            this.gridLog.Columns["ImportAmount"].Width = 140;
        }
        private void LoadGridLog (IList<StorageLog> arr) {
            TblStorageLog tbl = new TblStorageLog (_unitOfWork, arr);

            this.gridLog.DataSource = tbl;
            this.gridLog.ClearSelection ();
            this.SetUpGridLog ();

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

                this.gridItem.Columns["InStock"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                this.gridItem.Columns["InStock"].DisplayIndex = 3;
                this.gridItem.Columns["InStock"].HeaderText = "Tồn kho";
                this.gridItem.Columns["InStock"].Width = 100;
            

            this.gridItem.Columns["UnitPrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridItem.Columns["UnitPrice"].DisplayIndex = 4;
            this.gridItem.Columns["UnitPrice"].HeaderText = "Đơn giá";
            this.gridItem.Columns["UnitPrice"].Width = 120;
            this.gridItem.Columns["UnitPrice"].DefaultCellStyle.Format = "##,#";

            this.gridItem.Columns["Description"].DisplayIndex = 5;
            this.gridItem.Columns["Description"].HeaderText = "Mô tả";

            this.gridItem.Columns["StatusName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridItem.Columns["StatusName"].DisplayIndex = 6;
            this.gridItem.Columns["StatusName"].HeaderText = "Trạng thái";
            this.gridItem.Columns["StatusName"].Width = 50;

            this.gridItem.Columns["Status"].Visible = false;
        }
        private void LoadItemData () {
            _items = _unitOfWork.ItemRepos.GetAllNotCombo();
            _itemSearch = _items.ToList();
        }
        public void Reload()
        {
            LoadItemData();
            _logs = _analyzeService.Logs();
            LoadGridItem();
        }

        private void LoadGridItem (int selectedIndex = -1) {
            TblItem tbl = new TblItem (_itemSearch);

            this.gridItem.DataSource = tbl;
            if (selectedIndex < 0) {
                this.gridItem.ClearSelection ();
            } else {
                this.gridItem.Rows[selectedIndex].Selected = true;
            }
            SetUpGridItem ();
        }
        private void LoadItemInfo () {
            if (this.gridItem.SelectedRows.Count > 0) {
                var row = this.gridItem.SelectedRows[0];
                _selectedIndex = row.Index;

                var itemId = (Int32) row.Cells["Id"].Value;
                var item = _items.Where (m => m.Id.Equals (itemId)).First ();
                _subLogs = _analyzeService.CalculateLogStock(_logs, item);
                LoadGridLog(_subLogs);
            }
            else
            {
                _selectedIndex = -1;
                _subLogs = null;
                gridLog.DataSource = null;
            }
        }
        private void SearchItem () {
            var search = this.txtSearch.Text;
            var priceFrom = this.numberFrom.Value;
            var priceTo = this.numberTo.Value;
            var types = this.checkedTypeBox.CheckedItems.OfType<ItemType> ().Select (m => m.Type).ToList ();

            _itemSearch = _searchSortService.Search (_items, search, types, priceFrom, priceTo);
        }
        private void SearchLog () {
            DateTime dateFrom = dateStart.Value.Date;
            DateTime dateTo = dateEnd.Value.Date;

            _subLogSearch = _subLogSearch.Where(m => DateTime.Compare(m.LogDate.Date, dateFrom) >= 0 && DateTime.Compare(m.LogDate.Date, dateTo) <= 0).ToList();
        }
        public AnalyzePnl(IUnitOfWork unitOfWork, ISearchSortService searchSortService,  IAnalyzeService analyzeService)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            _unitOfWork = unitOfWork;
            _searchSortService = searchSortService;
            _analyzeService = analyzeService;
            _logs = _analyzeService.Logs();
            LoadCheckBoxType();
            LoadItemData();
            LoadGridItem();

            this.numberFrom.Minimum = 0;
            this.numberTo.Minimum = 0;
            this.numberFrom.Maximum = decimal.MaxValue;
            this.numberTo.Maximum = Decimal.MaxValue;
            this.numberTo.Value = 100000000;

            this.dateEnd.MinDate = this.dateStart.Value.Date;
        }

        private void gridItem_SelectionChanged(object sender, EventArgs e)
        {
            LoadItemInfo();
        }

        private void gridItem_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var index = e.RowIndex;
            var cell = gridItem.Rows[index].Cells["Status"];
            var subCell = gridItem.Rows[index].Cells["StatusName"];
            if (((ITEM_STATUS) cell.Value).Equals (ITEM_STATUS.ACTIVE)) subCell.Style.BackColor = Color.Green;
            else subCell.Style.BackColor = Color.Red;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadItemData ();
            this.SearchItem ();
            this.LoadGridItem ();
        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(dateStart.Value.Date, dateEnd.Value.Date) < 0)
            {
                this.dateEnd.MinDate = this.dateStart.Value.Date;
                //this.dateEnd.Value = this.dateStart.Value.Date;
            }
            else
            {
                this.dateEnd.Value = this.dateStart.Value.Date;
                this.dateEnd.MinDate = this.dateStart.Value.Date;
            }
        }

        private void btnSearchLog_Click(object sender, EventArgs e)
        {
            _subLogSearch = _subLogs.ToList();
            if (_subLogSearch == null) return;
            SearchLog();
            LoadGridLog(_subLogSearch);
        }
    }
}
