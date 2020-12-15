using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCore.Interfaces;

namespace Winform {
    public partial class MainForm : Form {
        private readonly IUnitOfWork _unitOfWork;

        private ItemPnl pnItem;
        
        public MainForm (IUnitOfWork unitOfWork) {
            InitializeComponent ();

            _unitOfWork = unitOfWork;

            pnItem = new ItemPnl(_unitOfWork);
            tabItem.Controls.Add(pnItem);

        }

        private void tabControl_TabIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Equals(tabItem))
            {
                tabItem.Controls.Remove(pnItem);
                pnItem = new ItemPnl(_unitOfWork);
                tabItem.Controls.Add(pnItem);
            }
        }
    }
}