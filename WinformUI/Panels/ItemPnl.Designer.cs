
namespace Winform
{
    partial class ItemPnl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radCombo = new System.Windows.Forms.RadioButton();
            this.radItem = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.checkedTypeBox = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numberTo = new System.Windows.Forms.NumericUpDown();
            this.numberFrom = new System.Windows.Forms.NumericUpDown();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridItem = new System.Windows.Forms.DataGridView();
            this.groupSubItem = new System.Windows.Forms.GroupBox();
            this.gridSubItem = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.txtInStock = new System.Windows.Forms.TextBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnShowImport = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberFrom)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).BeginInit();
            this.groupSubItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSubItem)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radCombo);
            this.groupBox1.Controls.Add(this.radItem);
            this.groupBox1.Location = new System.Drawing.Point(9, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loại danh sách";
            // 
            // radCombo
            // 
            this.radCombo.AutoSize = true;
            this.radCombo.Location = new System.Drawing.Point(16, 47);
            this.radCombo.Name = "radCombo";
            this.radCombo.Size = new System.Drawing.Size(65, 19);
            this.radCombo.TabIndex = 1;
            this.radCombo.Text = "Combo";
            this.radCombo.UseVisualStyleBackColor = true;
            // 
            // radItem
            // 
            this.radItem.AutoSize = true;
            this.radItem.Checked = true;
            this.radItem.Location = new System.Drawing.Point(16, 22);
            this.radItem.Name = "radItem";
            this.radItem.Size = new System.Drawing.Size(78, 19);
            this.radItem.TabIndex = 0;
            this.radItem.TabStop = true;
            this.radItem.Text = "Sản phẩm";
            this.radItem.UseVisualStyleBackColor = true;
            this.radItem.CheckedChanged += new System.EventHandler(this.radItem_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.checkedTypeBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numberTo);
            this.groupBox2.Controls.Add(this.numberFrom);
            this.groupBox2.Controls.Add(this.txtSearch);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(9, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(217, 537);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lọc";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(45, 446);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(125, 56);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "LỌC";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Loại:";
            // 
            // checkedTypeBox
            // 
            this.checkedTypeBox.BackColor = System.Drawing.SystemColors.Control;
            this.checkedTypeBox.CheckOnClick = true;
            this.checkedTypeBox.FormattingEnabled = true;
            this.checkedTypeBox.Location = new System.Drawing.Point(6, 157);
            this.checkedTypeBox.Name = "checkedTypeBox";
            this.checkedTypeBox.Size = new System.Drawing.Size(205, 274);
            this.checkedTypeBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "đến:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Giá từ:";
            // 
            // numberTo
            // 
            this.numberTo.Location = new System.Drawing.Point(58, 86);
            this.numberTo.Name = "numberTo";
            this.numberTo.Size = new System.Drawing.Size(153, 23);
            this.numberTo.TabIndex = 3;
            this.numberTo.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numberFrom
            // 
            this.numberFrom.Location = new System.Drawing.Point(58, 57);
            this.numberFrom.Name = "numberFrom";
            this.numberFrom.Size = new System.Drawing.Size(153, 23);
            this.numberFrom.TabIndex = 2;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(58, 28);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(153, 23);
            this.txtSearch.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên:";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.gridItem);
            this.groupBox3.Location = new System.Drawing.Point(232, 176);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(916, 310);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách";
            // 
            // gridItem
            // 
            this.gridItem.AllowUserToAddRows = false;
            this.gridItem.AllowUserToDeleteRows = false;
            this.gridItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridItem.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridItem.Location = new System.Drawing.Point(3, 19);
            this.gridItem.MultiSelect = false;
            this.gridItem.Name = "gridItem";
            this.gridItem.ReadOnly = true;
            this.gridItem.RowHeadersVisible = false;
            this.gridItem.RowTemplate.Height = 25;
            this.gridItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridItem.Size = new System.Drawing.Size(910, 288);
            this.gridItem.TabIndex = 0;
            this.gridItem.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.gridItem_RowPrePaint);
            this.gridItem.SelectionChanged += new System.EventHandler(this.gridItem_SelectionChanged);
            // 
            // groupSubItem
            // 
            this.groupSubItem.Controls.Add(this.gridSubItem);
            this.groupSubItem.Location = new System.Drawing.Point(235, 492);
            this.groupSubItem.Name = "groupSubItem";
            this.groupSubItem.Size = new System.Drawing.Size(913, 141);
            this.groupSubItem.TabIndex = 3;
            this.groupSubItem.TabStop = false;
            this.groupSubItem.Text = "Chi tiết combo";
            this.groupSubItem.Visible = false;
            // 
            // gridSubItem
            // 
            this.gridSubItem.AllowUserToAddRows = false;
            this.gridSubItem.AllowUserToDeleteRows = false;
            this.gridSubItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridSubItem.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridSubItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSubItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSubItem.Location = new System.Drawing.Point(3, 19);
            this.gridSubItem.MultiSelect = false;
            this.gridSubItem.Name = "gridSubItem";
            this.gridSubItem.ReadOnly = true;
            this.gridSubItem.RowHeadersVisible = false;
            this.gridSubItem.RowTemplate.Height = 25;
            this.gridSubItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSubItem.Size = new System.Drawing.Size(907, 119);
            this.gridSubItem.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtType);
            this.groupBox5.Controls.Add(this.btnImport);
            this.groupBox5.Controls.Add(this.btnEdit);
            this.groupBox5.Controls.Add(this.btnChangeStatus);
            this.groupBox5.Controls.Add(this.txtDescription);
            this.groupBox5.Controls.Add(this.txtInStock);
            this.groupBox5.Controls.Add(this.txtUnitPrice);
            this.groupBox5.Controls.Add(this.txtName);
            this.groupBox5.Controls.Add(this.txtId);
            this.groupBox5.Controls.Add(this.lblStock);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(235, 11);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(910, 159);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Thông tin chi tiết";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(61, 90);
            this.txtType.Name = "txtType";
            this.txtType.ReadOnly = true;
            this.txtType.Size = new System.Drawing.Size(227, 23);
            this.txtType.TabIndex = 16;
            // 
            // btnImport
            // 
            this.btnImport.Enabled = false;
            this.btnImport.Location = new System.Drawing.Point(735, 63);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(110, 36);
            this.btnImport.TabIndex = 15;
            this.btnImport.Text = "NHẬP THÊM";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(735, 105);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(111, 40);
            this.btnEdit.TabIndex = 13;
            this.btnEdit.Text = "CẬP NHẬT";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.Enabled = false;
            this.btnChangeStatus.Location = new System.Drawing.Point(735, 21);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(110, 36);
            this.btnChangeStatus.TabIndex = 12;
            this.btnChangeStatus.Text = "ẨN";
            this.btnChangeStatus.UseVisualStyleBackColor = true;
            this.btnChangeStatus.Click += new System.EventHandler(this.btnChangeStatus_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(430, 58);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(227, 87);
            this.txtDescription.TabIndex = 10;
            this.txtDescription.Text = "";
            // 
            // txtInStock
            // 
            this.txtInStock.Location = new System.Drawing.Point(61, 122);
            this.txtInStock.Name = "txtInStock";
            this.txtInStock.ReadOnly = true;
            this.txtInStock.Size = new System.Drawing.Size(100, 23);
            this.txtInStock.TabIndex = 9;
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(430, 29);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.ReadOnly = true;
            this.txtUnitPrice.Size = new System.Drawing.Size(175, 23);
            this.txtUnitPrice.TabIndex = 8;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(61, 61);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(288, 23);
            this.txtName.TabIndex = 7;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(61, 29);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(78, 23);
            this.txtId.TabIndex = 6;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(6, 125);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(53, 15);
            this.lblStock.TabIndex = 5;
            this.lblStock.Text = "Tồn kho:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(373, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 15);
            this.label9.TabIndex = 4;
            this.label9.Text = "Mô tả:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(373, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "Đơn giá:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Loại:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Tên:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "ID:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(1154, 195);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(66, 52);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "THÊM";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnShowImport
            // 
            this.btnShowImport.Location = new System.Drawing.Point(1151, 20);
            this.btnShowImport.Name = "btnShowImport";
            this.btnShowImport.Size = new System.Drawing.Size(75, 122);
            this.btnShowImport.TabIndex = 6;
            this.btnShowImport.Text = "LỊCH SỬ NHẬP HÀNG";
            this.btnShowImport.UseVisualStyleBackColor = true;
            this.btnShowImport.Click += new System.EventHandler(this.btnShowImport_Click);
            // 
            // ItemPnl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnShowImport);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupSubItem);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ItemPnl";
            this.Size = new System.Drawing.Size(1232, 645);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberFrom)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).EndInit();
            this.groupSubItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSubItem)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radCombo;
        private System.Windows.Forms.RadioButton radItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox checkedTypeBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numberTo;
        private System.Windows.Forms.NumericUpDown numberFrom;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView gridItem;
        private System.Windows.Forms.GroupBox groupSubItem;
        private System.Windows.Forms.DataGridView gridSubItem;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.TextBox txtInStock;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnChangeStatus;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Button btnShowImport;
    }
}
