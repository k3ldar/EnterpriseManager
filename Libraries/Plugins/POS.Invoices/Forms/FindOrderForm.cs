using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;
using Library.BOL.Orders;
using POS.Base.Classes;

namespace POS.Invoices.Forms
{
    public partial class FindOrderForm : POS.Base.Forms.BaseForm
    {
        #region Constructors

        public FindOrderForm()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.InvoiceFindOrder;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppOrderFind;
            lblEnterOrder.Text = LanguageStrings.AppOrderEnter;

            btnCancel.Text = LanguageStrings.AppCancel;
            btnFind.Text = LanguageStrings.AppSearch;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                int orderID = Convert.ToInt32(textBox1.Text);
                Order order = Library.BOL.Orders.Orders.Get(orderID);

                if (order == null)
                    throw new Exception(LanguageStrings.AppOrderNotFound);
                Close();

                POS.Base.Plugins.NotificationEventArgs showUser = new POS.Base.Plugins.NotificationEventArgs(order.User);
                PluginManager.RaiseEvent(showUser);

                if (showUser.Result != null)
                {
                    ((Form)showUser.Result).BringToFront();
                }
            }
            catch
            {
                ShowError(LanguageStrings.AppOrder, LanguageStrings.AppOrderNotFound);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !StringConstants.CHARS_VALID_NUMERIC.Contains(e.KeyChar.ToString());
        }

        #endregion Private Methods
    }
}
