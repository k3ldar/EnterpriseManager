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
 *  File: LeaveApprovalRequestsTrayNotification.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
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
            int leaveRequests = SharedBase.BOL.Staff.Staff.TotalLeaveApprovalRequests(AppController.ActiveUser);
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
