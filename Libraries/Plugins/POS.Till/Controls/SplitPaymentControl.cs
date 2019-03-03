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
 *  File: SplitPaymentControl.cs
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

using SharedBase.BOL.Vouchers;
using SharedBase.BOL.Orders;
using SharedBase.Utils;
using POS.Base.Classes;

namespace POS.Till.Controls
{
    public partial class SplitPaymentControl : SharedControls.BaseControl
    {
        #region Private Members

        private decimal _totalDue = 0.00m;
        private decimal _tendered = 0.00m;
        private decimal _totalVouchers = 0.00m;

        #endregion Private Members

        #region Constructors

        public SplitPaymentControl()
        {
            InitializeComponent();

            if (!DesignMode)
                lblChangeDue.Text = SharedBase.Utils.SharedUtils.FormatMoney(0.0m, AppController.LocalCurrency);
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblAmountDue.Text = Languages.LanguageStrings.AppAmountDue;
            lblBalance.Text = Languages.LanguageStrings.AppBalanceDue;
            lblTendered.Text = Languages.LanguageStrings.AppTendered;
            lblTotalCard.Text = Languages.LanguageStrings.AppTotalCard;
            lblTotalCash.Text = Languages.LanguageStrings.AppTotalCash;
            lblTotalCheques.Text = Languages.LanguageStrings.AppTotalCheque;
            lblTotalVouchers.Text = Languages.LanguageStrings.AppTotalVoucher;
        }

        #endregion Overridden Methods

        #region Properties

        /// <summary>
        /// Total amount due for order
        /// </summary>
        public decimal TotalDue
        {
            get
            {
                return (_totalDue);
            }

            set
            {
                _totalDue = Math.Round(value, 2);
                lblAmountDueTotal.Text = SharedBase.Utils.SharedUtils.FormatMoney(_totalDue, AppController.LocalCurrency);
            }
        }

        /// <summary>
        /// Determines wether the correct payment has been entered or not
        /// </summary>
        public bool CorrectPayment
        {
            get
            {
                return (_totalDue - _tendered == 0.00m);
            }
        }

        /// <summary>
        /// Determines wether payment is less than
        /// </summary>
        public bool PaymentLessThan
        {
            get
            {
                return (_tendered < _totalDue);
            }
        }

        #endregion Properties

        #region Public Methods

        public void Init()
        {
            AppController.ApplicationController.BarcodeReceived += User_BarcodeReceived;
        }

        public void AddSplitPayment(Order order)
        {
            RedeemVouchers();

            SharedBase.BOL.SplitPayments.SplitPayments.SplitPaymentAdd(order,
                Shared.Utilities.StrToDecimal(txtTotalCash.Text, 0.00m, null),
                Shared.Utilities.StrToDecimal(txtTotalCheque.Text, 0.00m, null),
                Shared.Utilities.StrToDecimal(txtTotalCard.Text, 0.00m, null), 
                _totalVouchers);
            
        }

        public void RedeemVouchers()
        {
            foreach (string item in lstVouchers.Items)
            {
                try
                {
                    Vouchers.RedeemVoucher(item, AppController.ActiveUser, false);
                }
                catch //(Exception err)
                {
                    //Vouchers.EmailVoucherFailure(item, AppController.ActiveUser.UserName, err.Message, AppController.ActiveUser.Email);
                }
            }
        }

        public void AddVoucher(string voucherCode)
        {
            try
            {
                if (lstVouchers.Items.Contains(voucherCode))
                    return;

                decimal voucherAmount = Vouchers.RedeemVoucher(voucherCode, AppController.ActiveUser, true);

                if (voucherAmount == 0)
                    return;

                if (VoucherIsInList(voucherCode))
                {
                    ShowError(Languages.LanguageStrings.AppError, Languages.LanguageStrings.AppVoucherScanned);
                    return;
                }
                else
                {
                    lstVouchers.Items.Add(voucherCode);
                    decimal vatAmount = SharedBase.Utils.SharedUtils.VATCalculate(voucherAmount, AppController.LocalCountry);
                    voucherAmount = Math.Round(voucherAmount + vatAmount, 2, MidpointRounding.AwayFromZero);
                    _totalVouchers += Convert.ToDecimal(voucherAmount);

                    txtTotalVoucher.Text = SharedBase.Utils.SharedUtils.FormatMoney(_totalVouchers, AppController.LocalCurrency);
                }
            }
            catch (Exception err)
            {
                if (err.Message.Contains(StringConstants.ERROR_INVALID_VOUCHER_CODE))
                    ShowError(Languages.LanguageStrings.AppErrorVoucher, Languages.LanguageStrings.AppErrorVoucherInvalidCode);
                else if (err.Message.Contains(StringConstants.ERROR_INVALID_VOUCHER_AMOUNT))
                    ShowError(Languages.LanguageStrings.AppErrorVoucher, Languages.LanguageStrings.AppErrorVoucherInvalidAmount);
                else if (err.Message.Contains(StringConstants.ERROR_INVALID_VOUCHER_ISSUE_DATE))
                    ShowError(Languages.LanguageStrings.AppErrorVoucher, Languages.LanguageStrings.AppErrorVoucherNotSold);
                else if (err.Message.Contains(StringConstants.ERROR_INVALID_VOUCHER_NOT_SOLD))
                    ShowError(Languages.LanguageStrings.AppErrorVoucher, Languages.LanguageStrings.AppErrorVoucherNotSold);
                else if (err.Message.Contains(StringConstants.ERROR_INVALID_VOUCHER_REDEEMED))
                    ShowError(Languages.LanguageStrings.AppErrorVoucher, Languages.LanguageStrings.AppErrorVoucherRedeemed);
                else if (err.Message.Contains(StringConstants.ERROR_INVALID_VOUCHER_NOT_EXIST))
                    ShowError(Languages.LanguageStrings.AppErrorVoucher, Languages.LanguageStrings.AppErrorVoucherNotExist);
                else
                    ShowError(Languages.LanguageStrings.AppErrorVoucher, err.Message);
            }
        }

