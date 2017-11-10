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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: StockControlAutoReorder.cs
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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;

using Library.BOL.StockControl;
using Library.BOL.Users;
using POS.Base.Classes;

namespace POS.StockControl.Controls
{
    public partial class StockControlAutoReorder : SharedControls.BaseSettings
    {
        #region Private Members


        #endregion Private Members

        #region Constructors

        public StockControlAutoReorder()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            cbAllowAutoReOrder.Text = LanguageStrings.AppStockAutoReOrderAllow;

            gbUser.Text = LanguageStrings.AppUser;
            lblUserDescription.Text = LanguageStrings.AppStockAutoReOrderUserDescription;
            lblPassword.Text = LanguageStrings.Password;
        }

        public override bool SettingsSave()
        {
            AppController.LocalSettings.StockAutoReOrder = cbAllowAutoReOrder.Checked;

            if (cbAllowAutoReOrder.Checked && String.IsNullOrEmpty(txtUserName.Text))
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppStockAutoReOrderUserRequired);
                return (false);
            }

            AppController.LocalSettings.StockAutoReOrderUserEmail = txtUserName.Text;
            AppController.LocalSettings.StockAutoReOrderUserPassword = txtPassword.Text;

            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
            cbAllowAutoReOrder.Checked = AppController.LocalSettings.StockAutoReOrder;

            txtUserName.Text = AppController.LocalSettings.StockAutoReOrderUserEmail;
            txtPassword.Text = AppController.LocalSettings.StockAutoReOrderUserPassword;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void cbAllowAutoReOrder_CheckedChanged(object sender, EventArgs e)
        {
            gbUser.Enabled = cbAllowAutoReOrder.Checked;
        }

        #endregion Private Methods
    }
}
