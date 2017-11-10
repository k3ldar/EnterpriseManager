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
 *  File: AssignVouchers.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Windows.Forms;


using SharedControls.Classes;
using Languages;
using Library.BOL.Vouchers;
using POS.Base.Classes;

namespace POS.VoucherManagement.Forms
{
    public partial class AssignVouchers : POS.Base.Controls.BaseTabControl
    {
        public AssignVouchers()
        {
            InitializeComponent();

            if (!AppController.ApplicationRunning)
                return;

            AppController.ApplicationController.BarcodeReceived += User_BarcodeReceived;
        }

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblDescription.Text = LanguageStrings.AppVoucherAssignDescription;
            lblScanBarcode.Text = LanguageStrings.AppVoucherScanBarcode;

            cbAddIfNotFound.Text = LanguageStrings.AppVoucherAddifNotFound;

            rbStatusMarkUnsold.Text = LanguageStrings.AppVoucherMarkAsUnsold;
            rbStatusVerify.Text = LanguageStrings.AppVoucherVerifyStatus;

            btnMarkAllAsSold.Text = LanguageStrings.AppVoucherMarkAllAsUnsold;
        }

        #endregion Overridden Methods

        void User_BarcodeReceived(object sender, AppController.BarcodeEventArgs e)
        {
            lblBarcode.Text = e.Barcode;
            Voucher voucher = Vouchers.Get(e.Barcode);

            if (rbStatusMarkUnsold.Checked && voucher != null)
            {
                Vouchers.MarkVoucherAsUnSold(AppController.ActiveUser, voucher.Code);
                lstVouchers.SelectedIndex = lstVouchers.Items.Add(String.Format(LanguageStrings.AppVoucherMarkedAsUnsold, voucher.Code));

                lstVouchers.SelectedIndex = lstVouchers.Items.Add(String.Format(LanguageStrings.AppVoucherSold,
                    voucher.Code, voucher.Amount, voucher.Sold.ToString()));
            }
            else
            {

                if (voucher == null)
                {
                    lstVouchers.SelectedIndex = lstVouchers.Items.Add(String.Format(LanguageStrings.AppVoucherNotFound, e.Barcode));

                    if (cbAddIfNotFound.Checked)
                    {
                        InputBoxResult result = InputBox.Show(LanguageStrings.AppVoucher, LanguageStrings.AppVoucherEnterAmount);

                        if (result.ReturnCode == System.Windows.Forms.DialogResult.OK)
                        {
                            Vouchers.CreateVoucher(e.Barcode, Convert.ToDecimal(result.Text));

                            lstVouchers.SelectedIndex = lstVouchers.Items.Add(String.Format(LanguageStrings.AppVoucherBarcodeCreated, e.Barcode,
                                Library.Utils.SharedUtils.FormatMoney(Convert.ToDecimal(result.Text), AppController.LocalCurrency)));
                        }
                    }
                }
                else
                    lstVouchers.SelectedIndex = lstVouchers.Items.Add(String.Format(LanguageStrings.AppVoucherSold, voucher.Code, voucher.Amount, voucher.Sold.ToString()));
            }
        }

        private void btnMarkAllAsSold_Click(object sender, EventArgs e)
        {
            Vouchers.MarkAllAsSold(AppController.ActiveUser);
        }

        private void rbStatusVerify_CheckedChanged(object sender, EventArgs e)
        {
            cbAddIfNotFound.Enabled = rbStatusVerify.Checked;
        }

        private void AssignVouchers_FormClosed(object sender, FormClosedEventArgs e)
        {
            AppController.ApplicationController.BarcodeReceived -= User_BarcodeReceived;
        }
    }
}
