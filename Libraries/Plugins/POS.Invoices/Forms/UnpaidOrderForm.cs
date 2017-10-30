using System;
using System.Windows.Forms;
using Library.BOL.Orders;

using POS.Base.Classes;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation
#pragma warning disable IDE0016 // null check simplified

namespace POS.Invoices.Forms
{
    public partial class UnpaidOrderForm : Base.Controls.BaseTabControl
    {
        public UnpaidOrderForm()
        {
            InitializeComponent();

            dtpStart.Value = DateTime.Now.AddDays(-7);
            dtpFinish.Value = DateTime.Now;
        }

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblEndDate.Text = Languages.LanguageStrings.AppDateEnd;
            lblStartDate.Text = Languages.LanguageStrings.AppDateStart;
            btnSearch.Text = Languages.LanguageStrings.AppSearch;
            toolStripStatusLabelSearch.Text = Languages.LanguageStrings.AppSearchClickSearch;
            colCustomer.Text = Languages.LanguageStrings.AppCustomer;
            colDate.Text = Languages.LanguageStrings.AppDate;
            colOrderNumber.Text = Languages.LanguageStrings.AppOrderNumber;
            colStatus.Text = Languages.LanguageStrings.AppStatus;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dtpStart.Value > dtpFinish.Value)
            {
                ShowError(Languages.LanguageStrings.AppSearch,
                    Languages.LanguageStrings.AppErrorStartDateBeforeEndDate);
                return;
            }

            TimeSpan span = dtpFinish.Value - dtpStart.Value;

            if (span.TotalDays > 30)
            {
                ShowError(Languages.LanguageStrings.AppSearch,
                    Languages.LanguageStrings.AppErrorMaximumSearch30Days);
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            try
            {
                lvUnpaidOrders.Items.Clear();

                Orders orders = Orders.GetUnpaid(dtpStart.Value, dtpFinish.Value);

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

                string statusLabel = Languages.LanguageStrings.AppOrderFoundMultiple;

                if (orders.Count == 1)
                    statusLabel = Languages.LanguageStrings.AppOrderFoundOne;
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
                Order order = Library.BOL.Orders.Orders.Get(Convert.ToInt32(itm.Text.Substring(1)));

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
