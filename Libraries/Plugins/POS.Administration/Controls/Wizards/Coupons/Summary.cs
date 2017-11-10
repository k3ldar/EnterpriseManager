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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: Summary.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using Languages;
using Library;
using Library.BOL.Coupons;
using Library.Utils;
using POS.Base.Classes;
using POS.Administration.Classes;
using SharedControls.WizardBase;

namespace POS.Administration.Controls.Wizards.Coupons
{
    public partial class Summary : BaseWizardPage
    {
        #region Private Members

        private CouponSettings _settings;

        #endregion Private Members

        #region Constructors

        public Summary()
        {
            InitializeComponent();
        }

        public Summary(CouponSettings settings)
            : this()
        {
            _settings = settings;

        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblSummary.Text = LanguageStrings.AppSummary;
        }

        public override bool NextClicked()
        {

            return base.NextClicked();
        }

        public override bool BeforeFinish()
        {
            // save/create here
            if (_settings.Coupon.ID == -1)
            {
                // new coupon
                Coupon coupon = AppController.Administration.CouponCreate(_settings.Coupon.Name);
                _settings.Coupon.ID = coupon.ID;
            }

            try
            {
                _settings.Coupon.Save();
                return (true);
            }
            catch (Exception err)
            {
                if (err.Message.Contains(StringConstants.ERROR_VIOLATION_COUPON))
                {
                    ShowError(LanguageStrings.AppDiscountCouponName,
                        String.Format(LanguageStrings.AppDiscountCouponSaveNameExists, _settings.Coupon.Name));
                    return (false);
                }
                else
                    throw;
            }

        }

        public override void PageShown()
        {
            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.DiscountCouponFinal;
            string discount = String.Empty;

            switch (_settings.Coupon.VoucherType)
            {
                case Enums.InvoiceVoucherType.Value:
                    discount = SharedUtils.FormatMoney(_settings.Coupon.Discount, AppController.LocalCurrency);
                    break;
                case Enums.InvoiceVoucherType.Percent:
                    discount = String.Format(StringConstants.PREFIX_AND_SUFFIX,
                        _settings.Coupon.Discount,
                        StringConstants.SYMBOL_PERCENT);
                    break;
                case Enums.InvoiceVoucherType.Footprint:
                    discount = LanguageStrings.AppNotApplicable;
                    _settings.Coupon.ExcludedProducts.Clear();
                    _settings.Coupon.FreeProduct = null;
                    _settings.Coupon.RequiredProducts.Clear();
                    break;
                default:
                    discount = LanguageStrings.AppNotApplicable;
                    break;
            }

            lblSummaryDescription.Text = String.Format(LanguageStrings.AppCouponSummary,
                _settings.Coupon.Name,
                _settings.Coupon.StartDateTime.ToString(StringConstants.SYMBOL_DATE_FORMAT_G),
                _settings.Coupon.Expires.ToString(StringConstants.SYMBOL_DATE_FORMAT_G),
                _settings.Coupon.VoucherType.ToString(),
                discount,
                _settings.Coupon.FreePostage ? LanguageStrings.Yes : LanguageStrings.No,
                SharedUtils.FormatMoney(_settings.Coupon.MinimumSpend, AppController.LocalCurrency),
                _settings.Coupon.IsActive ? LanguageStrings.Yes : LanguageStrings.No,
                _settings.Coupon.RequiredProducts.Count > 0 ? LanguageStrings.Yes : LanguageStrings.No,
                _settings.Coupon.FreeProduct != null ? LanguageStrings.Yes : LanguageStrings.No,
                _settings.Coupon.ExcludedProducts.Count > 0 ? LanguageStrings.Yes : LanguageStrings.No);
        }

        public override bool SkipPage()
        {
            switch (_settings.Coupon.VoucherType)
            {
                case Enums.InvoiceVoucherType.Footprint:
                    return (true);
                default:
                    return (false);
            }
        }

        #endregion Overridden Methods

        #region Private Methods

        #endregion Private Methods
    }
}