        #endregion Public Methods

        #region Private Methods

        void User_BarcodeReceived(object sender, AppController.BarcodeEventArgs e)
        {
            AddVoucher(e.Barcode);
        }

        private void txtTotalCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.Contains(StringConstants.SYMBOL_FULL_STOP))
                    e.Handled = true;
                else
                    e.Handled = false;
            }
            else
                e.Handled = !StringConstants.SPLIT_PAYMENT_VALID_CHARS.Contains(e.KeyChar.ToString());
        }

        private void txtTotalCash_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void UpdateTotals()
        {
            _tendered = 0.00m;

            _tendered += Shared.Utilities.StrToDecimal(txtTotalCash.Text, 0.00m, null);
            _tendered += Shared.Utilities.StrToDecimal(txtTotalCheque.Text, 0.00m, null);
            _tendered += Shared.Utilities.StrToDecimal(txtTotalCard.Text, 0.00m, null);
            _tendered += _totalVouchers;

            lblTotalTendered.Text = SharedBase.Utils.SharedUtils.FormatMoney(_tendered, AppController.LocalCurrency);

            lblChangeDue.Text = SharedBase.Utils.SharedUtils.FormatMoney(_totalDue - _tendered, AppController.LocalCurrency);

            if (_totalDue - _tendered >= 0.00m)
                lblChangeDue.ForeColor = Color.Black;
            else
                lblChangeDue.ForeColor = Color.Red;
        }

        private void lstVouchers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lstVouchers.SelectedIndex > -1)
            {
                if (e.KeyChar == StringConstants.SYMBOL_BACK_SPACE || e.KeyChar == StringConstants.SYMBOL_LETTER_D)
                {
                    try
                    {
                        decimal voucherAmount = Vouchers.RedeemVoucher((string)lstVouchers.Items[lstVouchers.SelectedIndex], AppController.ActiveUser, true);
                        decimal voucherVAT = SharedBase.Utils.SharedUtils.VATCalculate(voucherAmount, AppController.LocalCountry);
                        voucherAmount = Math.Round(voucherAmount + voucherVAT, 2, MidpointRounding.AwayFromZero);
                        _totalVouchers -= voucherAmount;
                        lstVouchers.Items.RemoveAt(lstVouchers.SelectedIndex);
                        txtTotalVoucher.Text = SharedBase.Utils.SharedUtils.FormatMoney(_totalVouchers, AppController.LocalCurrency);
                        UpdateTotals();
                    }
                    catch
                    {
                        lstVouchers.Items.RemoveAt(lstVouchers.SelectedIndex);
                    }
                }
            }
        }

        #region Pop up Voucher Menu

        private void pumVouchers_Opening(object sender, CancelEventArgs e)
        {
            pumVouchersRemove.Enabled = lstVouchers.SelectedIndex > -1;
        }

        private void pumVouchersAdd_Click(object sender, EventArgs e)
        {
            Forms.VoucherForm frm = new Forms.VoucherForm(false, AppController.ActiveUser, 0);
            try
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        if (VoucherIsInList(frm.Code))
                        {
                            ShowError(Languages.LanguageStrings.AppError, Languages.LanguageStrings.AppVoucherScanned);
                            return;
                        }
                        else
                        {
                            _totalVouchers += frm.Discount;
                            lstVouchers.Items.Add(frm.Code);
                            txtTotalVoucher.Text = SharedBase.Utils.SharedUtils.FormatMoney(_totalVouchers, AppController.LocalCurrency);
                            UpdateTotals();
                        }
                    }
                    catch
                    {
                        lstVouchers.Items.RemoveAt(lstVouchers.SelectedIndex);
                    }
                }
            }
            finally
            {
                frm.Close();
                frm.Dispose();
                frm = null;
            }
        }

        private void pumVouchersRemove_Click(object sender, EventArgs e)
        {
            try
            {
                decimal voucherAmount = Vouchers.RedeemVoucher((string)lstVouchers.Items[lstVouchers.SelectedIndex], AppController.ActiveUser, true);
                decimal voucherVAT = SharedBase.Utils.SharedUtils.VATCalculate(voucherAmount, AppController.LocalCountry);
                voucherAmount = Math.Round(voucherAmount + voucherVAT, 2, MidpointRounding.AwayFromZero);
                _totalVouchers -= voucherAmount;
                lstVouchers.Items.RemoveAt(lstVouchers.SelectedIndex);
                txtTotalVoucher.Text = SharedBase.Utils.SharedUtils.FormatMoney(_totalVouchers, AppController.LocalCurrency);
                UpdateTotals();
            }
            catch
            {
                lstVouchers.Items.RemoveAt(lstVouchers.SelectedIndex);
            }
        }

        #endregion Pop up Voucher Menu

        private bool VoucherIsInList(string voucherCode)
        {
            foreach (string s in lstVouchers.Items)
            {
                if (s == voucherCode)
                    return (true);
            }

            return (false);
        }

        #endregion Private Methods
    }
}
