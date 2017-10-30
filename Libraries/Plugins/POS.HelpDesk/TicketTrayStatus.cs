using System;
using Languages;
using Library;

using POS.Base.Classes;
using POS.Base.Plugins;

namespace POS.HelpDesk
{
    public class TicketTrayStatus : TrayNotification
    {
        #region Private Members

        private BasePlugin _parent;

        #endregion Private Members

        #region Constructor

        public TicketTrayStatus(BasePlugin parent)
            : base(parent)
        {
            _parent = parent;
            this.CanBlink = true;
            this.UpdateFrequency = new TimeSpan(0, 0, 30);
            this.Position = 1;
        }

        #endregion Constructor

        #region Overridden Methods

        public override string HintText()
        {
            return (String.Empty);
        }

        public override string StatusText()
        {
            int countTickets = AppController.Administration.StatsTickets(Enums.TicketStatus.Open);
            this.CanBlink = countTickets > 0;
            this.Blinking = countTickets > 0;

            string Result = StringConstants.PREFIX_AND_SPACE + LanguageStrings.AppOpenTickets;

            if (countTickets == 1)
                Result = StringConstants.PREFIX_AND_SPACE + LanguageStrings.AppOpenTicket;

            Result = String.Format(Result, countTickets);

            return (Result);
        }

        public override string Name()
        {
            return (LanguageStrings.AppPluginTrayHelpDeskTickets);
        }

        public override void DoubleClick()
        {

        }

        public override bool CanLoad()
        {
            return (true);
        }

        public override bool CanUnload()
        {
            return (true);
        }

        public override void Unload()
        {

        }

        public override void Load()
        {

        }

        #endregion Overridden Methods
    }
}
