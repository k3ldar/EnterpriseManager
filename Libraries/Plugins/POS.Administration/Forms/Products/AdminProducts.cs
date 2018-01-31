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
 *  File: AdminProducts.cs
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

using Library;
using Library.BOL.Users;
using Library.BOL.Products;

#pragma warning disable IDE1006

namespace POS.Administration.Forms.Products
{
    public partial class AdminProducts : POS.Base.Controls.BaseTabControl
    {
        #region Private / Protected Members

        private User _User;
        private WebsiteAdministration _Admin;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public AdminProducts(User user, WebsiteAdministration Admin)
        {
            _User = user;
            _Admin = Admin;

            InitializeComponent();

            if (!Base.Classes.AppController.ApplicationRunning)
                return;

            toolStripMainAdd.Image = POS.Base.Icons.AddIcon();
            toolStripMainDelete.Image = POS.Base.Icons.DeleteIcon();
            toolStripMainEdit.Image = POS.Base.Icons.EditIcon();
            toolStripMainRefresh.Image = POS.Base.Icons.RefreshIcon();

            toolStripMainEdit.Enabled = false;
            RebuildContextMenu(toolStripMain, contextMenuList);

            LoadPrimaryGroupTypes(toolStripMainPrimaryProductType, true, true);
            LoadProductTypes();
            LoadProducts();
            toolStripMainPrimaryProductType.SelectedIndexChanged += cmbPrimaryProduct_SelectedIndexChanged;
            toolStripMainProductGroups.SelectedIndexChanged += cmbPrimaryProduct_SelectedIndexChanged;

            //toolStripMainPrimaryProductType.
        }

        #endregion Constructors / Destructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            toolStripMainPrimaryProductType.ToolTipText = LanguageStrings.AppPrimaryProduct;
            toolStripMainProductName.ToolTipText = LanguageStrings.AppHintProductSearch;
            toolStripMainProductGroups.ToolTipText = LanguageStrings.AppProductGroup;

            colHeaderName.Text = LanguageStrings.AppName;
            colHeaderPrimaryGroup.Text = LanguageStrings.AppPrimaryGroup;
            colHeaderRegal.Text = LanguageStrings.AppRegal;
            colHeaderShowOnWeb.Text = LanguageStrings.AppShowOnWebsite;
            colHeaderSKU.Text = LanguageStrings.AppSKU;

            toolStripMainAdd.Text = LanguageStrings.AppHintNew;
            toolStripMainDelete.Text = LanguageStrings.AppHintDelete;
            toolStripMainRefresh.Text = LanguageStrings.AppHintRefresh;
            toolStripMainEdit.Text = LanguageStrings.AppHintEdit;
        }

        protected override void SetPermissions()
        {
            toolStripMainAdd.Enabled = _User.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AllowCreateNew);
            toolStripMainDelete.Enabled = false;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadProductTypes()
        {
            toolStripMainProductGroups.Items.Clear();
            ProductGroups prodGroups = _Admin.ProductGroupsGet(1, 1000);
            toolStripMainProductGroups.Tag = prodGroups;

            ProductGroup prodAll = new ProductGroup(-1, LanguageStrings.AppProductAllProductGroups,
                100, String.Empty, false, MemberLevel.StandardUser,
                String.Empty, new ProductGroupType(-1, LanguageStrings.ViewAll), String.Empty,
                String.Empty, String.Empty, false);
            prodGroups.Insert(0, prodAll);

            toolStripMainProductGroups.Items.Add(prodAll.Description);

            foreach (ProductGroup group in prodGroups)
            {
                //if ((PrimaryProductType)cmbPrimaryProduct.SelectedIndex == group.ProductType)
                toolStripMainProductGroups.Items.Add(group.Description);
            }

            toolStripMainProductGroups.SelectedIndex = 0;
        }

