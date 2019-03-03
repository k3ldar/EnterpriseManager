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
 *  File: AdminProductItemEdit.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.ComponentModel;
using System.Windows.Forms;

using SharedBase;
using SharedBase.Utils;
using SharedBase.BOL.Products;
using POS.Base.Classes;

#pragma warning disable IDE1006

namespace POS.Administration.Controls
{
    public partial class AdminProductItemEdit : SharedControls.BaseControl
    {
        #region Private Members

        ProductCost _productCost;

        #endregion Private Members

        #region Constructor

        public AdminProductItemEdit()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                LoadMemberLevels();

                LoadProductTypes();

                AppController.ApplicationController.TableIDChanged += User_TableIDChanged;
                AppController.ApplicationController.ActiveControlChanged += User_ActiveControlChanged;

                lblPrice1.Text = SharedBase.LibraryHelperClass.SettingsGet(StringConstants.PRICE_DESCRIPTION_1, StringConstants.PRICE_1);
                lblPrice2.Text = SharedBase.LibraryHelperClass.SettingsGet(StringConstants.PRICE_DESCRIPTION_2, StringConstants.PRICE_2);
                lblPrice3.Text = SharedBase.LibraryHelperClass.SettingsGet(StringConstants.PRICE_DESCRIPTION_3, StringConstants.PRICE_3);
            }

