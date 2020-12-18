using System.Transactions;
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
using AppCore.Services;

namespace Winform {
    public partial class MainForm : Form {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISearchSortService _searchSortService;
        private readonly IOrderService _orderService;

        private ItemPnl pnItem;
        private OrderPnl pnOrder;

        public MainForm (IUnitOfWork unitOfWork,  ISearchSortService searchSortService, IOrderService orderService) {
            InitializeComponent ();

            _unitOfWork = unitOfWork;
            _searchSortService = searchSortService;
            _orderService = orderService;

            pnItem = new ItemPnl(_unitOfWork, _searchSortService);
            tabItem.Controls.Add(pnItem);

            pnOrder = new OrderPnl(_unitOfWork, _searchSortService, _orderService);
            tabOrder.Controls.Add(pnOrder);

        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Equals(tabItem))
            {
                pnItem.Reload();
            }
            if (tabControl.SelectedTab.Equals(tabOrder))
            {
                pnOrder.Reload();
            }
        }
    }
}