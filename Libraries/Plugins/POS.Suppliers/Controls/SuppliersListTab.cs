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
 *  File: SuppliersListTab.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Globalization;
using System.Windows.Forms;

using Languages;

using SharedBase;
using SharedBase.BOL.ContactDetails;
using SharedBase.BOL.Suppliers;

using POS.Base.Classes;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation

namespace POS.Suppliers
{
    public partial class SuppliersListTab : Base.Controls.BaseOptionsControl
    {
        #region Private Members

        private ToolStripButton _visitHomePage;
        private ToolStripButton _productAdd;
        private ToolStripButton _productDelete;
        private ToolStripButton _productEdit;

        #endregion Private Members

        #region Constructors

        public SuppliersListTab()
        {
            InitializeComponent();
            suppliersProductSplitter.SplitterDistance = 150;

            AllowAddNew = true;
            AllowRefresh = true;
            AllowDelete = false;
            AllowEdit = lvSuppliers.SelectedItems.Count > 0;
            UpdateUI(AllowEdit);
            OnRefreshClicked();

            AddCustomToolbarItems();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            colSupplierName.Text = LanguageStrings.Name;
            colSupplierStatus.Text = LanguageStrings.Status;
            colSupplierContact.Text = LanguageStrings.PrimaryContact;
            colSupplierTelephone.Text = LanguageStrings.Telephone;
            colSupplierWebsite.Text = LanguageStrings.Website;
            colSupplierAddressLine1.Text = LanguageStrings.AddressLine1;
            colSupplierPostcode.Text = LanguageStrings.Postcode;

            colProductsMake.Text = LanguageStrings.AppProductMake;
            colProductsModel.Text = LanguageStrings.AppProductModel;
            colProductsName.Text = LanguageStrings.Name;
            colProductsNotes.Text = LanguageStrings.Notes;
            colProductsCost.Text = LanguageStrings.AppCost;
            colProductsSKU.Text = LanguageStrings.AppSKU;
            colProductsType.Text = LanguageStrings.AppProductType;

            contextMenuSuppliersEdit.Text = LanguageStrings.AppMenuEdit;
            contextMenuSuppliersWebsite.Text = LanguageStrings.AppMenuVisitWebsite;

            _productAdd.ToolTipText = LanguageStrings.AppHintProductAdd;
            _productEdit.ToolTipText = LanguageStrings.AppHintProductEdit;
            _productDelete.ToolTipText = LanguageStrings.AppHintProductDelete;
            _visitHomePage.ToolTipText = LanguageStrings.AppMenuVisitWebsite;

            foreach (ListViewItem item in lvProducts.Items)
            {
                SupplierProduct product = (SupplierProduct)item.Tag;

                item.SubItems[3].Text = SharedBase.Utils.SharedUtils.FormatMoney(product.NetCost, AppController.LocalCurrency, true);
                item.SubItems[5].Text = Base.EnumTranslations.Translate(product.AssetType);
            }
        }

        protected override void OnRefreshClicked()
        {
            this.Cursor = Cursors.WaitCursor;
            lvSuppliers.BeginUpdate();
            try
            {
                lvSuppliers.Items.Clear();

                foreach (Supplier sup in SharedBase.BOL.Suppliers.Suppliers.All())
                {
                    ListViewItem item = new ListViewItem(sup.BusinessName);
                    item.SubItems.Add(Base.EnumTranslations.Translate(sup.Status));

                    Contact contact = sup.Contacts[0];

                    item.SubItems.Add(contact.ContactName);
                    item.SubItems.Add(contact.ContactValue);

                    item.SubItems.Add(sup.Website);
                    item.SubItems.Add(sup.Addressline1);
                    item.SubItems.Add(sup.Postcode);
                    item.Tag = sup;
                    lvSuppliers.Items.Add(item);

                    LoadSupplierProducts(null);
                }
            }
            finally
            {
                lvSuppliers.EndUpdate();
                this.Cursor = Cursors.Arrow;
            }
        }

        protected override void OnCreateClicked()
        {
            if (!AppController.ActiveUser.HasPermissionAccounts(SecurityEnums.SecurityPermissionsAccounts.AddUpdateSuppliers))
            {
                ShowError(LanguageStrings.Error, LanguageStrings.AppSuppliersInvalidPermissionAddEdit);
                return;
            }

            Supplier newSupplier = null;

            if (Classes.SuppliersWizards.CreateNewSupplier(ref newSupplier))
            {
                ListViewItem item = new ListViewItem(newSupplier.BusinessName);
                item.SubItems.Add(Base.EnumTranslations.Translate(newSupplier.Status));

                Contact contact = newSupplier.Contacts[0];
                item.SubItems.Add(contact.ContactName);
                item.SubItems.Add(contact.ContactValue);

                item.SubItems.Add(newSupplier.Website);
                item.SubItems.Add(newSupplier.Addressline1);
                item.SubItems.Add(newSupplier.Postcode);
                item.Tag = newSupplier;
                lvSuppliers.Items.Add(item);
            }
        }

