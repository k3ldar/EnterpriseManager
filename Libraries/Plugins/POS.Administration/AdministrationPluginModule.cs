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
 *  File: AdministrationPluginModule.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

using SharedControls.Forms;
using Languages;

using Library;
using Library.BOL.Products;
using Library.BOL.Statistics;

using POS.Base.Classes;
using POS.Base.Plugins;

using POS.Administration.Forms.Products;

#pragma warning disable IDE1006

namespace POS.Administration
{
    public class AdministrationPluginModule : BasePlugin
    {
        #region Private Members

        private SalonTreatmentCard _treatmentsTab;
        private SystemEmailCard _systemEmailsTab;
        private DiscountCouponCard _discountCouponTab;
        private TopProductsCard _topProductsTab;
        private ProductGroupCard _productGroupsTab;
        private ProductsCard _productsTab;
        private CategoriesCard _typesCard;

        private ToolStripMenuItem menuAdministrationProducts;
        private ToolStripSeparator menuAdministrationProductsSeperator;
        private ToolStripMenuItem menuAdministrationProductsProducts;
        private ToolStripMenuItem menuAdministrationProductsProductGroups;
        private ToolStripSeparator menuAdministrationProductsProductsSeperator;
        private ToolStripMenuItem menuAdministrationProductsProductsSetTopProducts;
        private ToolStripMenuItem menuAdministrationDiscountCoupons;
        private ToolStripSeparator menuAdministrationDiscountCouponsSeperator;
        private ToolStripMenuItem menuAdministrationSystemEmails;

        #endregion Private Members

        #region Constructors

        public AdministrationPluginModule(Form parent)
            : base(parent)
        {
            RaiseAlerts = true;
            AlertFrequency = new TimeSpan(0, 30, 0);
        }

        #endregion Constructors

        #region Overridden Methods

        public override PluginVersion Version()
        {
            return (PluginVersion.Version1);
        }

        public override string PluginName()
        {
            return (LanguageStrings.AppPluginAdministration);
        }

        public override bool CanUnload()
        {
            return (true);
        }

        public override void Unload()
        {

        }

        public override bool BeforeLoad()
        {
            return (true);
        }

        public override void AfterLoad()
        {

        }

        public override void UpdateLanguage(CultureInfo culture)
        {
            menuAdministrationSystemEmails.Text = LanguageStrings.AppMenuSystemEmails;

            menuAdministrationProducts.Text = LanguageStrings.AppMenuProducts;
            menuAdministrationProductsProducts.Text = LanguageStrings.AppMenuProducts;
            menuAdministrationProductsProductGroups.Text = LanguageStrings.AppMenuProductGroups;

            menuAdministrationProductsProductsSetTopProducts.Text = LanguageStrings.AppMenuProductsSetTopProducts;

            menuAdministrationDiscountCoupons.Text = LanguageStrings.AppMenuDiscountCoupons;
        }

        public override void LoadAdministrationSettings(FormSettings settingsForm)
        {
            settingsForm.LoadControlOption(LanguageStrings.AppProducts,
                LanguageStrings.AppProductVerificationSettings,
                null, new Controls.ProductVerificationSettings());

        }

        public override void LoadUserSettings(FormSettings settingsForm)
        {

        }

        public override bool CanClose()
        {
            return (true);
        }

        public override void MenuAdd(PluginMenuType menuType, ToolStripMenuItem parentMenu)
        {
            switch (menuType)
            {
                case PluginMenuType.Administration:
                    CreateAdministrationMenu(parentMenu);
                    break;
            }
        }

        public override void MenuAdd(PluginMenuType menuType, MenuStrip mainMenu)
        {

        }

        public override void MenuDropDown(PluginMenuType menuType)
        {

        }

