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
 *  File: TillPluginModule.cs
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
using Library.BOL.Appointments;
using Library.BOL.Basket;

using POS.Base.Classes;
using POS.Base.Plugins;

using POS.Till.Forms;

namespace POS.Till
{
    public class TillPluginModule : BasePlugin
    {
        #region Private Members

        private TillCard _tillTab;

        private ToolStripSeparator _menuSeperator;
        private ToolStripMenuItem _menuTill;

        #endregion Private Members

        #region Constructors

        public TillPluginModule(Form parent)
            : base(parent)
        {

        }

        #endregion Constructors

        public override string PluginName()
        {
            return (LanguageStrings.AppPluginTill);
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
            if (_menuTill != null)
                _menuTill.Text = LanguageStrings.AppMenuButtonTill;
        }

        public override void LoadAdministrationSettings(FormSettings settingsForm)
        {
            //settingsForm.LoadControlOption(Languages.LanguageStrings.AppSettingsTill,
            //    Languages.LanguageStrings.AppTillSettingsDescription,
            //    null, new Controls.Settings.LocalUser.TillSettings());
        }

        public override void LoadUserSettings(FormSettings settingsForm)
        {
            settingsForm.LoadControlOption(Languages.LanguageStrings.AppSettingsTill,
                Languages.LanguageStrings.AppTillSettingsDescription,
                null, new Controls.TillSettings());
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

        }

        public override HomeCards HomeCards()
        {
            HomeCards Result = new HomeCards();

            if (_tillTab == null)
                _tillTab = new TillCard(this);

            Result.Add(_tillTab);

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

            switch (e.EventName)
            {
                case StringConstants.PLUGIN_EVENT_TAKE_PAYMENT:
                    TakePayment((Appointment)e.EventValue);
                    break;
                case StringConstants.PLUGIN_EVENT_SHOW_TILL_DISCOUNT:
                    ShowTillDiscountForm((ShoppingBasket)e.EventValue);
                    break;

                case StringConstants.PLUGIN_EVENT_SHOW_CUSTOM_VAT_RATE:
                    CustomVATRateForm.CustomVATRateShow(ParentForm, (ShoppingBasket)e.EventValue);
                    break;

                case StringConstants.PLUGIN_EVENT_SHOW_MARK_AS_PAID:
                    ShowMarkAsPaid(e);
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
            names.Add(StringConstants.PLUGIN_EVENT_TAKE_PAYMENT);
            names.Add(StringConstants.PLUGIN_EVENT_SHOW_TILL_DISCOUNT);
            names.Add(StringConstants.PLUGIN_EVENT_SHOW_CUSTOM_VAT_RATE);
            names.Add(StringConstants.PLUGIN_EVENT_SHOW_MARK_AS_PAID);
            names.Add(StringConstants.PLUGIN_EVENT_TREATMENT_ADD_REMOVE_UPDATE);
            names.Add(StringConstants.PLUGIN_EVENT_PRODUCT_ADD_REMOVE_UPDATE);
        }

        #endregion Notification Events

        #region Private Methods

        private void ShowMarkAsPaid(NotificationEventArgs args)
        {
            MarkAsPaidForm frm = new MarkAsPaidForm(false);
            try
            {
                frm.ShowDialog(ParentForm);

                args.Result = frm.DialogResult == System.Windows.Forms.DialogResult.OK;

                if ((bool)args.Result)
                {
                    args.Param4 = frm.PaymentStatus;
                    args.Param5 = frm.AdditionalPaymentInformation;
                }
            }
            finally
            {
                frm.Dispose();
                frm = null;
            }
        }

        private void ShowTillDiscountForm(ShoppingBasket basket)
        {
            TillDiscountForm frm = new TillDiscountForm();
            try
            {
                frm.Basket = basket;
                frm.ShowDialog(ParentForm);
            }
            finally
            {
                frm.Dispose();
                frm = null;
            }
        }

        private void TakePayment(Appointment appointment)
        {
            _tillTab.ShowTill(appointment);
        }

        private void CreateToolMenuItems(ToolStripMenuItem parent)
        {
            if (parent.HasDropDownItems)
            {
                _menuSeperator = new ToolStripSeparator();
                parent.DropDownItems.Add(_menuSeperator);
            }

            _menuTill = new ToolStripMenuItem(LanguageStrings.AppMenuButtonTill);
            _menuTill.ShortcutKeys = Keys.F7;
            _menuTill.Click += _menuTill_Click;
            parent.DropDownItems.Add(_menuTill);
        }

        private void _menuTill_Click(object sender, EventArgs e)
        {
            _tillTab.HomeTabButton.ForceClick();
        }


        private void tillButton_PluginUsage(object sender, PluginUsageEventArgs e)
        {

        }

        private void _tillButton_POSBringToFront(object sender, EventArgs e)
        {
            base.OnRaiseBringToFront(EventArgs.Empty);
        }


        #endregion Private Methods
    }
}
