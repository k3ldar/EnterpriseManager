using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using POS.Base.Classes;

namespace POS.Orders.Controls
{
    public partial class OrderManagerSettings : SharedControls.BaseSettings
    {
        public OrderManagerSettings()
        {
            InitializeComponent();
        }

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblDescription.Text = Languages.LanguageStrings.AppOrderManagerFooterDesc;
            gbTextAlignment.Text = Languages.LanguageStrings.AppTextAlignment;
            rbOrderByAlignCenter.Text = Languages.LanguageStrings.AppCenter;
            rbOrderByAlignLeft.Text = Languages.LanguageStrings.AppLeft;
            rbOrderByAlignRight.Text = Languages.LanguageStrings.AppRight;
            cbLinkToStock.Text = Languages.LanguageStrings.AppOrderLinkToStock;
            cbBypassLabel.Text = Languages.LanguageStrings.AppBypassLabelPrinting;
        }

        public override bool SettingsSave()
        {
            AppController.LocalSettings.OrderManagerOrderPreparedBy = txtInvoicePreparedBy.Text;
            AppController.LocalSettings.OrderManagerPreparedByAlignment = GetPreparedByAlignment();
            AppController.LocalSettings.OrderManagerLinkToStock = cbLinkToStock.Checked;
            AppController.LocalSettings.OrderManagerBypassLabel = cbBypassLabel.Checked;

            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
            cbLinkToStock.Checked = AppController.LocalSettings.OrderManagerLinkToStock;
            cbBypassLabel.Checked = AppController.LocalSettings.OrderManagerBypassLabel;

            txtInvoicePreparedBy.Text = AppController.LocalSettings.OrderManagerOrderPreparedBy;

            if (AppController.LocalSettings.OrderManagerPreparedByAlignment == 0)
                rbOrderByAlignLeft.Checked = true;
            else if (AppController.LocalSettings.OrderManagerPreparedByAlignment == 1)
                rbOrderByAlignCenter.Checked = true;
            else
                rbOrderByAlignRight.Checked = true;
        }

        #endregion Overridden Methods

        #region Private Methods

        private int GetPreparedByAlignment()
        {
            if (rbOrderByAlignLeft.Checked)
                return (0);
            else if (rbOrderByAlignCenter.Checked)
                return (1);
            else
                return (2);
        }

        #endregion Private Methods
    }
}
