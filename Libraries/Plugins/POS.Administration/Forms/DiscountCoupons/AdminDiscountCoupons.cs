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
 *  File: AdminDiscountCoupons.cs
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

using Library;
using Library.Utils;
using Library.BOL.Users;
using Library.BOL.Coupons;

using POS.Base;
using POS.Base.Classes;
using SharedControls.Classes;

namespace POS.Administration.Forms.DiscountCoupons
{
    public partial class AdminDiscountCoupons : POS.Base.Controls.BaseTabControl
    {
        #region Private Members

        private WebsiteAdministration _Admin;

        #endregion Private Members

        #region Constructors

        public AdminDiscountCoupons(WebsiteAdministration admin)
        {
            _Admin = admin;

            InitializeComponent();

            toolStripMainAdd.Image = POS.Base.Icons.AddIcon();
            toolStripMainDelete.Image = POS.Base.Icons.DeleteIcon();
            toolStripMainEdit.Image = POS.Base.Icons.EditIcon();
            toolStripMainRefresh.Image = POS.Base.Icons.RefreshIcon();
            toolStripMainEdit.Enabled = false;
            RebuildContextMenu(toolStripMain, contextMenuCoupons);
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            colHeaderActive.Text = LanguageStrings.AppActive;
            colHeaderDiscount.Text = LanguageStrings.AppDiscount;
            colHeaderExpires.Text = LanguageStrings.Expires;
            colHeaderName.Text = LanguageStrings.AppName;
            colHeaderUses.Text = LanguageStrings.AppTimesUsed;

            toolStripMainAdd.Text = LanguageStrings.AppHintNew;
            toolStripMainDelete.Text = LanguageStrings.AppHintDelete;
            toolStripMainRefresh.Text = LanguageStrings.AppHintRefresh;
            toolStripMainEdit.Text = LanguageStrings.AppHintEdit;

            toolStripMainTypes.Items.Clear();
            toolStripMainTypes.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripMainTypes.Items.Add(LanguageStrings.AppAll);
            toolStripMainTypes.Items.Add(LanguageStrings.AppDiscountCouponActiveCodes);
            toolStripMainTypes.SelectedIndex = 1;
        }

        protected override void SetPermissions()
        {
            toolStripMainAdd.Enabled = AppController.ActiveUser.MemberLevel > MemberLevel.AdminReadOnly;
            toolStripMainDelete.Enabled = false;
        }

        public override void AfterTabShow()
        {
            LoadCoupons();
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadCoupons()
        {
            this.Cursor = Cursors.WaitCursor;
            lstDiscounts.BeginUpdate();
            try
            {
                lstDiscounts.Items.Clear();
                int count = 0;
                Coupons coupons = Coupons.Get(false);

                foreach (Coupon coupon in coupons)
                {
                    if ((toolStripMainTypes.SelectedIndex == 1 && coupon.Expires > DateTime.Now && coupon.IsActive) ||
                        (toolStripMainTypes.SelectedIndex == 0))
                    {
                        ListViewItem item = lstDiscounts.Items.Add(coupon.Name);
                        item.SubItems.Add(coupon.Expires.ToShortDateString());
                        item.Tag = coupon;

                        string type = StringConstants.SYMBOL_EMPTY_STRING;

                        switch (coupon.VoucherType)
                        {
                            case Enums.InvoiceVoucherType.Footprint:
                                type = LanguageStrings.AppNotApplicable;
                                break;
                            case Enums.InvoiceVoucherType.Percent:
                                type = String.Format(StringConstants.PREFIX_AND_SUFFIX, coupon.Discount, StringConstants.SYMBOL_PERCENT);
                                break;
                            case Enums.InvoiceVoucherType.Value:
                                type = String.Format(StringConstants.PREFIX_NO_SPACE,
                                    Library.Utils.SharedUtils.FormatMoney(coupon.Discount, AppController.LocalCurrency));
                                break;
                        }

                        item.SubItems.Add(type);
                        item.SubItems.Add(coupon.Expires < DateTime.Now ? LanguageStrings.AppFalse : coupon.IsActive.ToString());
                        item.SubItems.Add(coupon.VoucherUsage.ToString());
                        item.SubItems.Add(coupon.ID.ToString());
                        count++;
                    }
                }


                string StatusText = LanguageStrings.AppDiscountCouponsFound;

                if (count == 1)
                    StatusText = LanguageStrings.AppDiscountCouponFound;

                toolStripStatusLabelCount.Text = String.Format(StatusText, count);
            }
            finally
            {
                lstDiscounts.EndUpdate();
                this.Cursor = Cursors.Arrow;
            }
        }

        /// <summary>
        /// Determines wether a new coupon code name is valid or not
        /// </summary>
        /// <param name="couponCode">name of coupon</param>
        /// <returns>true if valid, false otherwise</returns>
        private bool ValidNewDiscountCode(string couponCode)
        {
            bool Result = false;

            if (String.IsNullOrEmpty(couponCode))
            {
                ShowError(LanguageStrings.AppDiscountCouponNewCoupon, LanguageStrings.AppDiscountCouponNewEmpty);
                return (Result);
            }

            Result = Coupons.Get(couponCode) == null;

            if (!Result)
                ShowError(LanguageStrings.AppDiscountCouponNewCoupon, String.Format(LanguageStrings.AppDiscountCouponNewExists, couponCode));

            return (Result);
        }

        private void lstDiscounts_DoubleClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                foreach (ListViewItem itm in lstDiscounts.SelectedItems)
                {
                    Coupon coupon = (Coupon)itm.Tag;

                    if (coupon != null)
                    {
                        if (Classes.NewDiscountCouponWrapper.ShowNewDiscountWizard(coupon))
                            LoadCoupons();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void cbActiveCodes_CheckedChanged(object sender, EventArgs e)
        {
            LoadCoupons();
        }


        #region ToolStrip Buttons

        private void toolStripMainAdd_Click(object sender, EventArgs e)
        {
            Coupon coupon = new Coupon(-1, String.Empty, DateTime.Now.AddDays(10), false,
                0, null, null, Enums.InvoiceVoucherType.Footprint, 0, false, 5000, 50.0m, -2, DateTime.Now.AddDays(1), false);
            if (Classes.NewDiscountCouponWrapper.ShowNewDiscountWizard(coupon))
                LoadCoupons();
        }

        private void toolStripMainRefresh_Click(object sender, EventArgs e)
        {
            LoadCoupons();
        }

        private void toolStripMainEdit_Click(object sender, EventArgs e)
        {
            lstDiscounts_DoubleClick(sender, e);
        }

        #endregion ToolStrip Buttons

        private void lstDiscounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripMainEdit.Enabled = lstDiscounts.SelectedItems.Count > 0;
        }

        #endregion Private Methods
    }
}
