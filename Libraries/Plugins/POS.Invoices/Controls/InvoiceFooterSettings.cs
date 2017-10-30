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
