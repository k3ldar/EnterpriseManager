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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: SendRemindersWizardWrapper.cs
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

using SalonDiary.Controls;
using Languages;
using Library.BOL.Therapists;
using Library.BOL.Appointments;
using Library.BOL.Users;
using SharedControls.WizardBase;

namespace SalonDiary.Classes
{
    public static class SendRemindersWizardWrapper
    {
        public static void ShowSendRemindersWizard(Controls.SalonDiary salonDiary)
        {
            NewSendAppointmentOptions options = new NewSendAppointmentOptions();
            options.Diary = salonDiary;

            WizardForm.ShowWizard(LanguageStrings.AppDiarySMSAlertWizard,
                new Controls.Wizards.SendReminders.Step1(options),
                new Controls.Wizards.SendReminders.Step2(options),
                new Controls.Wizards.SendReminders.Step3(options));
        }
    }

    public sealed class NewSendAppointmentOptions
    {
        #region Constructors

        public NewSendAppointmentOptions()
        {

        }

        #endregion Constructors

        #region Properties

        internal Controls.SalonDiary Diary { get; set; }

        /// <summary>
        /// Message to be sent
        /// </summary>
        internal string Message { get; set; }

        /// <summary>
        /// List of recipients who will receive the message
        /// </summary>
        internal List<AppointmentReminder> SendList { get; set; }

        #endregion Properties

        #region Public Methods

        #endregion Public Methods

        #region Private Methods

        #endregion Private Methods

        #region Events

        //internal event NewAppointmentEventDelegate AppointmentFound;


        //internal event EventHandler AppointmentSearchFinished;

        #endregion Events
    }


    public sealed class AppointmentReminder
    {
        #region Private Members

        private bool _send;

        #endregion Private Members

        #region Constructors

        public AppointmentReminder (Appointment appointment, string message)
        {
            Appt = appointment;
            Customer = appointment.User.UserName;
            StaffMember = appointment.Therapist.EmployeeName;
            Time = Shared.Utilities.DoubleToTime(appointment.StartTime);
            Treatment = appointment.TreatmentName;
            Telephone = appointment.User.Telephone;
            Send = CanSend;
            
            string day = Appt.AppointmentDate.Date == DateTime.Now.AddDays(1).Date ? "tomorrow" : Appt.AppointmentDate.ToString("dddd");

            FinalMessage = message.Replace("{NAME}", Appt.User.FirstName);
            FinalMessage = FinalMessage.Replace("{DAY}", day);
            FinalMessage = FinalMessage.Replace("{TIME}", Appt.AppointmentAsDateTime().ToString("t"));
            FinalMessage = FinalMessage.Replace("{THERAPIST}", Appt.EmployeeName.Substring(0, Appt.EmployeeName.IndexOf(" ")));

            // is it a valid uk mobile phone number
            string phone = appointment.User.Telephone.Trim();

            if (!String.IsNullOrEmpty(phone))
            {
                try
                {
                    Shared.Validation.Validate(phone, Shared.ValidationTypes.IsNumeric);
                }
                catch (Exception err)
                {
                    if (!err.Message.Contains(StringConstants.ERROR_CONVERT_INVALID_TYPE))
                        throw;
                }

                if (phone.StartsWith(StringConstants.NUMBER_ZERO_DOUBLE))
                    phone = phone.Substring(2);

                if (phone.StartsWith(StringConstants.PHONE_PREFIX_UK))
                {
                    phone = phone.Substring(2);
                    phone = StringConstants.NUMBER_ZERO + phone;
                }

                if (phone.StartsWith(StringConstants.NUMBER_ZERO))
                {
                    phone = StringConstants.PHONE_PREFIX_UK + phone.Substring(1);
                }
            }

            Telephone = phone;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Determines wether the message will be sent or not
        /// </summary>
        public bool Send 
        { 
            get
            {
                return (_send);
            }
            
            set
            {
                if (CanSend)
                    _send = value;
                else
                    _send = false;
            }
        }

        /// <summary>
        /// Name of customer
        /// </summary>
        public string Customer { get; private set; }

        /// <summary>
        /// Customer Telephone Number
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// Member of staff for treatment
        /// </summary>
        public string StaffMember { get; private set; }

        /// <summary>
        /// Time of treatment
        /// </summary>
        public string Time { get; private set; }

        /// <summary>
        /// Name of treatment
        /// </summary>
        public string Treatment { get; private set; }

        /// <summary>
        /// Appointment linked to treatment
        /// </summary>
        internal Appointment Appt { get; private set; }

        internal bool CanSend
        {
            get
            {
                try
                {
                    // is it a valid uk mobile phone number
                    string phone = Shared.Validation.Validate(Telephone, Shared.ValidationTypes.IsNumeric);

                    if (phone.StartsWith(StringConstants.NUMBER_ZERO_DOUBLE))
                        phone = phone.Substring(2);

                    if (phone.StartsWith(StringConstants.PHONE_PREFIX_UK))
                    {
                        phone = phone.Substring(2);
                        phone = StringConstants.NUMBER_ZERO + phone;
                    }

                    return (phone.StartsWith(StringConstants.PHONE_PREFIX_UK_MOBILE) && phone.Length <= 12);
                }
                catch
                {
                    return (false);
                }
            }
        }

        /// <summary>
        /// Message that will be sent to the end user
        /// </summary>
        internal string FinalMessage { get; private set; }

        #endregion Properties
    }
}
