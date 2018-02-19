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
 *  File: Step5.cs
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
    public partial class Step5 : BaseWizardPage
    {
        #region Private Members

        private CouponSettings _settings;

        #endregion Private Members

        #region Constructors

        public Step5()
        {
            InitializeComponent();
        }

        public Step5(CouponSettings settings)
            :this()
        {
            _settings = settings;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblExcludedProduct.Text = LanguageStrings.AppDiscountCouponExcludedProduct;
            cbExcludedProducts.Text = LanguageStrings.AppDiscountExcludedProducts;

            chSKU.Text = LanguageStrings.AppSKU;
            chProductType.Text = LanguageStrings.AppProductType;
            chProductName.Text = LanguageStrings.AppProductName;
            chProductSize.Text = LanguageStrings.AppProductSize;

            pumInvertSelection.Text = LanguageStrings.AppMenuInvertSelection;
            pumSelectAll.Text = LanguageStrings.AppMenuSelectAll;
            pumUnselectAll.Text = LanguageStrings.AppMenuUnSelectAll;
        }

        public override bool NextClicked()
        {
            if (cbExcludedProducts.Checked)
            {
                if (clbExcludedProducts.CheckedItems.Count == 0)
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppProductsSelectExcluded);
                    return (false);
                }

                _settings.Coupon.ExcludedProducts.Clear();

                // add the required products to the coupon
                foreach (ListViewItem item in clbExcludedProducts.CheckedItems)
                {
                    _settings.Coupon.ExcludedProducts.Add((ProductCost)item.Tag);
                }
            }
            else
            {
                _settings.Coupon.ExcludedProducts.Clear();
            }


            return base.NextClicked();
        }

        public override void PageShown()
        {
            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.DiscountCouponStep5;

            if (_settings.Coupon.ExcludedProducts.Count > 0)
            {
                cbExcludedProducts.Checked = true;

                for (int i = 0; i < clbExcludedProducts.Items.Count; i++)
                {
                    ProductCost item = (ProductCost)clbExcludedProducts.Items[i].Tag;
                    clbExcludedProducts.Items[i].Checked = _settings.Coupon.ExcludedProducts.Contains(item) ? true : false;
                }
            }
            else
            {
                cbSpecificProducts_CheckedChanged(this, EventArgs.Empty);
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

        private void cbSpecificProducts_CheckedChanged(object sender, EventArgs e)
        {
            Enums.InvoiceVoucherType type = _settings.Coupon.VoucherType;

            MainWizardForm.Cursor = Cursors.WaitCursor;
            clbExcludedProducts.BeginUpdate();
            try
            {
                clbExcludedProducts.Visible = cbExcludedProducts.Checked;
                lblExcludedProduct.Visible = cbExcludedProducts.Checked;

                if (cbExcludedProducts.Checked && clbExcludedProducts.Items.Count == 0)
                {
                    foreach (ProductType primaryType in ProductTypes.Get())
                    {
                        Library.BOL.Products.Products _products = Library.BOL.Products.Products.Get(primaryType, 1, 1000);

                        foreach (Product product in _products)
                        {
                            foreach (ProductCost cost in product.ProductCosts)
                            {
                                ListViewItem item = new ListViewItem(cost.SKU);
                                item.SubItems.Add(primaryType.Description);
                                item.SubItems.Add(product.Name);
                                item.SubItems.Add(cost.Size);
                                item.Tag = cost;
                                clbExcludedProducts.Items.Add(item);
                            }
                        }
                    }
                }
            }
            finally
            {
                clbExcludedProducts.EndUpdate();
                MainWizardForm.Cursor = Cursors.Arrow;
            }
        }

        #region Popup Menu

        private void pumSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in clbExcludedProducts.Items)
            {
                item.Checked = true;
            }
        }

        private void pumUnselectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in clbExcludedProducts.Items)
            {
                item.Checked = false;
            }
        }

        private void pumInvertSelection_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in clbExcludedProducts.Items)
            {
                item.Checked = !item.Checked;
            }
        }

        #endregion Popup Menu

        #endregion Private Methods
    }
}
