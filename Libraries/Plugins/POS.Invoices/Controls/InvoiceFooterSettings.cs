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
 *  File: InvoiceFooterSettings.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using POS.Base.Classes;

namespace POS.Invoices.Controls
{
    public partial class InvoiceFooterSettings : SharedControls.BaseSettings
    {
        public InvoiceFooterSettings()
        {
            InitializeComponent();
        }

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblInvoiceFooterDesc.Text = Languages.LanguageStrings.AppInvoiceFooterDescription;
            lblPaymentDue.Text = Languages.LanguageStrings.AppOrderPaymentDue;
        }

        public override bool SettingsSave()
        {
            AppController.LocalSettings.InvoiceFooter = txtInvoiceFooter.Text;
            AppController.LocalSettings.InvoiceFooterInvoiceDue = txtInvoiceDue.Text;

            //if (!AppController.LocalSettings.InvoiceFooter.Contains(StringConstants.SYMBOL_RETURN))
            //    AppController.LocalSettings.InvoiceFooter = AppController.LocalSettings.InvoiceFooter.Replace(
            //        StringConstants.SYMBOL_LINE_FEED, StringConstants.SYMBOL_CRLF);

            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
            //if (!AppController.LocalSettings.InvoiceFooter.Contains(StringConstants.SYMBOL_RETURN))
            //    AppController.LocalSettings.InvoiceFooter = AppController.LocalSettings.InvoiceFooter.Replace(
            //        StringConstants.SYMBOL_LINE_FEED, StringConstants.SYMBOL_CRLF);

            txtInvoiceFooter.Text = AppController.LocalSettings.InvoiceFooter;
            txtInvoiceDue.Text = AppController.LocalSettings.InvoiceFooterInvoiceDue;
        }

        #endregion Overridden Methods
    }
}
