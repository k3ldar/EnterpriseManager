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
            Library.DAL.DALHelper.HideVATOnWebsiteAndInvoices = cbHideVAT.Checked;

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
            cbHideVAT.Checked = Library.DAL.DALHelper.HideVATOnWebsiteAndInvoices;
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
