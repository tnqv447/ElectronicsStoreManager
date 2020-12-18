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
        public EditItemRelationDialog (IUnitOfWork unitOfWork, ItemRelation relation) {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            if (relation is null) {
                MessageBox.Show ("Chi tiết truyền vào không tìm thấy", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose ();
            }
            _model = relation;
        }

        private void btnOk_Click (object sender, EventArgs e) {

        }

        private void btnCancel_Click (object sender, EventArgs e) {
            var check = MessageBox.Show ("Hủy thao tác?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (check.Equals (DialogResult.Cancel)) return;

            this.DialogResult = DialogResult.Cancel;
            this.Close ();
        }
    }
}