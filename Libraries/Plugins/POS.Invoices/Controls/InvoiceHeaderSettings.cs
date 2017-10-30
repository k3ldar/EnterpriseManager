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