        public override HomeCards HomeCards()
        {
            HomeCards Result = new HomeCards();

            if (_treatmentsTab == null)
                _treatmentsTab = new SalonTreatmentCard(this);

            if (_systemEmailsTab == null)
                _systemEmailsTab = new SystemEmailCard(this);

            if (_discountCouponTab == null)
                _discountCouponTab = new DiscountCouponCard(this);

            if (_topProductsTab == null)
                _topProductsTab = new TopProductsCard(this);

            if (_productGroupsTab == null)
                _productGroupsTab = new ProductGroupCard(this);

            if (_productsTab == null)
                _productsTab = new ProductsCard(this);

            if (_typesCard == null)
                _typesCard = new CategoriesCard(this);

            Result.Add(_productsTab);
            Result.Add(_treatmentsTab);
            Result.Add(_systemEmailsTab);
            Result.Add(_discountCouponTab);
            Result.Add(_topProductsTab);
            Result.Add(_productGroupsTab);
            Result.Add(_typesCard);

            return (Result);
        }

        public override void Alert()
        {
            SimpleStatistics statsDuplicateSKU = Products.DuplicateSKUCodes();

            if (statsDuplicateSKU.Count > 0)
                AddToastNotification("Invalid SKU Found", LoadProductsDuplicateSKU, statsDuplicateSKU);

            SimpleStatistics statsInvalidSKU = Products.InvalidSKUCodes();

            if (statsInvalidSKU.Count > 0)
                AddToastNotification("duplicate product SKU's found", LoadProductInvalidSKU, statsInvalidSKU);
        }

        #region Notification Items

        /// <summary>
        /// Retrieves Tray Notification Items
        /// </summary>
        /// <returns></returns>
        public override TrayNotificationCollection TrayNotifications()
        {
            return (null);
        }

        #endregion Notification Items

        #region Notification Events

        public override void Notification(NotificationEventArgs e)
        {
            base.Notification(e);

            switch (e.EventName)
            {
                case POS.Base.Classes.StringConstants.PLUGIN_EVENT_EDIT_PRODUCT_ITEM:
                    EditProduct((Product)e.EventValue);
                    break;

                case POS.Base.Classes.StringConstants.PLUGIN_EVENT_EDIT_SALON_TREATMENTS:
                    EditSalonTreatments();
                    break;

                case POS.Base.Classes.StringConstants.PLUGIN_EVENT_SELECT_SALON:
                    SelectSalon();
                    break;

                default:
                    foreach (HomeCard card in HomeCards())
                    {
                        card.EventRaised(e);
                    }

                    break;
            }
        }

        public override void NotificationsGet(ref List<string> names)
        {
            base.NotificationsGet(ref names);
            names.Add(Base.Classes.StringConstants.PLUGIN_EVENT_EDIT_PRODUCT_ITEM);
            names.Add(Base.Classes.StringConstants.PLUGIN_EVENT_EDIT_SALON_TREATMENTS);
            names.Add(Base.Classes.StringConstants.PLUGIN_EVENT_SELECT_SALON);
        }

        #endregion Notification Events

        #endregion Overridden Methods

        #region Private Methods

        private void SelectSalon()
        {
        }

        private void EditSalonTreatments()
        {
            _treatmentsTab.HomeTabButton.ForceClick();
        }

