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
 *  File: WebsiteHelpDeskPluginModule.cs
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
using Library.BOL.Helpdesk;
using Library.BOL.ValidationChecks;

using POS.Base.Classes;
using POS.Base.Plugins;

using POS.HelpDesk.Forms;

namespace POS.HelpDesk
{
    public class WebsiteHelpDeskPluginModule : BasePlugin
    {
        #region Private Members

        private HelpDeskTicketCard _ticketTab;

        private ToolStripMenuItem menuToolsSupportTickets;
        private ToolStripSeparator menuToolsSupportTicketsSeperator;

        #endregion Private Members

        #region Constructors

        public WebsiteHelpDeskPluginModule(Form parent)
            : base(parent)
        {

        }

        #endregion Constructors

        #region Overridden Methods

        public override PluginVersion Version()
        {
            return (PluginVersion.Version1);
        }

        public override string PluginName()
        {
            return (LanguageStrings.AppPluginHelpDesk);
        }

        public override bool CanUnload()
        {
            return (true);
        }

        public override void Unload()
        {
            // remove the menu items
            menuToolsSupportTickets.Owner.Items.Remove(menuToolsSupportTickets);
            menuToolsSupportTickets.Dispose();
            menuToolsSupportTickets = null;

            menuToolsSupportTicketsSeperator.Owner.Items.Remove(menuToolsSupportTicketsSeperator);
            menuToolsSupportTicketsSeperator.Dispose();
            menuToolsSupportTicketsSeperator = null;
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
            menuToolsSupportTickets.Text = LanguageStrings.AppMenuSupportTickets;
        }

        public override void LoadAdministrationSettings(FormSettings settingsForm)
        {

        }

        public override void LoadUserSettings(FormSettings settingsForm)
        {

        }

        public override bool CanClose()
        {
            bool Result = true;

            if (ParentForm.IsDisposed)
                return (Result);

            return (Result);
        }

        public override void MenuAdd(PluginMenuType menuType, ToolStripMenuItem parentMenu)
        {
            switch (menuType)
            {
                case PluginMenuType.Tools:
                    CreateToolsMenu(parentMenu);
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

            if (_ticketTab == null)
                _ticketTab = new HelpDeskTicketCard(this);

            Result.Add(_ticketTab);

            return (Result);
        }

        #region Notification Items

        /// <summary>
        /// Retrieves Tray Notification Items
        /// </summary>
        /// <returns></returns>
        public override TrayNotificationCollection TrayNotifications()
        {
            TrayNotificationCollection Result = new TrayNotificationCollection();

            Result.Add(new TicketTrayStatus(this));

            return (Result);
        }

        #endregion Notification Items

        #region Notification Events

        public override void Notification(NotificationEventArgs e)
        {
            base.Notification(e);

            switch (e.EventName)
            {
                case StringConstants.PLUGIN_EVENT_VIEW_TICKET:
                    ViewTicket((SupportTicket)e.EventValue);
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
            names.Add(StringConstants.PLUGIN_EVENT_VIEW_TICKET);
        }

        #endregion Notification Events

        #endregion Overridden Methods

        #region Private Methods

        private void ViewTicket(SupportTicket ticket)
        {
            Ticket supportTicket = new Ticket(AppController.ActiveUser, ticket);
            try
            {
                supportTicket.ShowDialog(ParentForm);
            }
            finally
            {
                supportTicket.Dispose();
                supportTicket = null;
            }
        }

        private void CreateToolsMenu(ToolStripMenuItem parent)
        {
            menuToolsSupportTickets = new ToolStripMenuItem(LanguageStrings.AppMenuSupportTickets);
            menuToolsSupportTickets.Click += menuToolsSupportTickets_Click;
            parent.DropDownItems.Insert(0, menuToolsSupportTickets);

            menuToolsSupportTicketsSeperator = new ToolStripSeparator();
            parent.DropDownItems.Insert(1, menuToolsSupportTicketsSeperator);
        }

        void menuToolsSupportTickets_Click(object sender, EventArgs e)
        {
            _ticketTab.HomeTabButton.ForceClick();
        }

        #endregion Private Methods
    }
}
