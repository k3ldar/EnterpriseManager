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
 *  File: VoucherForm.cs
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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;
using Library.Utils;
using Library.BOL.Vouchers;
using Library.BOL.Users;

using POS.Base.Classes;

namespace POS.Till.Forms
{
    public partial class VoucherForm : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private bool _sale;
        private decimal _value;
        private User _user;
        private bool _isCoupon = false;

        #endregion Private Members

        #region Constructors

        public VoucherForm(bool sale, User user, decimal value)
        {
            _sale = sale;
            _user = user;

            InitializeComponent();

            AppController.ApplicationController.BarcodeReceived += User_BarcodeReceived;
            AppController.ApplicationController.InterceptBarcodes = false;
        }

        #endregion Constructors
        
        #region Overridden Methods

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.TillVoucher;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppVoucherCode;
            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnOK.Text = LanguageStrings.AppMenuButtonOK;

            lblScanVoucher.Text = LanguageStrings.AppVoucherScan;
        }

        #endregion Overridden Methods

        private void User_BarcodeReceived(object sender, AppController.BarcodeEventArgs e)
        {
            txtVoucherCode.Text = e.Barcode;
        }

        /// <summary>
        /// Determines wehter a coupon (true) has been used or a voucher (false)
        /// </summary>
        public bool IsCoupon
        {
            get
            {
                return (_isCoupon);
            }
        }

        /// <summary>
        /// The value of the discount in pounds
        /// </summary>
        public decimal Discount
        {
            get
            {
                return (_value);
            }

            set
            {
                decimal vatAmount = 0;

                if (!_sale)
                    vatAmount = Library.Utils.SharedUtils.VATCalculate(value, POS.Base.Classes.AppController.LocalCountry);

                _value = Math.Round(value + vatAmount, 2, MidpointRounding.AwayFromZero);
            }
        }

        /// <summary>
        /// Code entered
        /// </summary>
        public string Code
        {
            get
            {
                return (txtVoucherCode.Text);
            }
        }

        /// <summary>
        /// Expires
        /// </summary>
        public DateTime Expires { get; set; }


        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (_sale) // selling voucher
                {
                    Vouchers.SellVoucher(txtVoucherCode.Text, _value, _user, true);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else // redeeming voucher
                {
                    _isCoupon = false;
                    Voucher voucher = Vouchers.Get(txtVoucherCode.Text);

                    if (voucher != null)
                    {
                        if (voucher.Sold)
                        {
                            if (voucher.Expires > DateTime.Now)
                            {
                                Discount = voucher.Amount;
                                _isCoupon = true;
                                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            }
                            else
                                _value = Vouchers.RedeemVoucher(txtVoucherCode.Text, _user, true);
                        }
                        else
                            _value = Vouchers.RedeemVoucher(txtVoucherCode.Text, _user, true);
                    }
                    else
                        _value = Vouchers.RedeemVoucher(txtVoucherCode.Text, _user, true);
                }
            }
            catch (Exception err)
            {
                if (err.Message.Contains(StringConstants.ERROR_INVALID_VOUCHER_CODE))
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppVoucherInvalidCode);
                    
                }
                else if (err.Message.Contains(StringConstants.ERROR_INVALID_VOUCHER_AMOUNT))
                {
                    decimal vatValue = Library.Utils.SharedUtils.VATCalculate(_value, POS.Base.Classes.AppController.LocalCountry);
                    ShowError(LanguageStrings.AppError, String.Format(LanguageStrings.AppVoucherInvalidAmount,
                        Library.Utils.SharedUtils.FormatMoney(Math.Round(_value + vatValue, 2), AppController.LocalCurrency)));
                    return;
                }
                else if (err.Message.Contains("Voucher has expired"))
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppVoucherExpired);
                    return;
                }
                else if (err.Message.Contains(StringConstants.ERROR_INVALID_VOUCHER_SOLD))
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppVoucherAlreadySold);
                    return;
                }
                else if (err.Message.Contains(StringConstants.ERROR_INVALID_VOUCHER_ISSUE_DATE))
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppVoucherNotSold);
                }
                else if (err.Message.Contains(StringConstants.ERROR_INVALID_VOUCHER_NOT_SOLD))
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppVoucherNotSold);
                }
                else if (err.Message.Contains(StringConstants.ERROR_INVALID_VOUCHER_REDEEMED))
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppVoucherRedeemed);
                }
                else if (err.Message.Contains(StringConstants.ERROR_INVALID_VOUCHER_NOT_EXIST))
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppVoucherNotExist);
                }
                else
                {
                    ShowError(LanguageStrings.AppError, err.Message);
                }

                //this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }   
        }

        private void VoucherForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AppController.ApplicationController.InterceptBarcodes = true;
        }
    }
}
