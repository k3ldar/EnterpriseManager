/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *  Enterprise Manager is distributed under the GNU General Public License version 3 and  
 *  is also available under alternative licenses negotiated directly with Simon Carter.  
 *  If you obtained Enterprise Manager under the GPL, then the GPL applies to all loadable 
 *  Enterprise Manager modules used on your system as well. The GPL (version 3) is 
 *  available at https://opensource.org/licenses/GPL-3.0
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 *  without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 *  See the GNU General Public License for more details.
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: FindOrderForm.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;
using SharedBase.BOL.Orders;
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
                Order order = SharedBase.BOL.Orders.Orders.Get(orderID);

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
