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
 *  File: TrayNotifications.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Text;

using Languages;
using SharedBase;
using SharedBase.BOL.Appointments;
using POS.Base.Classes;
using POS.Base.Plugins;

namespace POS.Diary.Classes
{//AppTrayAppointmentsInProgress
    /// <summary>
    /// Tray notification for new appointments
    /// </summary>
    public class NewAppointmentsTrayNotification : TrayNotification
    {
        #region Constructors

        public NewAppointmentsTrayNotification(BasePlugin parent)
            : base(parent)
        {
            this.CanBlink = true;
            this.UpdateFrequency = new TimeSpan(0, 0, 30);
            this.Position = 3;
        }

        #endregion Constructors

        #region Overridden Methods

        public override string HintText()
        {
            return (String.Empty);
        }

        public override string StatusText()
        {
            int countNewAppointments = AppController.Administration.StatsAppointments(Enums.AppointmentStats.NewAppointments);
            this.Blinking = countNewAppointments > 0;
            this.CanBlink = countNewAppointments > 0;

            string Result = StringConstants.PREFIX_AND_SPACE + LanguageStrings.AppNewAppointments;

            if (countNewAppointments == 1)
                Result = StringConstants.PREFIX_AND_SPACE + LanguageStrings.AppNewAppointment;

            Result = String.Format(Result, countNewAppointments);

            return (Result);
        }

        public override string Name()
        {
            return (LanguageStrings.AppPluginTrayNewAppointments);
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

    /// <summary>
    /// Tray notification for new appointments
    /// </summary>
    public class TodaysAppointmentsTrayNotification : TrayNotification
    {
        #region Constructors

        public TodaysAppointmentsTrayNotification(BasePlugin parent)
            : base(parent)
        {
            this.CanBlink = false;
            this.UpdateFrequency = new TimeSpan(0, 0, 30);
            this.Position = 3;
        }

        #endregion Constructors

        #region Overridden Methods

        public override string HintText()
        {
            return (String.Empty);
        }

        public override string StatusText()
        {
            Appointments _appointments = Appointments.Get(DateTime.Now);
            int countNewAppointments = 0;

            foreach (Appointment appt in _appointments)
            {
                if (appt.AppointmentType == 0 && appt.Status == Enums.AppointmentStatus.Confirmed)
                    countNewAppointments++;
            }

            this.Blinking = countNewAppointments > 0;

            string Result = StringConstants.PREFIX_AND_SPACE + LanguageStrings.AppTodaysAppointments;

            if (countNewAppointments == 1)
                Result = StringConstants.PREFIX_AND_SPACE + LanguageStrings.AppTodaysAppointments;

            Result = String.Format(Result, countNewAppointments);

            return (Result);
        }

        public override string Name()
        {
            return (LanguageStrings.AppTrayTodaysAppointments);
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

    /// <summary>
    /// Tray notification for new appointments
    /// </summary>
    public class AppointmentsInProgressTrayNotification : TrayNotification
    {
        #region Constructors

        public AppointmentsInProgressTrayNotification(BasePlugin parent)
            : base(parent)
        {
            this.CanBlink = false;
            this.UpdateFrequency = new TimeSpan(0, 0, 30);
            this.Position = 3;
        }

        #endregion Constructors

        #region Overridden Methods

        public override string HintText()
        {
            return (String.Empty);
        }

        public override string StatusText()
        {
            Appointments _appointments = Appointments.Get(DateTime.Now); 
            int count = 0;

            foreach (Appointment appt in _appointments)
            {
                if (appt.Status == Enums.AppointmentStatus.Arrived)
                    count++;
            }

            string Result = StringConstants.PREFIX_AND_SPACE + LanguageStrings.AppTrayAppointmentsInProgress;

            Result = String.Format(Result, count);

            return (Result);
        }

        public override string Name()
        {
            return (LanguageStrings.AppTrayTodaysAppointments);
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
