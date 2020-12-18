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

namespace Winform.Dialogs {
    public partial class ImportDialog : Form {
        private readonly IUnitOfWork _unitOfWork;
        private Item _model;
        public ImportDialog (IUnitOfWork unitOfWork, Item item) {
            InitializeComponent ();
            _unitOfWork = unitOfWork;
            if (item is null) {
                MessageBox.Show ("Sản phẩm truyền vào không tìm thấy", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose ();
            }
            _model = item;
        }

        private void btnOk_Click (object sender, EventArgs e) {
            var amount = (int)this.numberAmount.Value;
            if (amount <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0", "Cánh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var check = MessageBox.Show ("Xác nhận số lượng nhập là " + amount + " ?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (check.Equals (DialogResult.Cancel)) return;

            _unitOfWork.ImportRepos.Add (new Import (_model.Id, amount, DateTime.Today));
            _model.InStock += amount;

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