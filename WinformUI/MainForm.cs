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
        private readonly IAnalyzeService _analyzeService;

        private ItemPnl pnItem;
        private OrderPnl pnOrder;
        private AnalyzePnl pnAnalyze;

        public MainForm (IUnitOfWork unitOfWork,  ISearchSortService searchSortService, IAnalyzeService analyzeService, IOrderService orderService) {
            InitializeComponent ();

            _unitOfWork = unitOfWork;
            _searchSortService = searchSortService;
            _orderService = orderService;
            _analyzeService = analyzeService;

            pnItem = new ItemPnl(_unitOfWork, _searchSortService);
            tabItem.Controls.Add(pnItem);

            pnOrder = new OrderPnl(_unitOfWork, _searchSortService, _orderService);
            tabOrder.Controls.Add(pnOrder);

            pnAnalyze = new AnalyzePnl(_unitOfWork,_searchSortService, _analyzeService);
            tabAnalyze.Controls.Add(pnAnalyze);

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
            if (tabControl.SelectedTab.Equals(tabAnalyze))
            {
                pnAnalyze.Reload();
            }
        }
    }
}