using System;
using Languages;

using POS.Base.Classes;
using POS.Base.Plugins;

namespace POS.Staff
{
    /// <summary>
    /// Tray notification for salon updates
    /// </summary>
    public class LeaveAuthorisationRequestsTrayNotification : TrayNotification
    {
        #region Constructors

        public LeaveAuthorisationRequestsTrayNotification(BasePlugin parent)
            : base(parent)
        {
            this.CanBlink = false;
            this.UpdateFrequency = new TimeSpan(0, 30, 0);
            this.Position = 2;
        }

        #endregion Constructors

        #region Overridden Methods

        public override string HintText()
        {
            return (String.Empty);
        }

        public override string StatusText()
        {
            int leaveRequests = Library.BOL.Staff.Staff.TotalLeaveAuthorisationRequests(AppController.ActiveUser);
            this.Blinking = leaveRequests > 0;

            string Result = String.Format(LanguageStrings.AppPluginTrayLeaveAuthorisationRequestTotal, leaveRequests);

            return (Result);
        }

        public override string Name()
        {
            return (LanguageStrings.AppPluginTrayLeaveAuthorisationRequests);
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
