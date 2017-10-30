using System.Drawing;
using Languages;

using Library;
using Library.BOL.Users;

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