        protected override void OnEditClicked()
        {
            if (!AppController.ActiveUser.HasPermissionAccounts(SecurityEnums.SecurityPermissionsAccounts.AddUpdateSuppliers))
            {
                ShowError(LanguageStrings.Error, LanguageStrings.AppSuppliersInvalidPermissionAddEdit);
                return;
            }

            if (lvSuppliers.SelectedItems.Count > 0)
            {
                Supplier supplier = (Supplier)lvSuppliers.SelectedItems[0].Tag;

                if (Classes.SuppliersWizards.EditSupplier(ref supplier))
                {
                    lvSuppliers.SelectedItems[0].Text = supplier.BusinessName;
                    lvSuppliers.SelectedItems[0].SubItems[1].Text = Base.EnumTranslations.Translate(supplier.Status);

                    Contact contact = supplier.Contacts[0];
                    lvSuppliers.SelectedItems[0].SubItems[2].Text = contact.ContactName;
                    lvSuppliers.SelectedItems[0].SubItems[3].Text = contact.ContactValue;

                    lvSuppliers.SelectedItems[0].SubItems[4].Text = supplier.Website;
                    lvSuppliers.SelectedItems[0].SubItems[5].Text = supplier.Addressline1;
                    lvSuppliers.SelectedItems[0].SubItems[6].Text = supplier.Postcode;
                }
            }
        }

        #endregion Overridden Methods

        #region Private Methods

        #region Toolbar Buttons

        private void AddCustomToolbarItems()
        {
            AddToolbarSeperator();

            // visit website button
            _visitHomePage = new ToolStripButton();
            _visitHomePage.Image = Base.Icons.HomeIcon();
            _visitHomePage.Click += contextMenuSuppliersWebsite_Click;
            _visitHomePage.Enabled = false;
            AddToobarButton(_visitHomePage);

            AddToolbarSeperator();

            _productAdd = new ToolStripButton();
            _productAdd.Image = Base.Icons.ProductAddIcon();
            _productAdd.Click += productAdd_Click;
            _productAdd.Enabled = false;
            AddToobarButton(_productAdd);

            _productEdit = new ToolStripButton();
            _productEdit.Image = Base.Icons.ProductEditIcon();
            _productEdit.Click += productEdit_Click;
            _productEdit.Enabled = false;
            AddToobarButton(_productEdit);

            _productDelete = new ToolStripButton();
            _productDelete.Image = Base.Icons.ProductDeleteIcon();
            _productDelete.Click += productDelete_Click;
            _productDelete.Enabled = false;
            AddToobarButton(_productDelete);
        }

        private void productEdit_Click(object sender, EventArgs e)
        {
            if (lvProducts.SelectedItems.Count < 1)
                return;

            ListViewItem item = lvProducts.SelectedItems[0];
            SupplierProduct product = (SupplierProduct)item.Tag;

            if (POS.Suppliers.Classes.SuppliersWizards.EditProduct(product.Supplier, ref product))
            {
                item.SubItems[0].Text = product.Name;
                item.SubItems[1].Text = product.Make;
                item.SubItems[2].Text = product.Model;
                item.SubItems[3].Text = SharedBase.Utils.SharedUtils.FormatMoney(product.NetCost, AppController.LocalCurrency, true);
                item.SubItems[4].Text = product.SKU;
                item.SubItems[5].Text = Base.EnumTranslations.Translate(product.AssetType);
                item.SubItems[6].Text = product.Notes.Replace(StringConstants.SYMBOL_CRLF, StringConstants.SYMBOL_SPACE);
            }
        }

        private void productDelete_Click(object sender, EventArgs e)
        {
            if (lvProducts.SelectedItems.Count < 1)
                return;

            ListViewItem item = lvProducts.SelectedItems[0];
            SupplierProduct product = (SupplierProduct)item.Tag;


            if (ShowQuestion(LanguageStrings.ConfirmDelete, 
                String.Format(LanguageStrings.AppSupplierDeleteProduct, product.Name)))
            {
                product.Delete();
                lvProducts.Items.Remove(item);
            }
        }

