﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

using SharedControls.Forms;
using Languages;
using Library;
using POS.Base.Classes;
using POS.Base.Plugins;

using POS.StockControl.Controls;

namespace POS.StockControl
{
    public class StockControlPluginModule : BasePlugin
    {
        #region Private Members

        private StockCard _stockTab;

        private ToolStripSeparator _menuSeperator;
        private ToolStripMenuItem _menuStockMain;
        private ToolStripMenuItem _menuStockStockControl;
        private ToolStripMenuItem _menuStockReOrder;

        #endregion Private Members

        #region Constructors

        public StockControlPluginModule(Form parent)
            : base(parent)
        {
        }

        #endregion Constructors

        #region Overridden Methods

        public override string PluginName()
        {
            return (LanguageStrings.AppPluginStockControl);
        }

        public override PluginVersion Version()
        {
            return (PluginVersion.Version1);
        }

        public override void AfterLoad()
        {

        }

        public override bool BeforeLoad()
        {
            return (true);
        }

        public override bool CanClose()
        {
            return (true);
        }

        public override bool CanUnload()
        {
            return (true);
        }

        public override void Unload()
        {
            // do nothing
        }

        public override void UpdateLanguage(CultureInfo culture)
        {
            if (_menuStockMain != null)
                _menuStockMain.Text = LanguageStrings.AppMenuStockControl;

            if (_menuStockStockControl != null)
                _menuStockStockControl.Text = LanguageStrings.AppMenuStockControl;


            if (_menuStockReOrder != null)
                _menuStockReOrder.Text = LanguageStrings.AppMenuStockControlReOrderLowStock;
        }

        public override void LoadAdministrationSettings(FormSettings settingsForm)
        {
            TreeNode parent = settingsForm.LoadControlOption(
                Languages.LanguageStrings.AppStockControl,
                Languages.LanguageStrings.AppStockControlDescription,
                null, new StockControlSettings());

            settingsForm.LoadControlOption(Languages.LanguageStrings.AppStockReOrder,
                Languages.LanguageStrings.AppStockReOrderDescription,
                parent, new StockControlAutoReorder());
        }

        public override void LoadUserSettings(FormSettings settingsForm)
        {

        }

        public override void MenuAdd(PluginMenuType menuType, ToolStripMenuItem parentMenu)
        {
            switch (menuType)
            {
                case PluginMenuType.Tools:
                    CreateToolMenuItems(parentMenu);
                    break;
            }
        }

        public override void MenuAdd(PluginMenuType menuType, MenuStrip mainMenu)
        {

        }

        public override void MenuDropDown(PluginMenuType menuType)
        {
            _menuStockReOrder.Visible = AppController.LocalSettings.StockAutoReOrder;
        }

        public override HomeCards HomeCards()
        {
            HomeCards Result = new HomeCards();

            if (_stockTab == null)
                _stockTab = new StockCard(this);

            Result.Add(_stockTab);

            return (Result);
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

            foreach (HomeCard card in HomeCards())
            {
                card.EventRaised(e);
            }
        }

        public override void NotificationsGet(ref List<string> names)
        {
            base.NotificationsGet(ref names);
            names.Add(StringConstants.PLUGIN_EVENT_PRODUCT_ADD_REMOVE_UPDATE);
            names.Add(StringConstants.PLUGIN_EVENT_INVOICE_CREATED);
            names.Add(StringConstants.PLUGIN_EVENT_ORDER_DISPATCHED);
        }

        #endregion Notification Events

        #endregion Overridden Methods

        #region Private Methods

        private void CreateToolMenuItems(ToolStripMenuItem parent)
        {
            if (parent.HasDropDownItems)
            {
                _menuSeperator = new ToolStripSeparator();
                parent.DropDownItems.Add(_menuSeperator);
            }

            _menuStockMain = new ToolStripMenuItem(LanguageStrings.AppMenuStockControl);
            parent.DropDownItems.Add(_menuStockMain);

            _menuStockStockControl = new ToolStripMenuItem(LanguageStrings.AppMenuStockControl);
            _menuStockStockControl.Click += menuStockStockControl_Click;
            _menuStockStockControl.ShortcutKeys = Keys.Alt | Keys.K;
            _menuStockMain.DropDownItems.Add(_menuStockStockControl);

            _menuStockReOrder = new ToolStripMenuItem(LanguageStrings.AppMenuStockControlReOrderLowStock);
            _menuStockReOrder.Click += menuStockReOrder_Click;
            _menuStockMain.DropDownItems.Add(_menuStockReOrder);
        }

        private void menuStockReOrder_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionStock(SecurityEnums.SecurityPermissionsStockControl.AutoReOrderStock))
            {
                POS.StockControl.Forms.AutoReOrderForm.ShowReOrderForm(ParentForm);
            }
            else
            {
                MessageBox.Show(LanguageStrings.AppPermissionStockReOrder,
                    LanguageStrings.AppErrorPermisions, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuStockStockControl_Click(object sender, EventArgs e)
        {
            _stockTab.HomeTabButton.ForceClick();
        }

        private void stockButton_POSBringToFront(object sender, EventArgs e)
        {
            base.OnRaiseBringToFront(EventArgs.Empty);
        }

        private void stockButton_PluginUsage(object sender, PluginUsageEventArgs e)
        {
            base.OnRaisePluginUsage(e);
        }

        #endregion Private Methods

    }
}
