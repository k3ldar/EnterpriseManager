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