        private void CreateAdministrationMenu(ToolStripMenuItem parent)
        {
            menuAdministrationProducts = new ToolStripMenuItem(LanguageStrings.AppMenuProducts);
            parent.DropDownItems.Add(menuAdministrationProducts);

            menuAdministrationProductsSeperator = new ToolStripSeparator();
            parent.DropDownItems.Add(menuAdministrationProductsSeperator);

            menuAdministrationProductsProducts = new ToolStripMenuItem(LanguageStrings.AppMenuProducts);
            menuAdministrationProductsProducts.ShortcutKeys = Keys.F8;
            menuAdministrationProductsProducts.Click += menuAdministrationProductsProducts_Click;
            menuAdministrationProducts.DropDownItems.Add(menuAdministrationProductsProducts);

            menuAdministrationProductsProductGroups = new ToolStripMenuItem(LanguageStrings.AppMenuProductGroups);
            menuAdministrationProductsProductGroups.Click += menuAdministrationProductsProductGroups_Click;
            menuAdministrationProductsProductGroups.ShortcutKeys = Keys.Alt | Keys.G;
            menuAdministrationProducts.DropDownItems.Add(menuAdministrationProductsProductGroups);

            menuAdministrationProductsProductsSeperator = new ToolStripSeparator();
            menuAdministrationProducts.DropDownItems.Add(menuAdministrationProductsProductsSeperator);

            menuAdministrationProductsProductsSetTopProducts = new ToolStripMenuItem(
                LanguageStrings.AppMenuProductsSetTopProducts);
            menuAdministrationProductsProductsSetTopProducts.Click += menuAdministrationProductsProductsSetTopProducts_Click;
            menuAdministrationProducts.DropDownItems.Add(menuAdministrationProductsProductsSetTopProducts);


            menuAdministrationDiscountCoupons = new ToolStripMenuItem(LanguageStrings.AppMenuDiscountCoupons);
            menuAdministrationDiscountCoupons.Click += menuAdministrationDiscountCoupons_Click;
            menuAdministrationDiscountCoupons.ShortcutKeys = Keys.Alt | Keys.C;
            parent.DropDownItems.Add(menuAdministrationDiscountCoupons);

            menuAdministrationDiscountCouponsSeperator = new ToolStripSeparator();
            parent.DropDownItems.Add(menuAdministrationDiscountCouponsSeperator);

            menuAdministrationSystemEmails = new ToolStripMenuItem(LanguageStrings.AppMenuSystemEmails);
            menuAdministrationSystemEmails.Click += menuAdministrationSystemEmails_Click;
            menuAdministrationSystemEmails.ShortcutKeys = Keys.Alt | Keys.E;
            parent.DropDownItems.Add(menuAdministrationSystemEmails);
        }

        private void menuAdministrationSystemEmails_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AdministerSystemEmails))
            {
                _systemEmailsTab.HomeTabButton.ForceClick();
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissions,
                    LanguageStrings.AppPermissionSystemEmails), LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void menuAdministrationDiscountCoupons_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AdministerCoupons))
            {
                _discountCouponTab.HomeTabButton.ForceClick();
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissions,
                    LanguageStrings.AppPermissionAdminiserCoupons), LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void menuAdministrationProductsProductsSetTopProducts_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AdministerProducts))
            {
                _topProductsTab.HomeTabButton.ForceClick();
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissions,
                    LanguageStrings.AppPermissionProductGroup), LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void menuAdministrationProductsProductGroups_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AdministerProducts))
            {
                _productGroupsTab.HomeTabButton.ForceClick();
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissions,
                    LanguageStrings.AppPermissionProductGroup), LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void menuAdministrationProductsProducts_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AdministerProducts))
            {
                _productsTab.HomeTabButton.ForceClick();
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissions,
                    LanguageStrings.AppPermissionProducts), LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Edit's a product item
        /// </summary>
        /// <param name="product"></param>
        private void EditProduct(Product product)
        {
            AdminProductEdit productEdit = new AdminProductEdit(AppController.ActiveUser,
                new Library.WebsiteAdministration(AppController.ActiveUser),
                product);
            try
            {
                productEdit.ShowDialog(ParentForm);
            }
            finally
            {
                productEdit.Dispose();
                productEdit = null;
            }

        }

        #region Toast Actions

        private void LoadProductInvalidSKU(object data)
        {
            InvalidProductSKU frm = new InvalidProductSKU(LanguageStrings.AppProductInvalidSKUCodes,
                LanguageStrings.AppProductInvalidSKUCodesDescription, (SimpleStatistics)data);
            frm.Show(ParentForm);
        }

        private void LoadProductsDuplicateSKU(object data)
        {
            InvalidProductSKU frm = new InvalidProductSKU(LanguageStrings.AppProductDuplicateSKUCodes,
                LanguageStrings.AppProductDuplicateSKUCodesDescription, (SimpleStatistics)data);

            frm.Show(ParentForm);
        }

        #endregion Toast Actions

        #endregion Private Methods
    }
}
