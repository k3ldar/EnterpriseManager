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
 *  File: HelpDeskTicketCard.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System.Drawing;
using Languages;

using SharedBase;
using SharedBase.BOL.Users;

using POS.Base.Classes;
using POS.Base.Plugins;


namespace POS.HelpDesk
{
    public class HelpDeskTicketCard : HomeCard
    {
        #region Private Members

        Forms.Tickets _tickets;

        #endregion Private Members

        public HelpDeskTicketCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            if (!PluginManager.WebsitesEnabled())
                return (false);

            return (user.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.ViewSupportTickets));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.HelpDeskTickets);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (HelpTopics.Tickets);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_tickets == null)
            {
                _tickets = new Forms.Tickets(AppController.ActiveUser);
            }

            return (_tickets);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppHelpDeskTickets);
        }

        public override int StatusPanelCount()
        {
            return (_tickets.GetStatusCount());
        }

        public override string StatusPanelText(int index)
        {
            return (_tickets.GetStatusText(index));
        }

        public override string StatusPanelHint(int index)
        {
            return (_tickets.GetStatusHint(index));
        }

        public override int GetNotificationCount()
        {
            return (AppController.Administration.StatsTickets(Enums.TicketStatus.Open));
        }

        public override Brush GetNotificationColor()
        {
            return (Brushes.Red);
        }

        #region Private Members


        #endregion Private Members
    }
}
