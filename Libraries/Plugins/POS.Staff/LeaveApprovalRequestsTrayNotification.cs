using System;
using Languages;

using POS.Base.Classes;
using POS.Base.Plugins;

namespace POS.Staff
{
    /// <summary>
    /// Tray notification for leave requests
    /// </summary>
    public class LeaveApprovalRequestsTrayNotification : TrayNotification
    {
        #region Constructors

        public LeaveApprovalRequestsTrayNotification(BasePlugin parent)
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
            int leaveRequests = Library.BOL.Staff.Staff.TotalLeaveApprovalRequests(AppController.ActiveUser);
            this.Blinking = leaveRequests > 0;

            string Result = String.Format(LanguageStrings.AppPluginTrayLeaveApprovalRequestTotal, leaveRequests);

            return (Result);
        }

        public override string Name()
        {
            return (LanguageStrings.AppPluginTrayLeaveApprovalRequests);
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
