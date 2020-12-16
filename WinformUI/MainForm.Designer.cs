
namespace Winform
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabItem = new System.Windows.Forms.TabPage();
            this.tabOrder = new System.Windows.Forms.TabPage();
            this.tabAnalyze = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabItem);
            this.tabControl.Controls.Add(this.tabOrder);
            this.tabControl.Controls.Add(this.tabAnalyze);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1240, 673);
            this.tabControl.TabIndex = 0;
            this.tabControl.TabIndexChanged += new System.EventHandler(this.tabControl_TabIndexChanged);
            // 
            // tabItem
            // 
            this.tabItem.Location = new System.Drawing.Point(4, 24);
            this.tabItem.Name = "tabItem";
            this.tabItem.Padding = new System.Windows.Forms.Padding(3);
            this.tabItem.Size = new System.Drawing.Size(1232, 645);
            this.tabItem.TabIndex = 0;
            this.tabItem.Text = "Sản phẩm";
            this.tabItem.UseVisualStyleBackColor = true;
            // 
            // tabOrder
            // 
            this.tabOrder.Location = new System.Drawing.Point(4, 24);
            this.tabOrder.Name = "tabOrder";
            this.tabOrder.Padding = new System.Windows.Forms.Padding(3);
            this.tabOrder.Size = new System.Drawing.Size(1232, 645);
            this.tabOrder.TabIndex = 1;
            this.tabOrder.Text = "Hóa đơn";
            this.tabOrder.UseVisualStyleBackColor = true;
            // 
            // tabAnalyze
            // 
            this.tabAnalyze.Location = new System.Drawing.Point(4, 24);
            this.tabAnalyze.Name = "tabAnalyze";
            this.tabAnalyze.Padding = new System.Windows.Forms.Padding(3);
            this.tabAnalyze.Size = new System.Drawing.Size(1232, 645);
            this.tabAnalyze.TabIndex = 3;
            this.tabAnalyze.Text = "Thống kê";
            this.tabAnalyze.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 694);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "Quản lí cửa hàng đồ điện tử";
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabItem;
        private System.Windows.Forms.TabPage tabOrder;
        private System.Windows.Forms.TabPage tabAnalyze;
    }
}