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
 *  File: AssignBarcodeForm.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Windows.Forms;

using Languages;
using Library.BOL.Products;
using POS.Base.Classes;

namespace POS.Till.Forms
{
    public partial class AssignBarcodeForm : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private Products _products;

        #endregion Private Members

        #region Constructors

        public AssignBarcodeForm()
        {
            InitializeComponent();
            LoadProductTypes();
            BuildProducts();

            AppController.ApplicationController.BarcodeReceived += User_BarcodeReceived;
        }

        #endregion Constructors

        #region Properties

        public Products Products
        {
            set
            {
                _products = value;
                BuildProducts();
            }

            get
            {
                return (_products);
            }
        }

        public ProductCost UpdatedProductCost
        {
            private set;
            get;
        }

        #endregion Properties

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.TillAssignBarcodes;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppBarcodeAssign;

            lblBarcode.Text = LanguageStrings.AppBarcode;
            lblFilter.Text = LanguageStrings.AppFilter;
            lblProductType.Text = LanguageStrings.AppProductType;

            btnSave.Text = LanguageStrings.AppMenuButtonSave;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void User_BarcodeReceived(object sender, AppController.BarcodeEventArgs e)
        {
            txtBarcode.Text = e.Barcode;
        }

        private void LoadProductTypes()
        {
            cmbProductType.Items.Clear();

            foreach (ProductCostType item in ProductCostTypes.Get())
            {
                cmbProductType.Items.Add(item);
            }

            cmbProductType.SelectedIndex = 0;
        }

        private void BuildProducts()
        {
            if (_products == null)
                return;

            lstProducts.BeginUpdate();
            try
            {
                ProductCostType type = (ProductCostType)Enum.Parse(
                    typeof(ProductCostType), (string)cmbProductType.Items[cmbProductType.SelectedIndex]);

                lstProducts.Items.Clear();

                foreach (Product product in _products)
                {
                    foreach (ProductCost cost in product.ProductCosts)
                    {
                        if (cost.ProductCostType == type)
                            if (product.Name.ToLower().Contains(txtFilter.Text.ToLower()) || 
                                    cost.Size.ToLower().Contains(txtFilter.Text.ToLower()))
                                lstProducts.Items.Add(cost);
                    }
                }
            }
            finally
            {
                lstProducts.EndUpdate();
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            BuildProducts();
        }

        private void cmbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildProducts();
        }

        private void lstProducts_Format(object sender, ListControlConvertEventArgs e)
        {
            ProductCost cost = (ProductCost)e.ListItem;

            e.Value = String.Format(StringConstants.PRODUCT_COST_SIZE_TYPE,
                cost.ProductCostType.Description, 
                cost.Product.Name, cost.Size);
        }

        private void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductCost cost = (ProductCost)lstProducts.Items[lstProducts.SelectedIndex];
            txtBarcode.Text = cost.Barcode;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lstProducts.SelectedIndex == -1)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppProductSelect);
            }
            else
            {
                ProductCost cost = (ProductCost)lstProducts.Items[lstProducts.SelectedIndex];
                cost.Barcode = txtBarcode.Text;
                cost.Save();
                UpdatedProductCost = cost;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        #endregion Private Methods
    }
}
