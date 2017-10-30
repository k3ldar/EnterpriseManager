using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;
using Library;
using Library.BOL.Coupons;
using POS.Base.Classes;
using POS.Administration.Classes;

using SharedControls.WizardBase;

namespace POS.Administration.Controls.Wizards.Coupons
{
    public partial class Step2 : BaseWizardPage
    {
        #region Private Members

        private CouponSettings _settings;

        #endregion Private Members

        #region Constructors

        public Step2()
        {
            InitializeComponent();
        }

        public Step2(CouponSettings settings)
            : this()
        {
            
            _settings = settings;
            PopulateTypes();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblVoucherType.Text = LanguageStrings.AppDiscountCouponVoucherType;
        }

        public override bool NextClicked()
        {
            _settings.Coupon.VoucherType = (Enums.InvoiceVoucherType)Enum.Parse(typeof(Enums.InvoiceVoucherType), cmbVoucherType.Text);
            _settings.Coupon.Discount = (int)spnDiscount.Value;

            return base.NextClicked();
        }

        public override void PageShown()
        {
            spnDiscount.Value = _settings.Coupon.Discount;
            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.DiscountCouponStep2;
        }

        public override bool SkipPage()
        {
            return base.SkipPage();
        }

        #endregion Overridden Methods

        #region Private Methods

        private void PopulateTypes()
        {
            foreach (Enums.InvoiceVoucherType type in (Enums.InvoiceVoucherType[])Enum.GetValues(typeof(Enums.InvoiceVoucherType)))
            {
                int idx = cmbVoucherType.Items.Add(type);

                if (type == _settings.Coupon.VoucherType)
                    cmbVoucherType.SelectedIndex = idx;
            }
        }

        private void cmbVoucherType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enums.InvoiceVoucherType type = (Enums.InvoiceVoucherType)Enum.Parse(typeof(Enums.InvoiceVoucherType), cmbVoucherType.Text);

            switch (type)
            {
                case Enums.InvoiceVoucherType.FreeProduct:
                    spnDiscount.Enabled = false;
                    lblDiscountAmount.Text = LanguageStrings.AppDiscount;
                    lblDiscountAmount2.Text = LanguageStrings.AppNotApplicable;
                    break;

                case Enums.InvoiceVoucherType.Footprint:
                case Enums.InvoiceVoucherType.SpecialOffer:
                    spnDiscount.Enabled = false;
                    lblDiscountAmount.Text = LanguageStrings.AppDiscount;
                    lblDiscountAmount2.Text = LanguageStrings.AppNotApplicable;
                    break;

                case Enums.InvoiceVoucherType.Percent:
                    lblDiscountAmount.Text = String.Format(StringConstants.PREFIX_AND_SUFFIX_SPACE,
                        LanguageStrings.AppDiscount, StringConstants.SYMBOL_PERCENT);
                    lblDiscountAmount2.Text = StringConstants.SYMBOL_PERCENT;
                    spnDiscount.Enabled = true;
                    break;

                case Enums.InvoiceVoucherType.Value:
                    lblDiscountAmount.Text = String.Format(StringConstants.PREFIX_AND_SUFFIX_SPACE,
                        LanguageStrings.AppDiscount, AppController.LocalCountry.CurrencySymbol);
                    lblDiscountAmount2.Text = AppController.LocalCountry.CurrencySymbol;
                    spnDiscount.Enabled = true;
                    break;

                default:
                    throw new Exception(StringConstants.ERROR_INVALID_VOUCHER_TYPE);
            }

            lblDiscountAmount.Enabled = spnDiscount.Enabled;
            lblDiscountAmount2.Enabled = spnDiscount.Enabled;
        }

        #endregion Private Methods
    }
}