            HintControl = lblDescription;
        }

        public AdminProductItemEdit(ProductCost productcost)
        {
            _productCost = productcost;

            InitializeComponent();

            LoadMemberLevels();

            txtCost1.Text = _productCost.Cost1.ToString();
            txtCost2.Text = _productCost.Cost2.ToString();
            txtCost3.Text = _productCost.Cost3.ToString();
            txtSize.Text = _productCost.Size;
            txtSKU.Text = _productCost.SKU;
            cbOutOfStock.Checked = _productCost.OutOfStock;
            cbGiftWrap.Checked = _productCost.IsGiftWrapping;

            LoadProductTypes();

            cmbProductType.SelectedIndex = cmbProductType.Items.IndexOf(productcost.ProductCostType.Description);

            AppController.ApplicationController.TableIDChanged += User_TableIDChanged;
        }

        #endregion Constructor

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblGiftWrap.Text = Languages.LanguageStrings.AppGiftWrap;
            lblMemberLevel.Text = Languages.LanguageStrings.AppMemberLevel;
            lblOutOfStock.Text = Languages.LanguageStrings.AppOutOfStock;
            lblProductCode.Text = Languages.LanguageStrings.AppProductCode;
            lblProductType.Text = Languages.LanguageStrings.AppProductType;
            lblSize.Text = Languages.LanguageStrings.AppProductSize;
            lblSaving.Text = Languages.LanguageStrings.AppProductSaving;
        }

        #endregion Overridden Methods

        #region Properties

        public string SKU
        {
            get
            {
                return (txtSKU.Text);
            }
        }

        #endregion Properties

        #region Public Methods

        public bool Save()
        {
            bool Result = false;
            try
            {
                _productCost.SKU = txtSKU.Text;
                _productCost.Size = txtSize.Text;
                _productCost.Cost1 = Convert.ToDecimal(txtCost1.Text);
                _productCost.Cost2 = Convert.ToDecimal(txtCost2.Text);
                _productCost.Cost3 = Convert.ToDecimal(txtCost3.Text);
                _productCost.MemberLevel = cmbMemberLevel.SelectedIndex;
                _productCost.OutOfStock = cbOutOfStock.Checked;
                _productCost.IsGiftWrapping = cbGiftWrap.Checked;
                _productCost.ProductCostType = (ProductCostType)cmbProductType.Items[cmbProductType.SelectedIndex];
                _productCost.Discount = Shared.Utilities.CheckMinMax(
                    Shared.Utilities.StrToDecimal(txtDiscount.Text, 0.00m, null), 0.00m, 100.00m);
                _productCost.Saving = (double)udSaving.Value;
                _productCost.ItemType = _productCost.ProductCostType.ItemType;
                _productCost.Save();
                Result = true;
            }
            catch (Exception err)
            {
                if (err.Message.Contains(StringConstants.ERROR_INPUT_STRING))
                    ShowError(Languages.LanguageStrings.AppErrorInvalidNumber, 
                        Languages.LanguageStrings.AppErrorInvalidCost);
                else
                    throw;
            }

            return (Result);
        }

        public void Refresh(ProductCost productCost)
        {
            _productCost = productCost;

            txtCost1.Text = _productCost.Cost1.ToString();
            txtCost2.Text = _productCost.Cost2.ToString();
            txtCost3.Text = _productCost.Cost3.ToString();
            txtSize.Text = _productCost.Size;
            txtSKU.Text = _productCost.SKU;
            cbOutOfStock.Checked = _productCost.OutOfStock;
            cbGiftWrap.Checked = _productCost.IsGiftWrapping;
            cmbMemberLevel.SelectedIndex = _productCost.MemberLevel;
            txtDiscount.Text = _productCost.Discount.ToString();
            udSaving.Value = (decimal)_productCost.Saving;

            LoadProductTypes();
        }


        #endregion Public Methods

        #region Protected Methods

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            lblDescription.Text = GetHintText(this.Name.ToString(), this.ActiveControl.Name.ToString());
        }

        #endregion Protected Methods

        #region Private Methods

        private void User_ActiveControlChanged(object sender, EventArgs e)
        {
            lblDescription.Text = GetHintText(this.Name.ToString(), this.ActiveControl.Name.ToString());
        }

        private void User_TableIDChanged(object sender, AppController.TableIDChangedEventArgs e)
        {
            //is the id of the item we are looking at changing?
            switch (e.Table)
            {
                case StringConstants.TABLE_PRODUCT_ITEMS:

                    if (e.OldID == _productCost.ID)
                    {
                        _productCost.ID = e.NewID;
                    }

                    break;
                case StringConstants.TABLE_PRODUCTS:

                    if (e.OldID == _productCost.ProductID)
                    {
                        _productCost.Product.ID = e.NewID;
                    }

                    break;
            }
        }

        private void LoadMemberLevels()
        {
            cmbMemberLevel.Items.Clear();

            foreach (MemberLevel memberLevel in (MemberLevel[])Enum.GetValues(typeof(MemberLevel)))
            {
                cmbMemberLevel.Items.Add(memberLevel);
            }

            cmbMemberLevel.SelectedIndex = 0;
        }

        private void LoadProductTypes()
        {
            cmbProductType.Items.Clear();

            foreach (ProductCostType item in ProductCostTypes.Get())
            {
                int index = cmbProductType.Items.Add(item);

                if (_productCost != null && item.ID == _productCost.ProductCostType.ID)
                    cmbProductType.SelectedIndex = index;
            }
        }

        private void cmbProductType_Format(object sender, ListControlConvertEventArgs e)
        {
            ProductCostType item = (ProductCostType)e.ListItem;
            e.Value = item.Description;
        }

        private void btnCost1Calculate_Click(object sender, EventArgs e)
        {
            decimal netAmount = SharedUtils.StrToDecimal(txtCost1.Text, 0);

            if (Forms.Products.AdminPriceCalculator.ShowCostItemForm(ref netAmount))
                txtCost1.Text = netAmount.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal netAmount = SharedUtils.StrToDecimal(txtCost2.Text, 0);

            if (Forms.Products.AdminPriceCalculator.ShowCostItemForm(ref netAmount))
                txtCost2.Text = netAmount.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal netAmount = SharedUtils.StrToDecimal(txtCost3.Text, 0);

            if (Forms.Products.AdminPriceCalculator.ShowCostItemForm(ref netAmount))
                txtCost3.Text = netAmount.ToString();
        }

        #endregion Private Methods
    }
}
