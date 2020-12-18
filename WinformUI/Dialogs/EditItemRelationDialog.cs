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
    public partial class EditItemRelationDialog : Form {
        private readonly IUnitOfWork _unitOfWork;
        private ItemRelation _model;
        private IList<ItemRelation> _modifieds;
        public EditItemRelationDialog (IUnitOfWork unitOfWork, ItemRelation relation, IList<ItemRelation> modifieds) {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _modifieds = modifieds;
            if (relation is null) {
                MessageBox.Show ("Chi tiết truyền vào không tìm thấy", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose ();
            }
            _model = relation;
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

            _model.Amount = amount;
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