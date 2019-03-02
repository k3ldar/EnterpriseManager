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
 *  File: Step3.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using SharedControls.Interfaces;

using SalonDiary.Classes;
using Languages;
using SharedBase.BOL.Therapists;
using SharedBase.BOL.Appointments;
using SharedBase.BOL.Users;
using SharedControls.WizardBase;

namespace SalonDiary.Controls.Wizards.SendReminders
{
    public partial class Step3 : BaseWizardPage
    {
        #region Private Members

        private NewSendAppointmentOptions _options;

        private bool _allowBack = true;

        #endregion Private Members

        #region Constructors

        public Step3(NewSendAppointmentOptions options)
        {
            InitializeComponent();
            _options = options;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            btnSend.Text = LanguageStrings.AppSend;
        }

        public override void PageShown()
        {
            lblHeader.Text = String.Format(LanguageStrings.AppDiaryReminderSendPrompt, _options.SendList.Count);
            lblSendMessage.Visible = false;
        }

        public override bool PreviousClicked()
        {
            if (!_allowBack)
            {
                return (false);
            }

            return base.PreviousClicked();
        }

        public override bool NextClicked()
        {
            return base.NextClicked();
        }

        #endregion Overridden Methods

        private void btnSend_Click(object sender, EventArgs e)
        {
            this.MainWizardForm.Cursor = Cursors.WaitCursor;
            try
            {
                lblSendMessage.Visible = true;
                ISMSSend iSMSSend = _options.Diary.RaiseGetSMSInterace();

                foreach (AppointmentReminder reminder in _options.SendList)
                {
                    lblSendMessage.Text = String.Format(LanguageStrings.AppDiaryReminderSending, reminder.Customer, reminder.Telephone);
                    
                    if (!iSMSSend.SendSMS(reminder.Telephone, reminder.FinalMessage))
                    {
                        ShowError(LanguageStrings.AppError, LanguageStrings.AppDiaryReminderSendFailed);
                        return;
                    }
                    else
                    {
                        reminder.Appt.ReminderSent(_options.Diary.User);
                        _allowBack = false;
                    }

                    lblSendMessage.Text = String.Format(LanguageStrings.AppDiaryReminderSent, reminder.Customer);
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(500);
                }
            }
            finally
            {
                this.MainWizardForm.Cursor = Cursors.Arrow;
            }

            ShowInformation(LanguageStrings.AppRemindersSendReminders, LanguageStrings.AppRemindersSent);
            MainWizardForm.ForceFinish();
        }

        #region Private Methods

        #endregion Private Methods
    }
}
