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
 *  File: AdminProductEdit.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.IO;
using System.Windows.Forms;
using System.Reflection;

using Languages;

using SharedBase.BOL.Products;
using SharedBase.BOL.Users;
using SharedBase.BOL.ValidationChecks;

using SharedBase;
using SharedBase.Utils;
using POS.Base.Classes;
using POS.Base.Plugins;

using POS.Administration.Controls;

#pragma warning disable IDE1006

namespace POS.Administration.Forms.Products
{
    public partial class AdminProductEdit : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private User _User;
        private WebsiteAdministration _Admin;
        private Product _product;

        private bool _spellCheckComplete = false;

        #endregion Private Members

        #region Constructors

        public AdminProductEdit()
        {
            InitializeComponent();

            if (!PluginManager.WebsitesEnabled())
            {
                tabControlMain.TabPages.Remove(tabPageSettings);
            }
        }

        public AdminProductEdit(User user, WebsiteAdministration admin, Product product)
            : this()
        {
            _User = user;
            _Admin = admin;
            _product = product;

            LoadPrimaryGroupTypes(cmbPrimaryType, false);
            LoadProductGroups();
            LoadImages();
            LoadProduct();

            AppController.ApplicationController.TableIDChanged += User_TableIDChanged;

            if (!PluginManager.PluginLoaded(LanguageStrings.AppPluginWebsiteAdministration))
            {
                tabProductDetails.TabPages.Remove(tabPageDetailFeatures);
                tabProductDetails.TabPages.Remove(tabPageDetailHowToUse);
                tabProductDetails.TabPages.Remove(tabPageDetailIngredients);
            }

            NotificationEventArgs args = new NotificationEventArgs(StringConstants.PLUGIN_EVENT_WEBSITE_NAME);
            PluginManager.RaiseEvent(args);

            if (String.IsNullOrEmpty((string)args.Result))
            {
                tabControlMain.TabPages.Remove(tabPageProductSEO);
            }
            else
            {
                try
                {
                    string url = (string)args.Result;

                    if (!url.StartsWith(StringConstants.BASE_WEB_HTTP) && !url.StartsWith(StringConstants.BASE_WEB_HTTPS))
                        url = StringConstants.BASE_WEB_HTTP + url;

                    Uri uri = new Uri(url + _product.URL);
                    seoSettings1.Url = uri;
                }
                catch
                {
                    tabControlMain.TabPages.Remove(tabPageProductSEO);
                }
            }
        }

        #endregion Constructors

        #region Overridden Methods

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            tabControlMain_SelectedIndexChanged(this, e);
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppProductAdministration;

            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnDelete.Text = LanguageStrings.AppMenuButtonDelete;
            btnNew.Text = LanguageStrings.AppMenuButtonNew;
            btnRemove.Text = LanguageStrings.AppMenuButtonRemove;
            btnRemoveAll.Text = LanguageStrings.AppMenuButtonRemoveAll;
            btnSave.Text = LanguageStrings.AppMenuButtonSave;
            btnSpellCheck.Text = LanguageStrings.AppMenuButtonSpellCheck;

            tabPageDetails.Text = LanguageStrings.AppDetails;
            tabPageDetailDescription.Text = LanguageStrings.Description;
            tabPageDetailFeatures.Text = LanguageStrings.Features;
            tabPageDetailHowToUse.Text = LanguageStrings.HowToUse;
            tabPageDetailIngredients.Text = LanguageStrings.Contents;
            tabPageProductItems.Text = LanguageStrings.AppProductItems;
            tabPageProductGroups.Text = LanguageStrings.AppProductGroups;
            tabPageSettings.Text = LanguageStrings.AppSettings;
            tabPageProductSEO.Text = LanguageStrings.SEO;

            cbAllowPreOrder.Text = LanguageStrings.AppProductAllowPreOrder;
            cbBestSeller.Text = LanguageStrings.BestSeller;
            cbCarousel.Text = LanguageStrings.AppProductCarousel;
            cbFeatured.Text = LanguageStrings.FeaturedProduct;
            cbNewProduct.Text = LanguageStrings.NewProduct;
            cbOutOfStock.Text = LanguageStrings.OutOfStock;
            cbRegal.Text = LanguageStrings.AppRegal;
            cbShowOnWeb.Text = LanguageStrings.AppShowOnWebsite;
            cbSpecialOffer.Text = LanguageStrings.AppProductSpecialOffer;

