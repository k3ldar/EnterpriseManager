using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SieraDelta.Languages;
using SieraDelta.Library.BOL.Orders;
using SieraDelta.POS.Classes;

namespace SieraDelta.POS.Orders.Forms
{
    public partial class FindOrderForm : SieraDelta.POS.Forms.BaseForm
    {
        #region Constructors

        public FindOrderForm()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

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
                Order order = SieraDelta.Library.BOL.Orders.Orders.Get(orderID);

                if (order == null)
                    throw new Exception(LanguageStrings.AppOrderNotFound);
                PluginManager.RaiseEvent(new Plugins.NotificationEventArgs(StringConstants.PLUGIN_EVENT_EDIT_CUSTOMER, order.User));
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
