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
 *  File: Step4.cs
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

using Languages;
using Library;
using Library.BOL.Coupons;
using Library.BOL.Products;
using POS.Base.Classes;
using POS.Administration.Classes;
using SharedControls.WizardBase;

namespace POS.Administration.Controls.Wizards.Coupons
{
    public partial class Step4 : BaseWizardPage
    {
        #region Private Members

        private CouponSettings _settings;

        #endregion Private Members

        #region Constructors

        public Step4()
        {
            InitializeComponent();
        }

        public Step4(CouponSettings settings)
            : this()
        {
            _settings = settings;

            lblFreeProduct.Visible = false;
            cmbFreeProduct.Visible = false;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            cbFreeProduct.Text = LanguageStrings.AppDiscountFreeProduct;
            lblFreeProduct.Text = LanguageStrings.AppDiscountCouponFreeProduct;
        }

        public override bool NextClicked()
        {

            if (cbFreeProduct.Checked && cmbFreeProduct.SelectedIndex == -1)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppDiscountCouponSaveFreeProduct);
                cmbFreeProduct.DroppedDown = true;
                return (false);
            }

            if (cbFreeProduct.Checked)
                _settings.Coupon.FreeProduct = (ProductCost)cmbFreeProduct.Items[cmbFreeProduct.SelectedIndex];

            return base.NextClicked();
        }

        public override void PageShown()
        {
            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.DiscountCouponStep4;
            cbFreeProduct.Checked = _settings.Coupon.FreeProduct != null;

            if (_settings.Coupon.FreeProduct != null)
            {
                for (int i = 0; i < cmbFreeProduct.Items.Count; i++)
                {
                    ProductCost item = (ProductCost)cmbFreeProduct.Items[i];

                    if (item.ID == _settings.Coupon.FreeProduct.ID)
                    {
                        cmbFreeProduct.SelectedIndex = i;
                        break;
                    }
                }
            }
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

        private void cbFreeProduct_CheckedChanged(object sender, EventArgs e)
        {
            cmbFreeProduct.Visible = cbFreeProduct.Checked;
            lblFreeProduct.Visible = cbFreeProduct.Checked;

            if (cbFreeProduct.Checked && cmbFreeProduct.Items.Count == 0)
            {
                foreach (ProductType primaryType in ProductTypes.Get())
                {
                    MainWizardForm.Cursor = Cursors.WaitCursor;
                    try
                    {
                        Library.BOL.Products.Products _products = Library.BOL.Products.Products.Get(primaryType, 1, 1000);

                        foreach (Product product in _products)
                        {
                            foreach (ProductCost cost in product.ProductCosts)
                            {
                                cmbFreeProduct.Items.Add(cost);
                            }
                        }
                    }
                    finally
                    {
                        MainWizardForm.Cursor = Cursors.Arrow;
                    }
                }
            }
        }

        private void cmbFreeProduct_Format(object sender, ListControlConvertEventArgs e)
        {
            ProductCost ci = (ProductCost)e.ListItem;

            e.Value = String.Format(StringConstants.PRODUCT_COST_SIZE_TYPE,
                ci == null ? String.Empty : ci.ProductCostType.Description, ci.Product.Name.Trim(), ci.Size.Trim());
        }

        #endregion Private Methods
    }
}
