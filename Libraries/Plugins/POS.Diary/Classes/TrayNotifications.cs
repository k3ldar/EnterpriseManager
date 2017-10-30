using System;
using System.Collections.Generic;
using System.Text;

using Languages;
using Library;
using Library.BOL.Appointments;
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
