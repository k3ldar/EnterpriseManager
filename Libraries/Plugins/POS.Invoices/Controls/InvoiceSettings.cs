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
 *  File: InvoiceSettings.cs
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
using POS.Base.Classes;

namespace POS.Invoices.Controls
{
    public partial class InvoiceSettings : SharedControls.BaseSettings
    {
        public InvoiceSettings()
        {
            InitializeComponent();
        }

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            cbAllowCurrencyToBeConverted.Text = LanguageStrings.AppAllowCurrencyConversion;
            cbHideVAT.Text = LanguageStrings.AppHideVAT;
            cbShowProductDiscountOnInvoice.Text = LanguageStrings.AppShowProductDiscountOnInvoice;
            lblMinTrackingOrderValue.Text = LanguageStrings.AppOrderMinTrackingRefCost;
            cbShippingIsTaxable.Text = LanguageStrings.AppShippingIsTaxable;
            lblVATNumber.Text = LanguageStrings.VATRegistrationNumber;

            lblInvoicePrefix.Text = LanguageStrings.AppInvoicePrefix;
        }

        public override bool SettingsSave()
        {
            SharedBase.DAL.DALHelper.HideVATOnWebsiteAndInvoices = cbHideVAT.Checked;

            AppController.LocalSettings.AllowCurrencyToBeConverted = cbAllowCurrencyToBeConverted.Checked;
            AppController.LocalSettings.HideVATOnOrdersAndInvoices = cbHideVAT.Checked;
            AppController.LocalSettings.InvoicePrefix = txtInvoicePrefix.Text;
            AppController.LocalSettings.InvoiceShowProductDiscount = cbShowProductDiscountOnInvoice.Checked;
            AppController.LocalSettings.InvoiceMinimumValueTrackingReference = Convert.ToDecimal(txtMinTrackReference.Text);
            AppController.LocalSettings.ShippingIsTaxable = cbShippingIsTaxable.Checked;
            AppController.LocalSettings.InvoiceVATRegistrationNumber = txtVATRegNumber.Text;

            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
            cbHideVAT.Checked = SharedBase.DAL.DALHelper.HideVATOnWebsiteAndInvoices;
            cbAllowCurrencyToBeConverted.Checked = AppController.LocalSettings.AllowCurrencyToBeConverted;
            cbShowProductDiscountOnInvoice.Checked = AppController.LocalSettings.InvoiceShowProductDiscount;
            txtMinTrackReference.Text = AppController.LocalSettings.InvoiceMinimumValueTrackingReference.ToString();
            cbShippingIsTaxable.Checked = AppController.LocalSettings.ShippingIsTaxable;
            txtInvoicePrefix.Text = AppController.LocalSettings.InvoicePrefix;
            txtVATRegNumber.Text = AppController.LocalSettings.InvoiceVATRegistrationNumber;
        }

        #endregion Overridden Methods

    }
}
