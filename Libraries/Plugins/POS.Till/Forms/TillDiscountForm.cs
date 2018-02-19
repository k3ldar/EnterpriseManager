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
 *  File: TillDiscountForm.cs
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
using Library.BOL.Basket;

using POS.Base.Classes;

#pragma warning disable IDE1006

namespace POS.Till.Forms
{
    public partial class TillDiscountForm : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private ShoppingBasket _basket;

        #endregion Private Members

        #region Constructors

        public TillDiscountForm()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Current Shopping Basket
        /// </summary>
        public ShoppingBasket Basket
        {
            get
            {
                return (_basket);
            }

            set
            {
                _basket = value;
            }
        }

        #endregion Properties

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.TillDiscount;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppTillApplyDiscount;

            btnApplyDiscount.Text = LanguageStrings.AppMenuButtonApplyDiscount;
            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;

            rbCashAmount.Text = LanguageStrings.AppTillDiscountValueDesc;
            rbCoupon.Text = LanguageStrings.AppTillDiscountCouponDesc;
            rbPercent.Text = LanguageStrings.AppTillDiscountPercentDesc;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void rbCoupon_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == rbCoupon)
            {
                lblVoucherDescription.Text = LanguageStrings.AppTillCouponCode;
                txtVoucherDescription.Text = String.Empty;
                txtDiscount.Enabled = false;
                lblDiscountPercent.Enabled = false;
                txtVoucherDescription.Focus();
            }
            else
            {
                lblVoucherDescription.Text = LanguageStrings.AppTillDiscountReason;
                txtVoucherDescription.Text = LanguageStrings.AppTillDiscountGoodWill;
                lblDiscountPercent.Enabled = true;
                txtDiscount.Enabled = true;
            }

            if (sender == rbPercent)
            {
                _basket.VoucherType = Enums.InvoiceVoucherType.Percent;
                lblDiscountPercent.Text = LanguageStrings.AppTillDiscountPercent;
            }
            else
            {
                _basket.VoucherType = Enums.InvoiceVoucherType.Value;
                lblDiscountPercent.Text = String.Format(LanguageStrings.AppTillDiscountValue, AppController.LocalCountry.CurrencySymbol);
            }
        }

        private void btnApplyDiscount_Click(object sender, EventArgs e)
        {
            if (rbCoupon.Checked)
            {
                string resultText = String.Empty;

                if (!_basket.ValidateCouponCode(txtVoucherDescription.Text, ref resultText))
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppTillDiscountCouponInvalid +
                        StringConstants.SYMBOL_CRLF_DOUBLE + resultText);
            }
            else
            {
                int amount = 0;

                if (String.IsNullOrEmpty(txtDiscount.Text) || !int.TryParse(txtDiscount.Text, out amount) && amount > -1)
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppTillDiscountInvalid);
                    return;
                }

                if (rbPercent.Checked)
                {
                    if (amount > 100 || amount < 0)
                    {
                        ShowError(LanguageStrings.AppError, LanguageStrings.AppTillDiscountPercentInvalid);
                        return;
                    }

                    if (!String.IsNullOrEmpty(txtVoucherDescription.Text) && !String.IsNullOrEmpty(txtDiscount.Text))
                        _basket.ApplyDiscount(Convert.ToInt32(txtDiscount.Text), txtVoucherDescription.Text);
                }
                else
                {
                    if (amount > _basket.SubTotalAmount)
                    {
                        ShowError(LanguageStrings.AppError, LanguageStrings.AppTillDiscountExceedsBasket);
                        return;
                    }
                    else
                    {
                        _basket.ApplyDiscount((decimal)amount, txtVoucherDescription.Text);
                    }
                }
            }
        }

        private void TillDiscountForm_Shown(object sender, EventArgs e)
        {
            rbCoupon_CheckedChanged(rbCoupon, e);
        }

        #endregion Private Methods
    }
}