        private void productAdd_Click(object sender, EventArgs e)
        {
            if (!AppController.ActiveUser.HasPermissionAccounts(
                SharedBase.SecurityEnums.SecurityPermissionsAccounts.AddUpdateSuppliers))
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppErrorManageSuppliers);
                return;
            }

            if (lvSuppliers.SelectedItems.Count < 1)
                return;

            SupplierProduct product = null;

            if (Classes.SuppliersWizards.CreateProduct(
                (Supplier)lvSuppliers.SelectedItems[0].Tag,
                ref product))
            {
                ListViewItem item = new ListViewItem(product.Name);
                item.SubItems.Add(product.Make);
                item.SubItems.Add(product.Model);
                item.SubItems.Add(SharedBase.Utils.SharedUtils.FormatMoney(product.NetCost, AppController.LocalCurrency, true));
                item.SubItems.Add(product.SKU);
                item.SubItems.Add(Base.EnumTranslations.Translate(product.AssetType));
                item.SubItems.Add(product.Notes.Replace(StringConstants.SYMBOL_CRLF, StringConstants.SYMBOL_SPACE));
                item.Tag = product;
                lvProducts.Items.Add(item);
            }
        }


        #endregion Toolbar Buttons

        private void lvSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllowEdit = lvSuppliers.SelectedItems.Count > 0;
            UpdateUI(AllowEdit);

            if (AllowEdit)
            {
                Supplier supplier = (Supplier)lvSuppliers.SelectedItems[0].Tag;

                contextMenuSuppliersWebsite.Enabled = !String.IsNullOrEmpty(supplier.Website) &&
                    (supplier.Website.StartsWith(StringConstants.BASE_WEB_HTTP) ||
                    supplier.Website.StartsWith(StringConstants.BASE_WEB_HTTPS));
                _visitHomePage.Enabled = contextMenuSuppliersWebsite.Enabled;
                _productAdd.Enabled = AppController.ActiveUser.HasPermissionAccounts(
                    SharedBase.SecurityEnums.SecurityPermissionsAccounts.AddUpdateSuppliers);

                LoadSupplierProducts(supplier);
            }
            else
            {
                _visitHomePage.Enabled = false;
                _productAdd.Enabled = false;
                _productDelete.Enabled = false;
                LoadSupplierProducts(null);
            }
        }

        private void lvSuppliers_DoubleClick(object sender, EventArgs e)
        {
            OnEditClicked();
        }

        private void LoadSupplierProducts(Supplier supplier)
        {
            this.Cursor = Cursors.WaitCursor;
            lvProducts.BeginUpdate();
            try
            {
                lvProducts.Items.Clear();
                lvProducts.Enabled = supplier != null;

                if (supplier == null)
                    return;

                foreach (SupplierProduct product in SupplierProducts.All((Supplier)lvSuppliers.SelectedItems[0].Tag))
                {
                    ListViewItem item = new ListViewItem(product.Name);
                    item.SubItems.Add(product.Make);
                    item.SubItems.Add(product.Model);
                    item.SubItems.Add(SharedBase.Utils.SharedUtils.FormatMoney(product.NetCost, AppController.LocalCurrency, true));
                    item.SubItems.Add(product.SKU);
                    item.SubItems.Add(Base.EnumTranslations.Translate(product.AssetType));
                    item.SubItems.Add(product.Notes.Replace(StringConstants.SYMBOL_CRLF, StringConstants.SYMBOL_SPACE));
                    item.Tag = product;
                    lvProducts.Items.Add(item);
                }
            }
            finally
            {
                if (_productAdd != null)
                {
                    _productDelete.Enabled = false;
                    _productEdit.Enabled = false;
                }

                lvProducts.EndUpdate();
                this.Cursor = Cursors.Arrow;
            }
        }

        #region Supplier Popup Menu

        private void contextMenuSuppliers_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void contextMenuSuppliersEdit_Click(object sender, EventArgs e)
        {
            OnEditClicked();
        }

        private void contextMenuSuppliersWebsite_Click(object sender, EventArgs e)
        {
            if (lvSuppliers.SelectedItems.Count > 0)
            {
                Supplier supplier = (Supplier)lvSuppliers.SelectedItems[0].Tag;
                RunProgram(supplier.Website);
            }
        }

        #endregion Supplier Popup Menu

        private void lvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            _productEdit.Enabled = lvProducts.SelectedItems.Count > 0;
            _productDelete.Enabled = lvProducts.SelectedItems.Count > 0;
        }

        private void lvProducts_DoubleClick(object sender, EventArgs e)
        {
            productEdit_Click(sender, e);
        }

        #endregion Private Methods
    }
}
