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
 *  Copyright (c) 2010 - 2019 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: OrderManagerSettings.cs
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
