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
 *  File: AdminDiscountCouponEdit.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  07/06/2017  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SieraDelta.Languages;

using SieraDelta.Library;
using SieraDelta.Library.Utils;
using SieraDelta.Library.BOL.Users;
using SieraDelta.Library.BOL.Coupons;
using SieraDelta.Library.BOL.Products;

using SieraDelta.POS.Classes;


namespace SieraDelta.POS.Administration.Forms.DiscountCoupons
{
    public partial class AdminDiscountCouponEdit : SieraDelta.POS.Forms.BaseForm
    {
        #region Private Members

        private WebsiteAdministration _Admin;
        private Coupon _coupon;

        #endregion Private Members

        #region Constructors

        public AdminDiscountCouponEdit(WebsiteAdministration admin, Coupon coupon)
        {
            _Admin = admin;
            _coupon = coupon;

            InitializeComponent();

            PopulateProducts(cmbFreeProduct, _coupon.FreeProduct);
            PopulateProducts(cmbMainProduct, _coupon.MainProduct);

            txtName.Text = _coupon.Name;
            spnDiscount.Value = _coupon.Discount < 0 ? 0 : _coupon.Discount;
            dtpExpires.Value = _coupon.Expires == DateTime.MinValue ? DateTime.Now : _coupon.Expires;
            txtMinSpend.Text = _coupon.MinimumSpend.ToString();
            cmbMainProduct.SelectedValue = _coupon.MainProduct == null ? null : _coupon.MainProduct.ID.ToString();
            cmbFreeProduct.SelectedValue = _coupon.FreeProduct == null ? null : _coupon.FreeProduct.ID.ToString();
            cbFreePostage.Checked = _coupon.FreePostage;
            numMaxUsage.Value = _coupon.MaxUsage;
            cbActive.Checked = _coupon.IsActive;

            foreach (Enums.InvoiceVoucherType type in (Enums.InvoiceVoucherType[])Enum.GetValues(typeof(Enums.InvoiceVoucherType)))
            {
                int idx = cmbVoucherType.Items.Add(type);

                if (type == _coupon.VoucherType)
                    cmbVoucherType.SelectedIndex = idx;
            }
        }

        #endregion Constructors

        #region Overridden Methods

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppDiscountCouponEditAdministration;

            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnSave.Text = LanguageStrings.AppMenuButtonSave;

            lblActive.Text = LanguageStrings.AppActive;
            lblCouponName.Text = LanguageStrings.AppName;
            lblExpires.Text = LanguageStrings.AppExpires;
            lblFreePostage.Text = LanguageStrings.AppDiscountCouponFreePostage;
            lblFreeProduct.Text = LanguageStrings.AppDiscountCouponFreeProduct;
            lblMainProduct.Text = LanguageStrings.AppDiscountCouponMainProduct;
            lblMaximumUsage.Text = LanguageStrings.AppMaximumUsage;
            lblMinimumSpend.Text = LanguageStrings.AppDiscountCouponMinimumSpend;
            lblVoucherType.Text = LanguageStrings.AppDiscountCouponVoucherType;
        }

