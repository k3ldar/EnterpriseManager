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
 *  File: InvoiceHeaderSettings.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using POS.Base.Classes;

#pragma warning disable IDE1006 // naming rule violation

namespace POS.Invoices.Controls
{
    public partial class InvoiceHeaderSettings : SharedControls.BaseSettings
    {
        #region Private Member

        private string _newInvoiceHeader = String.Empty;

        #endregion Private Members

        public InvoiceHeaderSettings()
        {
            InitializeComponent();
        }

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblJPEGDesc.Text = Languages.LanguageStrings.AppJPEGDescription;
            btnSelectInvoiceHeader.Text = Languages.LanguageStrings.AppSelectHeader;
            lblInvoiceAddress.Text = Languages.LanguageStrings.InvoiceAddress;
        }

        public override bool SettingsSave()
        {
            if (_newInvoiceHeader != AppController.LocalSettings.InvoiceHeaderRight)
                AppController.LocalSettings.InvoiceHeaderRight = _newInvoiceHeader;

            AppController.LocalSettings.InvoiceAddress = txtInvoiceAddress.Text;

            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
            _newInvoiceHeader = AppController.LocalSettings.InvoiceHeaderRight;

            if (String.IsNullOrEmpty(_newInvoiceHeader))
            {
                _newInvoiceHeader = AppController.POSFolder(ImageTypes.Logo) +
                    StringConstants.IMAGE_LOGO_INVOICE;
            }

            LoadInvoiceHeader(_newInvoiceHeader);
            txtInvoiceAddress.Text = AppController.LocalSettings.InvoiceAddress;
        }

        #endregion Overridden Methods

        #region Private Settings

        private void LoadInvoiceHeader(string invoiceHeader)
        {
            if (String.IsNullOrEmpty(invoiceHeader))
                return;

            Bitmap jpg;

            if (File.Exists(invoiceHeader))
            {
                jpg = new Bitmap(invoiceHeader);
                picInvoiceHeader.Image = jpg;
            }
            else
                _newInvoiceHeader = String.Empty;
        }

        private void btnSelectInvoiceHeader_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = StringConstants.FILE_SEARCH_JPEG;
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.InitialDirectory = Shared.Utilities.CurrentPath();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _newInvoiceHeader = openFileDialog1.FileName;
                LoadInvoiceHeader(_newInvoiceHeader);
            }
        }

        #endregion Private Settings
    }
}