        private void LoadProducts()
        {
            this.Cursor = Cursors.WaitCursor;
            lstProducts.BeginUpdate();
            try
            {
                int count = 0;
                bool setRightToLeft = false;

                lstProducts.Items.Clear();
                Library.BOL.Products.Products products;

                ProductGroup group = null;

                foreach (ProductGroup grp in (ProductGroups)toolStripMainProductGroups.Tag)
                {
                    if (grp.Description == (string)toolStripMainProductGroups.SelectedItem)
                    {
                        group = grp;
                        break;
                    }
                }

                if (group == null || (group.ID < 0 && toolStripMainProductName.Text == String.Empty))
                    products = _Admin.ProductsGet();
                else
                    products = _Admin.ProductsGet(group, toolStripMainProductName.Text);


                ProductType prodType = null;

                foreach (ProductType pType in (ProductTypes)toolStripMainPrimaryProductType.Tag)
                {
                    if (pType.Description == (string)toolStripMainPrimaryProductType.SelectedItem)
                    {
                        prodType = pType;
                        break;
                    }
                }

                foreach (Product prod in products)
                {
                    if (!setRightToLeft && Shared.Utilities.IsRightToLeftCharacter(prod.Name))
                        setRightToLeft = true;

                    if (prodType.ID == -1 || prod.PrimaryProduct.ID == prodType.ID)
                    {
                        ListViewItem item = lstProducts.Items.Add(prod.Name);
                        item.SubItems.Add(prod.PrimaryProduct.Description);
                        item.SubItems.Add(prod.SKU);
                        item.SubItems.Add(prod.Regal ? LanguageStrings.AppYes : LanguageStrings.AppNo);
                        item.SubItems.Add(prod.ShowOnWebsite ? LanguageStrings.AppYes : LanguageStrings.AppNo);
                        item.SubItems.Add(prod.ID.ToString());
                        count++;
                    }
                }

                string StatusText = LanguageStrings.AppProductsFound;

                if (count == 1)
                    StatusText = LanguageStrings.AppProductFound;

                toolStripStatusLabelCount.Text = String.Format(StatusText, count);

                lstProducts.RightToLeft = setRightToLeft ? RightToLeft.Yes : RightToLeft.No;
            }
            finally
            {
                lstProducts.EndUpdate();
                this.Cursor = Cursors.Default;
            }
        }

        private void lstProducts_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in lstProducts.SelectedItems)
            {
                Library.BOL.Products.Product product = _Admin.ProductGet(Convert.ToInt32(itm.SubItems[5].Text));

                if (product != null)
                {
                    AdminProductEdit productEdit = new AdminProductEdit(_User, _Admin, product);
                    try
                    {
                        if (productEdit.ShowDialog(this) == System.Windows.Forms.DialogResult.Abort)
                        {
                            LoadProducts();
                            break;
                        }
                    }
                    finally
                    {
                        productEdit.Dispose();
                        productEdit = null;
                    }
                }
            }
        }

        private void cmbProductType_Format(object sender, ListControlConvertEventArgs e)
        {
            ProductGroup grp = (ProductGroup)e.ListItem;
            e.Value = grp.Description;
        }

        private void cmbPrimaryProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstProducts.Focus();

            LoadProducts();
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void toolStripMainAdd_Click(object sender, EventArgs e)
        {
            NewProductForm frm = new NewProductForm();
            try
            {
                if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    AdminProductEdit productEdit = new AdminProductEdit(_User, _Admin, frm.NewProduct);
                    try
                    {
                        if (productEdit.ShowDialog(this) == System.Windows.Forms.DialogResult.Abort)
                        {
                            LoadProducts();
                        }
                    }
                    finally
                    {
                        productEdit.Dispose();
                        productEdit = null;
                    }
                }
            }
            finally
            {
                frm.Dispose();
                frm = null;
            }
        }

        private void toolStripMainDelete_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMainEdit_Click(object sender, EventArgs e)
        {
            lstProducts_DoubleClick(sender, e);
        }

        private void toolStripMainRefresh_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripMainEdit.Enabled = lstProducts.SelectedItems.Count > 0;
        }

        #endregion Private Methods
    }
}
