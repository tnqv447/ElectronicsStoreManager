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
    public partial class ShowImportDialog : Form
    {
        private readonly IUnitOfWork _unitOfWork;

        private IList<Import> _imports = new List<Import>();
        private IList<Import> _importSearch = new List<Import>();
        private void SetUpGridImport()
        {
            this.gridImport.Columns["ImportDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridImport.Columns["ImportDate"].DisplayIndex = 0;
            this.gridImport.Columns["ImportDate"].HeaderText = "Ngày nhập";
            this.gridImport.Columns["ImportDate"].Width = 120;
            this.gridImport.Columns["ImportDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

            this.gridImport.Columns["ItemName"].DisplayIndex = 1;
            this.gridImport.Columns["ItemName"].HeaderText = "Tên hàng";

            this.gridImport.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridImport.Columns["Amount"].DisplayIndex = 2;
            this.gridImport.Columns["Amount"].HeaderText = "Số lượng";
            this.gridImport.Columns["Amount"].Width = 120;

        }
        private void LoadImportData()
        {
            var _imports = _unitOfWork.ImportRepos.GetAll()
                .GroupBy(m => new { m.ItemId, m.ImportDate.Date })
                .Select(o => new Import(o.First().ItemId, o.Sum(m => m.Amount), o.First().ImportDate.Date));
            _importSearch = _imports.ToList();
        }
        public void Reload()
        {
            LoadImportData();
            LoadGridImport();
        }

        private void LoadGridImport(int selectedIndex = -1)
        {
            TblImport tbl = new TblImport(_unitOfWork, _importSearch);
            this.gridImport.DataSource = tbl;
            if (selectedIndex < 0)
            {
                this.gridImport.ClearSelection();
            }
            else
            {
                this.gridImport.Rows[selectedIndex].Selected = true;
            }
            SetUpGridImport();
        }
        private void SearchImport()
        {
            DateTime dateFrom = dateStart.Value.Date;
            DateTime dateTo = dateEnd.Value.Date;

            _importSearch = _importSearch.Where(m => DateTime.Compare(m.ImportDate.Date, dateFrom) >= 0 && DateTime.Compare(m.ImportDate.Date, dateTo) <= 0).ToList();
        }
        public ShowImportDialog(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            LoadImportData();
            LoadGridImport();

            this.dateEnd.MinDate = dateStart.Value.Date;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadImportData();
            SearchImport();
            LoadGridImport();
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
    }
}
