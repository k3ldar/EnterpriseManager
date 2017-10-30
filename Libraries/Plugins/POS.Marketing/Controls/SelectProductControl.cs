using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Library;
using Library.Utils;
using Library.BOL.Products;
using Library.BOL.Users;
using POS.Base.Classes;

namespace POS.Marketing.Controls
{
    public partial class SelectProductControl : SharedControls.BaseControl
    {
        public SelectProductControl()
        {
            InitializeComponent();

            if (AppController.ApplicationRunning)
                LoadProductTypes();
        }


        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblProductItem.Text = Languages.LanguageStrings.AppProductItem;
            lblProducts.Text = Languages.LanguageStrings.AppProducts;
            lblProductType.Text = Languages.LanguageStrings.AppProductType;
        }

        /// <summary>
        /// Returns the selected product item
        /// </summary>
        /// <returns></returns>
        public Int64 SelectedProductItemID()
        {
            Int64 Result = -1;

            if (cmbProductCost.SelectedIndex > -1)
            {
                ProductCost cost = (ProductCost)cmbProductCost.Items[cmbProductCost.SelectedIndex];
                Result = cost.ID;
            }

            return (Result);
        }

        public void SetProductTypeIndex(int index)
        {
            cmbProductType.SelectedIndex = index;
            LoadProducts();
        }

        public void SetProductIndex(int index)
        {
            cmbProducts.SelectedIndex = index;
            LoadProductCostItems();
        }

        public void SetProductCostIndex(int index)
        {
            cmbProductCost.SelectedIndex = index;
        }


        public int GetProductTypeIndex()
        {
            return (cmbProductType.SelectedIndex);
        }

        public int GetProductIndex()
        {
            return (cmbProducts.SelectedIndex);
        }

        public int GetProductCostIndex()
        {
            return (cmbProductCost.SelectedIndex);
        }



        private void LoadProductTypes()
        {
            cmbProductType.Items.Clear();

            foreach (ProductType item in ProductTypes.Get())
            {
                cmbProductType.Items.Add(item);
            }

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
                cmbProductType.SelectedIndex = 0;
        }

        private void cmbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Load products for product type
            LoadProducts();
        }

        private void LoadProducts()
        {
            cmbProducts.Items.Clear();
            cmbProductCost.Items.Clear();

            Products products = Products.Get((ProductType)cmbProductType.Items[cmbProductType.SelectedIndex], 1, 10000);

            foreach (Product product in products)
            {
                if (product.ShowOnWebsite)
                    cmbProducts.Items.Add(product);
            }

            if (cmbProducts.Items.Count > 0)
                cmbProducts.SelectedIndex = 0;
        }

        private void cmbProductType_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((ProductType)e.ListItem).Description;
        }

        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProductCostItems();
        }

        private void LoadProductCostItems()
        {
            cmbProductCost.Items.Clear();

            if (cmbProducts.SelectedIndex > -1)
            {
                Product product = (Product)cmbProducts.Items[cmbProducts.SelectedIndex];

                foreach (ProductCost item in product.ProductCosts)
                {
                    if (item.MemberLevel == (int)MemberLevel.StandardUser)
                        cmbProductCost.Items.Add(item);
                }
            }

            if (cmbProductCost.Items.Count > 0)
                cmbProductCost.SelectedIndex = 0;
        }

        private void cmbProducts_Format(object sender, ListControlConvertEventArgs e)
        {
            Product prod = (Product)e.ListItem;
            e.Value = prod.Name;
        }

        private void cmbProductCost_Format(object sender, ListControlConvertEventArgs e)
        {
            ProductCost cost = (ProductCost)e.ListItem;
            e.Value = String.Format(StringConstants.PREFIX_AND_SUFFIX_HYPHEN, cost.ProductCostType.Description, cost.Size);
        }
    }
}