        protected override void SetPermissions()
        {
            btnSave.Enabled = AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AllowSave) &&
                AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AdministerDiscountCoupons);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dtpExpires.Value < DateTime.Now.AddDays(1))
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppDiscountCouponSaveInvalidExpires);
            }
            else
            {
                // has the name changed?  if so is there another one with the same name
                Coupon cpn = Coupons.Get(txtName.Text);

                if (cpn != null && cpn.ID != _coupon.ID)
                {
                    ShowError(LanguageStrings.AppError, 
                        String.Format(LanguageStrings.AppDiscountCouponNewExists, txtName.Text));
                    return;
                }

                if (cmbMainProduct.SelectedIndex == -1)
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppDiscountCouponSaveMainProduct);
                    cmbMainProduct.DroppedDown = true;
                    return;
                }

                if (cmbFreeProduct.SelectedIndex == -1)
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppDiscountCouponSaveFreeProduct);
                    cmbFreeProduct.DroppedDown = true;
                    return;
                }

                if (cmbVoucherType.SelectedIndex == -1)
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppDiscountCouponSaveVoucherType);
                    cmbVoucherType.DroppedDown = true;
                    return;
                }

                decimal minSpend = 0.00m;

                if (!decimal.TryParse(txtMinSpend.Text, out minSpend))
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppDiscountCouponSaveMinimumSpend);
                    txtMinSpend.Focus();
                    return;
                }

                _coupon.Name = txtName.Text.Trim();
                _coupon.Expires = dtpExpires.Value;
                _coupon.Discount = (int)spnDiscount.Value;
                _coupon.FreePostage = cbFreePostage.Checked;
                _coupon.MinimumSpend = minSpend;
                _coupon.MaxUsage = Convert.ToInt32(numMaxUsage.Value);
                _coupon.VoucherType = (Enums.InvoiceVoucherType)Enum.Parse(typeof(Enums.InvoiceVoucherType), cmbVoucherType.Text);
                _coupon.IsActive = cbActive.Checked;

                ComboItem ci = (ComboItem)cmbMainProduct.SelectedItem;
                _coupon.MainProduct = ci.Cost;

                ci = (ComboItem)cmbFreeProduct.SelectedItem;
                _coupon.FreeProduct = ci.Cost;

                try
                {
                    _coupon.Save();
                }
                catch (Exception err)
                {
                    if (err.Message.Contains(StringConstants.ERROR_VIOLATION_COUPON))
                    {
                        ShowError(LanguageStrings.AppDiscountCouponName,
                            String.Format(LanguageStrings.AppDiscountCouponSaveNameExists, _coupon.Name));
                        return;
                    }
                    else
                        throw;
                }

                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void PopulateProducts(ComboBox combo, ProductCost productCost)
        {
            combo.Items.Clear();

            combo.Items.Add(new ComboItem(null, LanguageStrings.AppNotApplicable));

            foreach (ProductType primaryType in ProductTypes.Get())
            {
                SieraDelta.Library.BOL.Products.Products _products = SieraDelta.Library.BOL.Products.Products.Get(primaryType, 1, 1000);

                foreach (Product product in _products)
                {
                    foreach (ProductCost cost in product.ProductCosts)
                    {
                        int Idx = combo.Items.Add(new ComboItem(cost, 
                            String.Format(StringConstants.PREFIX_AND_SUFFIX_HYPHEN, product.Name, cost.Size)));

                        if (productCost != null)
                        {
                            if (cost.ID == productCost.ID)
                            {
                                combo.SelectedIndex = Idx;
                            }
                        }
                    }
                }
            }

            if (productCost == null)
                combo.SelectedIndex = 0;
        }

        private void cmbMainProduct_Format(object sender, ListControlConvertEventArgs e)
        {
            ComboItem ci = (ComboItem)e.ListItem;

            e.Value = String.Format(StringConstants.PREFIX_AND_SUFFIX_HYPHEN, 
                ci.Cost == null ? String.Empty : ci.Cost.ProductCostType.Description, ci.Text);
        }

        private void cmbFreeProduct_Format(object sender, ListControlConvertEventArgs e)
        {
            ComboItem ci = (ComboItem)e.ListItem;

            e.Value = String.Format(StringConstants.PREFIX_AND_SUFFIX_HYPHEN, 
                ci.Cost == null ? String.Empty : ci.Cost.ProductCostType.Description, ci.Text);
        }

        private void cmbVoucherType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enums.InvoiceVoucherType type = (Enums.InvoiceVoucherType)Enum.Parse(typeof(Enums.InvoiceVoucherType), cmbVoucherType.Text);

            cmbMainProduct.Enabled = true;
            lblMainProduct.Enabled = true;

            switch (type)
            {
                case Enums.InvoiceVoucherType.FreeProduct:
                    cmbMainProduct.Enabled = false;
                    lblMainProduct.Enabled = false;
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
