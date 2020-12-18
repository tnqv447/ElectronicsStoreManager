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
using AppCore.Models;
using Winform.DataTables;

namespace Winform
{
    public partial class OrderPnl: UserControl
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISearchSortService _searchSortService;
        private readonly IOrderService _orderService;

        private IList<Order> _orders;
        private IList<Order> _orderSearch;
        private IList<OrderStatus> _statuses;
        private Order _model = null;

        private int _selectedIndex = -1;

        private void LoadComboStatus () {
            this.comboStatus.Items.Clear ();

            comboStatus.DataSource = _statuses;
            comboStatus.DisplayMember = "StatusName";
            comboStatus.ValueMember = "Status";

        }
        private void SetUpGridOrderDetail () {
            this.gridOrderDetail.Columns["ItemId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridOrderDetail.Columns["ItemId"].DisplayIndex = 0;
            this.gridOrderDetail.Columns["ItemId"].HeaderText = "ID";
            this.gridOrderDetail.Columns["ItemId"].Width = 30;

            this.gridOrderDetail.Columns["ItemName"].DisplayIndex = 1;
            this.gridOrderDetail.Columns["ItemName"].HeaderText = "Tên";

            this.gridOrderDetail.Columns["TypeName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridOrderDetail.Columns["TypeName"].DisplayIndex = 2;
            this.gridOrderDetail.Columns["TypeName"].HeaderText = "Loại";
            this.gridOrderDetail.Columns["TypeName"].Width = 150;

            this.gridOrderDetail.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridOrderDetail.Columns["Amount"].DisplayIndex = 3;
            this.gridOrderDetail.Columns["Amount"].HeaderText = "Số lượng";
            this.gridOrderDetail.Columns["Amount"].Width = 80;
            
            this.gridOrderDetail.Columns["UnitPrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridOrderDetail.Columns["UnitPrice"].DisplayIndex = 4;
            this.gridOrderDetail.Columns["UnitPrice"].HeaderText = "Đơn giá";
            this.gridOrderDetail.Columns["UnitPrice"].Width = 120;
            this.gridOrderDetail.Columns["UnitPrice"].DefaultCellStyle.Format = "##,#";
        }
        private void LoadGridOrderDetail (IList<OrderDetail> details) {
            TblOrderDetail tbl = new TblOrderDetail (_unitOfWork, details);

            this.gridOrderDetail.DataSource = tbl;
            this.gridOrderDetail.ClearSelection ();
            this.SetUpGridOrderDetail ();

        }
        private void SetUpGridOrder()
        {
            this.gridOrder.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridOrder.Columns["Id"].DisplayIndex = 0;
            this.gridOrder.Columns["Id"].HeaderText = "ID";
            this.gridOrder.Columns["Id"].Width = 30;

            this.gridOrder.Columns["OrderDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridOrder.Columns["OrderDate"].DisplayIndex = 1;
            this.gridOrder.Columns["OrderDate"].HeaderText = "Ngày đặt";
            this.gridOrder.Columns["OrderDate"].Width = 120;
            this.gridOrder.Columns["OrderDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

            this.gridOrder.Columns["CustomerName"].DisplayIndex = 2;
            this.gridOrder.Columns["CustomerName"].HeaderText = "Tên khách hàng";

            this.gridOrder.Columns["SumPrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridOrder.Columns["SumPrice"].DisplayIndex = 3;
            this.gridOrder.Columns["SumPrice"].HeaderText = "Đơn giá";
            this.gridOrder.Columns["SumPrice"].Width = 120;
            this.gridOrder.Columns["SumPrice"].DefaultCellStyle.Format = "##,#";

            this.gridOrder.Columns["PhoneNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridOrder.Columns["PhoneNumber"].DisplayIndex = 4;
            this.gridOrder.Columns["PhoneNumber"].HeaderText = "SĐT";
            this.gridOrder.Columns["PhoneNumber"].Width = 150;

            this.gridOrder.Columns["Address"].DisplayIndex = 5;
            this.gridOrder.Columns["Address"].HeaderText = "Địa chỉ";

            this.gridOrder.Columns["StatusName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridOrder.Columns["StatusName"].DisplayIndex = 6;
            this.gridOrder.Columns["StatusName"].HeaderText = "Trạng thái";
            this.gridOrder.Columns["StatusName"].Width = 180;

            this.gridOrder.Columns["Status"].Visible = false;
        }
        private void LoadOrderData () {
            _orders = _unitOfWork.OrderRepos.GetAll();
            _orderSearch = _orders.ToList ();
        }
        public void Reload()
        {
            LoadOrderData();
            LoadGridOrder();
        }

        private void LoadGridOrder (int selectedIndex = -1) {
            TblOrder tbl = new TblOrder (_unitOfWork, _orderSearch);
            this.gridOrder.DataSource = tbl;
            if (selectedIndex < 0) {
                this.gridOrder.ClearSelection();
                this.EnableOrderButton (false);
            } else {
                this.gridOrder.Rows[selectedIndex].Selected = true;
            }
            SetUpGridOrder ();
        }
        private void EnableOrderButton (bool b) {
            this.btnCancel.Enabled = b; 
            this.btnComplete.Enabled = b; 
            this.btnCheck.Enabled = b;
            if (!b)
            {
                btnComplete.Text = "BẮT ĐẦU SHIP";
            }
        }
        private void LoadOrderInfo()
        {
            if (this.gridOrder.SelectedRows.Count > 0) {
                var row = this.gridOrder.SelectedRows[0];
                _selectedIndex = row.Index;
                var status = (ORDER_STATUS)row.Cells["Status"].Value;
                if (status.Equals(ORDER_STATUS.CANCELLED)
                    || status.Equals(ORDER_STATUS.CANCELLED_DELIVERY)
                    || status.Equals(ORDER_STATUS.DELIVERED))
                {
                    this.EnableOrderButton(false);
                }
                else if (status == ORDER_STATUS.NEW) {
                    btnCheck.Enabled = true;
                    btnComplete.Text = "BẮT ĐẦU SHIP";
                    btnComplete.Enabled = false;
                    btnCancel.Enabled = true;
                } else {
                    btnCheck.Enabled = false;
                    if (status.Equals(ORDER_STATUS.CHECKED)) btnComplete.Text = "BẮT ĐẦU SHIP";
                    else btnComplete.Text = "XÁC NHẬN ĐÃ SHIP";
                    btnComplete.Enabled = true;
                    btnCancel.Enabled = true;
                }

                var orderId = (Int32) row.Cells["Id"].Value;
                _model = _orders.Where (m => m.Id.Equals (orderId)).First ();

                var details = _model.OrderDetails;
                LoadGridOrderDetail(details);
            }
            else
            {
                _selectedIndex = -1;
                _model = null;
                gridOrderDetail.DataSource = null;
                this.EnableOrderButton (false);
            }
        }
        private void SearchOrder () {
            DateTime dateFrom = dateStart.Value.Date;
            DateTime dateTo = dateEnd.Value.Date;
            var check = comboStatus.SelectedItem as OrderStatus?;
            ORDER_STATUS? status;
            if (check.HasValue) status = check.Value.Status;
            else status = null;

            _orderSearch = _searchSortService.Search (_orders, dateFrom, dateTo, status);
        }
        public OrderPnl (IUnitOfWork unitOfWork, ISearchSortService searchSortService,  IOrderService orderService) {
            InitializeComponent ();
            this.Dock = DockStyle.Fill;

            _unitOfWork = unitOfWork;
            _searchSortService = searchSortService;
            _orderService = orderService;
            _statuses = ListEnum.GetListOrderStatus(true);
            LoadComboStatus ();
            LoadOrderData ();
            LoadGridOrder ();

            this.dateEnd.MinDate = dateStart.Value.Date;
        }

        private void gridOrder_SelectionChanged(object sender, EventArgs e)
        {
            LoadOrderInfo();
        }

        private void gridOrder_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var index = e.RowIndex;
            var subCell = gridOrder.Rows[index].Cells["StatusName"];
            var status = (ORDER_STATUS)gridOrder.Rows[index].Cells["Status"].Value; 
            switch (status)
            {
                case ORDER_STATUS.CHECKED: subCell.Style.BackColor = Color.LightGreen; break;
                case ORDER_STATUS.DELIVERING: subCell.Style.BackColor = Color.LightSeaGreen; break;
                case ORDER_STATUS.DELIVERED: subCell.Style.BackColor = Color.LawnGreen; break;
                case ORDER_STATUS.CANCELLED: subCell.Style.BackColor = Color.OrangeRed; break;
                case ORDER_STATUS.CANCELLED_DELIVERY: subCell.Style.BackColor = Color.OrangeRed; break;
                default: subCell.Style.BackColor = Color.LightBlue; break;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            var check = MessageBox.Show ("Nhận hóa đơn này?","Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (check.Equals(DialogResult.Cancel)) return;

            if (!_orderService.StorageCheck(_model))
            {
                MessageBox.Show("Kho hàng không đủ số lượng đáp ứng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _unitOfWork.OrderRepos.Check(_model);
            if (_orderService.UpdateStorage(_model, false))
                MessageBox.Show("Cập nhật kho hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Lỗi không cập nhật được kho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadOrderData ();
            LoadGridOrder(_selectedIndex);
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            DialogResult check;
            if(_model.Status.Equals(ORDER_STATUS.CHECKED))
                check = MessageBox.Show("Bắt đầu ship hóa đơn này?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            else
                check = MessageBox.Show("Xác nhận đã ship hóa đơn này?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (check.Equals(DialogResult.Cancel)) return;

            if (_model.Status.Equals(ORDER_STATUS.CHECKED)) _unitOfWork.OrderRepos.Delivering(_model);
            else
            {
                _unitOfWork.OrderRepos.Delivered(_model);
            }
            LoadOrderData ();
            LoadGridOrder(_selectedIndex);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var check = MessageBox.Show ("Hủy hóa đơn này?","Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (check.Equals(DialogResult.Cancel)) return;

            if (_model.Status.Equals(ORDER_STATUS.NEW)) _unitOfWork.OrderRepos.Cancel(_model);
            else
            {
                _unitOfWork.OrderRepos.CancelDelivery(_model);
                if (_orderService.UpdateStorage(_model, true))
                MessageBox.Show("Trả hàng về kho hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                MessageBox.Show("Lỗi không cập nhật được kho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadOrderData ();
            LoadGridOrder(_selectedIndex);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadOrderData();
            SearchOrder();
            LoadGridOrder();
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