            lblAssignedProductGroups.Text = LanguageStrings.AppProductAssignedProductGroups;
            lblImage.Text = LanguageStrings.Picture;
            lblPopupID.Text = LanguageStrings.AppProductPopUpID;
            lblPrimaryGroup.Text = LanguageStrings.AppPrimaryGroup;
            lblPrimaryProduct.Text = LanguageStrings.AppPrimaryProduct;
            lblProductCode.Text = LanguageStrings.AppProductCode;
            lblProductName.Text = LanguageStrings.AppProductName;
            lblSortOrder.Text = LanguageStrings.AppSortOrder;
            lblVideoLink.Text = LanguageStrings.AppProductVideoLink;
        }

        protected override void SetPermissions()
        {
            btnNew.Enabled = _User.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AllowCreateNew);
            btnSave.Enabled = _User.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AllowSave);
            btnDelete.Enabled = _User.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AllowDelete);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadImages()
        {
            cmbImage.Items.Clear();

            string imageRoot = AppController.POSFolder(ImageTypes.Products);

            string[] files = Directory.GetFiles(imageRoot, StringConstants.IMAGE_SEARCH_PRODUCTS);

            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                int idx = cmbImage.Items.Add(fileName);

                if (file.EndsWith(_product.Image, StringComparison.InvariantCultureIgnoreCase))
                {
                    cmbImage.SelectedIndex = idx;
                }
            }
        }

        private void LoadProductGroups()
        {
            lstProductGroups.Items.Clear();
            cmbGroup.Items.Clear();

            ProductGroups groups = _Admin.ProductGroupsGet(1, 1000);

            foreach (ProductGroup group in groups)
            {
                //if (group.ProductType == (PrimaryProductType)cmbPrimaryType.SelectedIndex)
                //{
                    lstProductGroups.Items.Add(group);

                    int idx = cmbGroup.Items.Add(group);

                    if (_product.PrimaryGroup != null && group.ID == _product.PrimaryGroup.ID)
                    {
                        cmbGroup.SelectedIndex = idx;
                    }
                //}
            }
        }

        private void LoadProduct()
        {
            for (int i = 0; i < cmbPrimaryType.Items.Count; i++)
            {
                ProductType ptype = (ProductType)cmbPrimaryType.Items[i];

                if (ptype.ID == _product.PrimaryProduct.ID)
                {
                    cmbPrimaryType.SelectedIndex = i;
                    break;
                }
            }

            LoadProductGroups();
            LoadImages();

            txtProductName.Text = _product.Name;
            txtProductCode.Text = _product.SKU;

            productEditTextDescription.PageType = CustomPagesType.ProductDescription;
            productEditTextDescription.Text = _product.Description;
            productEditTextDescription.MaximumLength = 4000;
            productEditTextDescription.Product = _product;

            productEditTextHowToUse.PageType = CustomPagesType.ProductHowToUse;
            productEditTextHowToUse.Text = _product.HowToUse;
            productEditTextHowToUse.MaximumLength = 2000;
            productEditTextHowToUse.Product = _product;

            productEditTextFeatures.PageType = CustomPagesType.ProductFeatures;
            productEditTextFeatures.Text = _product.Features;
            productEditTextFeatures.MaximumLength = 2000;
            productEditTextFeatures.Product = _product;

            productEditTextIngredients.PageType = CustomPagesType.ProductIngredients;
            productEditTextIngredients.Text = _product.Ingredients;
            productEditTextIngredients.MaximumLength = 2000;
            productEditTextIngredients.Product = _product;

            cbOutOfStock.Checked = _product.OutOfStock;
            cbRegal.Checked = _product.Regal;
            cbShowOnWeb.Checked = _product.ShowOnWebsite;
            cbSpecialOffer.Checked = _product.SpecialOffer;
            cbBestSeller.Checked = _product.BestSeller;
            cbCarousel.Checked = _product.Carousel;
            cbFeatured.Checked = _product.Featured;
            cbNewProduct.Checked = _product.NewProduct;
            spnPopupID.Value = _product.PopUpID;
            spnSortOrder.Value = _product.SortOrder;
            cmbImage.SelectedIndex = cmbImage.Items.IndexOf(_product.Image);
            LoadProductItems();
            txtVideoLink.Text = _product.VideoLink;
            cbAllowPreOrder.Checked = _product.PreOrder;

            if (cmbImage.SelectedIndex == -1)
                cmbImage.SelectedIndex = cmbImage.Items.IndexOf(_product.Image + StringConstants.IMAGE_SIZE_DEFAULT_PRODUCT_IMAGE);

            foreach (ProductGroup group in _product.ProductGroups)
            {
                foreach (object obj in lstProductGroups.Items)
                {
                    ProductGroup grp = (ProductGroup)obj;

                    if (grp.ID == group.ID)
                    {
                        lstProductGroups.SetItemChecked(lstProductGroups.Items.IndexOf(obj), true);
                        break;
                    }
                }
            }

            //txtDescription.InnerHtml.
        }

        private void LoadProductItems()
        {
            pnlProductItems.Controls.Clear();
            _product.UpdateProductCosts(_User);

            foreach (ProductCost prodCost in _product.ProductCosts)
            {
                AdminProductItem api = new AdminProductItem(prodCost, _User);
                api.OnDelete += api_OnDelete;
                api.OnEdit += api_OnEdit;
                pnlProductItems.Controls.Add(api);
            }
        }

        private void api_OnEdit(object sender, EventArgs e)
        {
            ProductCost prodCost = null;

            if (sender is AdminProductItem)
                prodCost = ((AdminProductItem)sender).ProductCostItem;

            if (prodCost != null)
            {
                EditProductCostItem(prodCost, true);
                ((AdminProductItem)sender).Refresh(prodCost);
            }
        }

        private void EditProductCostItem(ProductCost prodCost, bool allowCancel)
        {
            EditProductItem frmEditItem = new EditProductItem(prodCost, allowCancel);
            try
            {
                frmEditItem.ShowDialog();
            }
            finally
            {
                frmEditItem.Dispose();
                frmEditItem = null;
            }
        }

        void api_OnDelete(object sender, EventArgs e)
        {
            pnlProductItems.Controls.Remove(sender as AdminProductItem);
        }

        private void cmbProductGroup_Format(object sender, ListControlConvertEventArgs e)
        {
            ProductGroup group = (ProductGroup)e.ListItem;

            e.Value = group.Description;
        }

        private void pnlProductItems_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control ctl in pnlProductItems.Controls)
            {
                if (pnlProductItems.VerticalScroll.Visible)
                    ctl.Width = pnlProductItems.Width - 20;
                else
                    ctl.Width = pnlProductItems.Width;
            }
        }

        private void cmbImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string imageRoot = AppController.POSFolder(ImageTypes.Products) + cmbImage.SelectedItem;

            imgPicture.ImageLocation = imageRoot;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (ShowHardConfirm(LanguageStrings.AppProductDelete, LanguageStrings.AppProductDeletePrompt))
                {
                    try
                    {
                        _product.Delete(_User);
                        DialogResult = System.Windows.Forms.DialogResult.Abort;
                    }
                    catch (Exception error)
                    {
                        if (error.Message.Contains(StringConstants.ERROR_PRODUCT_IN_USE))
                        {
                            if (ShowHardConfirm(LanguageStrings.AppError,
                                LanguageStrings.AppProductItemDeleteFailedInUse))
                            {
                                try
                                {
                                    _product.SoftDelete();
                                    PluginManager.RaiseEvent(StringConstants.PLUGIN_EVENT_PRODUCT_ADD_REMOVE_UPDATE);
                                    DialogResult = DialogResult.Abort;
                                }
                                catch (Exception err)
                                {
                                    if (err.Message.Contains(StringConstants.ERROR_PRODUCT_HAS_STOCK))
                                    {
                                        ShowError(LanguageStrings.AppError, LanguageStrings.AppProductItemDeleteHasStock);
                                    }
                                    else if (err.Message.Contains(StringConstants.ERROR_PRODUCT_IN_USE))
                                    {
                                        ShowError(LanguageStrings.AppError, LanguageStrings.AppProductItemDeleteFailedInUse);
                                    }
                                    else
                                        throw;

                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (!_spellCheckComplete && (_product.Description != productEditTextDescription.Text ||
                    _product.HowToUse != productEditTextHowToUse.Text || _product.Features != productEditTextFeatures.Text ||
                    _product.Ingredients != productEditTextIngredients.Text || _product.Name != txtProductName.Text))
                {
                    if (ShowQuestion(LanguageStrings.AppSpellCheck, LanguageStrings.AppSpellCheckPrompt))
                    {
                        btnSpellCheck_Click(sender, e);
                        return;
                    }
                    else
                        POSValidation.Add(AppController.ActiveUser, ValidationReasons.IgnoreSpellCheckProduct,
                            String.Format(StringConstants.VALIDATION_CHECK_PRODUCT, _product.ID, 
                            Shared.Utilities.MaximumLength(_product.Name, 150)));
                }

                if (cmbGroup.SelectedIndex == -1)
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppProductSaveNoPrimaryGroup);
                    tabControlMain.SelectedTab = tabPageDetails;
                    cmbGroup.DroppedDown = true;
                    return;
                }

                _product.PopUpID = (int)spnPopupID.Value;
                _product.SortOrder = (int)spnSortOrder.Value;
                _product.Name = LibUtils.ReplaceHTMLElements(txtProductName.Text);
                _product.SKU = LibUtils.ReplaceHTMLElements(txtProductCode.Text);
                _product.Description = productEditTextDescription.Text;
                _product.Features = productEditTextFeatures.Text;
                _product.Ingredients = productEditTextIngredients.Text;
                _product.HowToUse = productEditTextHowToUse.Text;
                _product.SpecialOffer = cbSpecialOffer.Checked;
                _product.Regal = cbRegal.Checked;
                _product.ShowOnWebsite = cbShowOnWeb.Checked;

                if (cmbImage.SelectedItem == null)
                {
                    if (ShowQuestion(LanguageStrings.AppProductSave, LanguageStrings.AppProductSavePrompt))
                    {
                        tabControlMain.SelectedTab = tabPageDetails;
                        cmbImage.DroppedDown = true;
                        return;
                    }
                }
                else
                    _product.Image = cmbImage.SelectedItem.ToString();

                _product.OutOfStock = cbOutOfStock.Checked;
                _product.BestSeller = cbBestSeller.Checked;
                _product.NewProduct = cbNewProduct.Checked;
                _product.Featured = cbFeatured.Checked;
                _product.Carousel = cbCarousel.Checked;
                _product.PrimaryProduct = (ProductType)cmbPrimaryType.Items[cmbPrimaryType.SelectedIndex];
                _product.VideoLink = txtVideoLink.Text;
                _product.PreOrder = cbAllowPreOrder.Checked;

                ProductGroups newGroups = new ProductGroups();

                foreach (object obj in lstProductGroups.CheckedItems)
                {
                    ProductGroup group = (ProductGroup)obj;
                    newGroups.Add(group);
                }

                _product.ProductGroups = newGroups;

                foreach (Control ctl in pnlProductItems.Controls)
                {
                    AdminProductItem api = (AdminProductItem)ctl;

                    if (!api.Save())
                    {
                        //failed to save so quit
                        return;
                    }
                }

                _product.Save(_User);
                seoSettings1.Save();
                PluginManager.RaiseEvent(StringConstants.PLUGIN_EVENT_PRODUCT_ADD_REMOVE_UPDATE);
            }
            catch (Exception err)
            {
                if (err.Message.Contains(StringConstants.ERROR_INVALID_PERMISSION_UPDATE))
                {
                    ShowError(LanguageStrings.AppError, err.Message);
                }
                else if (err.Message.Contains(StringConstants.ERROR_LOCK_CONFLICT))
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppErrorLockConflictDesc);
                }
                else if (err.Message.Contains(StringConstants.ERROR_VIOLATION_PRODUCT_PRODUCT_NAME))
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppProductNameExists);
                }
                else
                {
                    SharedBase.ErrorHandling.LogError(MethodBase.GetCurrentMethod(), err, sender, e);
                    ShowError(LanguageStrings.AppError, err.Message);
                }

                return;
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            string name = String.Empty;
            ProductCostType type = null;

            if (AdminProductCostItemAdd.CreateNewProductType(this, _product, ref name, ref type))
            {
                ProductCost prodCost = _product.NewProductCostInfo(_User, name, type);
                EditProductCostItem(prodCost, false);
                LoadProductItems();
            }
        }

        private void lstProductGroups_Format(object sender, ListControlConvertEventArgs e)
        {
            ProductGroup group = (ProductGroup)e.ListItem;
            e.Value = group.Description;
        }

        private void cmbGroup_Format(object sender, ListControlConvertEventArgs e)
        {
            ProductGroup group = (ProductGroup)e.ListItem;
            e.Value = group.Description;
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            _product.PrimaryGroup = (ProductGroup)cmbGroup.SelectedItem;
        }

        private void imgPicture_Click(object sender, EventArgs e)
        {

        }

        private void cmbPrimaryType_DropDownClosed(object sender, EventArgs e)
        {
            LoadProductGroups();
            LoadImages();
        }

        private void User_TableIDChanged(object sender, AppController.TableIDChangedEventArgs e)
        {
            //is the id of the item we are looking at changing?
            switch (e.Table)
            {
                case StringConstants.TABLE_PRODUCTS:

                    if (e.OldID == _product.ID)
                    {
                        _product.ID = e.NewID;
                    }

                    break;
            }
        }

        private void btnSpellCheck_Click(object sender, EventArgs e)
        {
            SharedControls.SpellChecker.SpellChecker.ShowSpellChecker(this, 
                AppController.LocalSettings.CustomDictionary, 
                AppController.POSFolder(FolderType.Dictionary, true), 
                txtProductName, productEditTextDescription.TextBox, productEditTextFeatures.TextBox, 
                    productEditTextHowToUse.TextBox, productEditTextIngredients.TextBox);
            _spellCheckComplete = true;
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            foreach (int i in lstProductGroups.CheckedIndices)
            {
                lstProductGroups.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (ShowHardConfirm(LanguageStrings.AppProductRemove, LanguageStrings.AppProductRemovePrompt))
                {
                    try
                    {
                        _product.SoftDelete();
                        PluginManager.RaiseEvent(StringConstants.PLUGIN_EVENT_PRODUCT_ADD_REMOVE_UPDATE);
                        DialogResult = DialogResult.Abort;
                    }
                    catch (Exception err)
                    {
                        if (err.Message.Contains(StringConstants.ERROR_PRODUCT_HAS_STOCK))
                        {
                            ShowError(LanguageStrings.AppError, LanguageStrings.AppProductItemDeleteHasStock);
                        }
                        else if (err.Message.Contains(StringConstants.ERROR_PRODUCT_IN_USE))
                        {
                            ShowError(LanguageStrings.AppError, LanguageStrings.AppProductItemDeleteFailedInUse);
                        }
                        else
                            throw;
                    }
                }
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == tabPageDetails)
                HelpTopic = HelpTopics.ProductEditProductDetails;
            else if (tabControlMain.SelectedTab == tabPageSettings)
                HelpTopic = HelpTopics.ProductEditProductSettings;
            else if (tabControlMain.SelectedTab == tabPageProductItems)
                HelpTopic = HelpTopics.ProductEditProductItems;
            else if (tabControlMain.SelectedTab == tabPageProductGroups)
                HelpTopic = HelpTopics.ProductEditProductGroups;
            else if (tabControlMain.SelectedTab == tabPageProductSEO)
                HelpTopic = HelpTopics.ProductEditProductSEO;
        }

        private void cmbImage_Format(object sender, ListControlConvertEventArgs e)
        {
            
        }

        #endregion Private Methods
    }
}
