using System.Collections.Specialized;
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

namespace Winform.Dialogs {
    public partial class ItemDialog : Form {
        private readonly IUnitOfWork _unitOfWork;

        private IList<ItemType> _types = new List<ItemType>();
        private IList<ItemRelation> _relations = new List<ItemRelation>();
        private IList<ItemRelation> _relationsModified = new List<ItemRelation>();
        private IList<ItemRelation> _relationsDeleted = new List<ItemRelation>();
        private Item _model = null;
        private bool _isEditMode = false;
        private bool _isForCombo = false;

        private ItemRelation _selectedRelation = null;
        private int _selectedIndex = -1;
        private void LoadComboItemType () {
            comboType.Items.Clear ();
            comboType.DataSource = _types;
            comboType.DisplayMember = "TypeName";
            comboType.ValueMember = "Type";
            
        }
        private void LoadModel (Item item) {
            if (!(item is null)) {
                this.txtId.Text = item.Id.ToString ();
                this.txtName.Text = item.Name;
                this.comboType.SelectedValue = item.Type;
                this.numberUnitPrice.Value = item.UnitPrice;
                this.txtDescription.Text = item.Description;
            }
        }
        private void ReturnModel () {
            var res = new Item (txtName.Text, (ITEM_TYPE) comboType.SelectedValue, numberUnitPrice.Value, txtDescription.Text, _model == null?0 : _model.InStock);
            if (_model is null) _model = res;
            else _model.Copy (res);
        }
        private void HideView () {
            if (!_isEditMode) {
                this.txtId.Visible = false;
                this.lblId.Visible = false;
            }
            if (!_isForCombo) {
                this.Size = new Size (816, 220);
                this.groupSubItem.Visible = false;
            } else {
                this.comboType.Enabled = false;
            }
            this.CenterToParent ();
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

            this.gridSubItem.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridSubItem.Columns["Amount"].DisplayIndex = 3;
            this.gridSubItem.Columns["Amount"].HeaderText = "Số lượng";
            this.gridSubItem.Columns["Amount"].Width = 120;

            this.gridSubItem.Columns["UnitPrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.gridSubItem.Columns["UnitPrice"].DisplayIndex = 4;
            this.gridSubItem.Columns["UnitPrice"].HeaderText = "Đơn giá";
            this.gridSubItem.Columns["UnitPrice"].Width = 120;
            this.gridSubItem.Columns["UnitPrice"].DefaultCellStyle.Format = "##,#";
        }
        private void LoadGridSubItem (IList<ItemRelation> relations, int selectedIndex = -1) {
            TblItemRelation tbl = new TblItemRelation (_unitOfWork, relations);

            this.gridSubItem.DataSource = tbl;
            if (selectedIndex < 0) {
                this.gridSubItem.ClearSelection ();
            } else {
                this.gridSubItem.Rows[selectedIndex].Selected = true;
            }

        }
        public ItemDialog (IUnitOfWork unitOfWork, bool isForCombo, Item item = null) {
            InitializeComponent ();

            _unitOfWork = unitOfWork;
            _isForCombo = isForCombo;
            if (!(item is null)) {
                _model = item;
                _isEditMode = true;
            }
            if(_isForCombo) _types.Add(new ItemType (ITEM_TYPE.COMBO, "Combo"));
            else _types = ListEnum.GetListItemType ();
            this.numberUnitPrice.Maximum = decimal.MaxValue;

            HideView ();
            LoadComboItemType ();
            LoadModel (_model);
            if(_isForCombo){
                if(_isEditMode) _relations = _model.ConsistOf.Select(m => new ItemRelation(m)).ToList();
                LoadGridSubItem (_relations);
                this.SetUpGridSubItem ();
            }
        }

        private void btnCancel_Click (object sender, EventArgs e) {
            var check = MessageBox.Show ("Hủy thao tác?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (check.Equals (DialogResult.Cancel)) return;

            this.DialogResult = DialogResult.Cancel;
            this.Close ();
        }

        private void btnOK_Click (object sender, EventArgs e) {
            if(String.IsNullOrWhiteSpace(txtName.Text)){
                MessageBox.Show ("Tên không được để trống", "Cánh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            var check = MessageBox.Show ("Xác nhận thao tác?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (check.Equals (DialogResult.Cancel)) return;

            this.ReturnModel ();
            if (_isForCombo) {
               if (_isEditMode) {
                    _unitOfWork.ItemRepos.Update (_model);
                    foreach (ItemRelation c in _relationsDeleted)
                {
                    var res = _model.ConsistOf.Where(m => m.ChildId.Equals(c.ChildId));
                    if (res.Any())
                    {
                        _unitOfWork.ItemRepos.ItemRelationRepos.Delete(res.First());
                    }
                }
                foreach (ItemRelation c in _relationsModified)
                {
                    var res = _model.ConsistOf.Where(m => m.ChildId.Equals(c.ChildId));
                    if (res.Any())
                    {
                        var temp = res.First();
                        temp.Copy(c);
                        _unitOfWork.ItemRepos.ItemRelationRepos.Update(res.First());
                    }
                    else
                    {
                        var temp = new ItemRelation(c);
                        temp.ParentId = _model.Id;
                        _unitOfWork.ItemRepos.ItemRelationRepos.Add(temp);
                    }
                }
                } else {
                    _model = _unitOfWork.ItemRepos.Add(_model);
                    foreach (ItemRelation rel in _relations)
                    {
                        rel.ParentId = _model.Id;
                    }
                    _unitOfWork.ItemRepos.ItemRelationRepos.AddRange(_relations);
                }
            } else {
                if (_isEditMode) {
                    _unitOfWork.ItemRepos.Update (_model);
                } else {
                    _model = _unitOfWork.ItemRepos.Add (_model);
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close ();
        }

        private void btnAdd_Click (object sender, EventArgs e) {
            var dialog = new AddItemRelationDialog (_unitOfWork, _relations, _relationsModified);
            var check = dialog.ShowDialog ();

            if (check.Equals (DialogResult.OK)) {
                MessageBox.Show ("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGridSubItem(_relations, _selectedIndex);
                SetUpGridSubItem();
            }
            
            dialog.Dispose ();
        }

        private void btnEdit_Click (object sender, EventArgs e) {
            var dialog = new EditItemRelationDialog (_unitOfWork, _selectedRelation, _relationsModified);
            var check = dialog.ShowDialog ();

            if (check.Equals (DialogResult.OK)) {
                MessageBox.Show ("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGridSubItem(_relations, _selectedIndex);
                SetUpGridSubItem();
            }
            
            dialog.Dispose ();
        }

        private void btnDelete_Click (object sender, EventArgs e) {
            var check = MessageBox.Show ("Xóa chi tiết này?","Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (check.Equals (DialogResult.Cancel)) return;

            if(_selectedRelation != null){
                if(_isEditMode){
                    _relationsModified.Remove(_selectedRelation);
                    _relationsDeleted.Add(_selectedRelation);
                }
                _relations.Remove(_selectedRelation);
            }
            
            if(_isEditMode) _relations = _model.ConsistOf;
            LoadGridSubItem(_relations);
            SetUpGridSubItem();

        }

        private void gridSubItem_SelectionChanged(object sender, EventArgs e)
        {
            if (this.gridSubItem.SelectedRows.Count > 0) {
                var row = this.gridSubItem.SelectedRows[0];
                _selectedIndex = row.Index;

                var childId = (Int32) row.Cells["ChildId"].Value;
                _selectedRelation = _relations.Where (m => m.ChildId.Equals (childId)).First ();

            } else {
                _selectedRelation = null;
            }
        }
    }
}