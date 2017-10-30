using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SieraDelta.Library.Utils;
using SieraDelta.Library.BOL.Orders;

using SieraDelta.POS.Classes;

namespace SieraDelta.POS.Orders.Forms
{
    public partial class UnpaidOrderForm : SieraDelta.POS.Forms.BaseForm
    {
        public UnpaidOrderForm()
        {
            InitializeComponent();

            dtpStart.Value = DateTime.Now.AddDays(-7);
            dtpFinish.Value = DateTime.Now;
        }

        #region Overridden Methods

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblEndDate.Text = SieraDelta.Languages.LanguageStrings.AppDateEnd;
            lblStartDate.Text = SieraDelta.Languages.LanguageStrings.AppDateStart;
            btnSearch.Text = SieraDelta.Languages.LanguageStrings.AppSearch;
            toolStripStatusLabelSearch.Text = SieraDelta.Languages.LanguageStrings.AppSearchClickSearch;
            colCustomer.Text = SieraDelta.Languages.LanguageStrings.AppCustomer;
            colDate.Text = SieraDelta.Languages.LanguageStrings.AppDate;
            colOrderNumber.Text = SieraDelta.Languages.LanguageStrings.AppOrderNumber;
            colStatus.Text = SieraDelta.Languages.LanguageStrings.AppStatus;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dtpStart.Value > dtpFinish.Value)
            {
                ShowError(SieraDelta.Languages.LanguageStrings.AppSearch,
                    SieraDelta.Languages.LanguageStrings.AppErrorStartDateBeforeEndDate);
                return;
            }

            TimeSpan span = dtpFinish.Value - dtpStart.Value;

            if (span.TotalDays > 30)
            {
                ShowError(SieraDelta.Languages.LanguageStrings.AppSearch,
                    SieraDelta.Languages.LanguageStrings.AppErrorMaximumSearch30Days);
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            try
            {
                lvUnpaidOrders.Items.Clear();

                SieraDelta.Library.BOL.Orders.Orders orders = SieraDelta.Library.BOL.Orders.Orders.GetUnpaid(dtpStart.Value, dtpFinish.Value);

                foreach (Order order in orders)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = String.Format(StringConstants.ORDER_PREFIX, order.ID.ToString());
                    item.SubItems.Add(order.User.UserName);
                    item.SubItems.Add(order.PurchaseDateTime.ToShortDateString());
                    item.SubItems.Add(order.Status.Description);
                    item.SubItems.Add(order.ID.ToString());
                        
                    lvUnpaidOrders.Items.Add(item);
                }

                string statusLabel = SieraDelta.Languages.LanguageStrings.AppOrderFoundMultiple;

                if (orders.Count == 1)
                    statusLabel = SieraDelta.Languages.LanguageStrings.AppOrderFoundOne;
                else
                    statusLabel = String.Format(statusLabel, orders.Count);

                toolStripStatusLabelSearch.Text = statusLabel;
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void lvUnpaidOrders_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in lvUnpaidOrders.SelectedItems)
            {
                Order order = SieraDelta.Library.BOL.Orders.Orders.Get(Convert.ToInt32(itm.Text.Substring(1)));

                if (order != null)
                {
                    OrderView viewOrder = new OrderView(order);
                    try
                    {
                        viewOrder.ShowDialog(this);
                    }
                    finally
                    {
                        viewOrder.Dispose();
                        viewOrder = null;
                    }
                }
            }
        }

        #endregion Private Methods
    }
}
