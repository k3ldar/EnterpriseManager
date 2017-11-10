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
 *  File: Step2.cs
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

using SalonDiary.Classes;
using Languages;
using Library.BOL.Therapists;
using Library.BOL.Appointments;
using Library.BOL.Users;
using SharedControls.WizardBase;

namespace SalonDiary.Controls.Wizards.SendReminders
{
    public partial class Step2 : BaseWizardPage
    {
        #region Private Members

        private NewSendAppointmentOptions _options;

        #endregion Private Members

        #region Constructors

        public Step2(NewSendAppointmentOptions options)
        {
            InitializeComponent();
            _options = options;

            dtpDate.MinDate = DateTime.Now.AddDays(1);
            dtpDate.MaxDate = DateTime.Now.AddDays(5);
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblAppointmentDate.Text = LanguageStrings.AddSelectAppointmentDate;

            if (gridReminders.Columns.Count == 0)
                return;
            
            gridReminders.Columns[0].HeaderText = LanguageStrings.AppSend;
            gridReminders.Columns[1].HeaderText = LanguageStrings.AppCustomer;
            gridReminders.Columns[2].HeaderText = LanguageStrings.Telephone;
            gridReminders.Columns[3].HeaderText = LanguageStrings.StaffMember;
            gridReminders.Columns[4].HeaderText = LanguageStrings.AppTime;
            gridReminders.Columns[5].HeaderText = LanguageStrings.Treatment;
        }

        public override void PageShown()
        {
            LoadCustomers();
            LanguageChanged(System.Threading.Thread.CurrentThread.CurrentUICulture);
        }

        public override bool NextClicked()
        {
            for (int i = _options.SendList.Count -1; i >= 0; i--)
            {
                AppointmentReminder item = _options.SendList[i];

                if (!item.Send)
                    _options.SendList.RemoveAt(i);
            }

            if (_options.SendList.Count == 0)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppDiaryReminderNoneSelected);
                return (false);
            }

            return base.NextClicked();
        }

        #endregion Overridden Methods

        #region Private Methods

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            if (String.IsNullOrEmpty(_options.Message))
                return;

            Appointments daysAppointments = Appointments.Get(dtpDate.Value);
            _options.SendList = new List<AppointmentReminder>();

            foreach (Appointment appt in daysAppointments)
            {
                switch (appt.Status)
                {
                    case Library.Enums.AppointmentStatus.Confirmed:
                    case Library.Enums.AppointmentStatus.Requested:
                        if (appt.AllowSendReminder() && appt.Therapist != null)
                            _options.SendList.Add(new AppointmentReminder(appt, _options.Message));

                        break;
                }
            }

            gridReminders.DataSource = _options.SendList;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            AppointmentReminder item = (AppointmentReminder)gridReminders.Rows[e.RowIndex].DataBoundItem;

            if (item.CanSend)
            {
                e.CellStyle.BackColor = Color.White;
                e.CellStyle.ForeColor = Color.Black;
            }
            else
            {
                e.CellStyle.BackColor = Color.Red;
                e.CellStyle.ForeColor = Color.White;
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            AppointmentReminder item = (AppointmentReminder)gridReminders.Rows[e.RowIndex].DataBoundItem;

            if (!item.CanSend && item.Send)
                item.Send = false;

            gridReminders.Invalidate();
        }

        private void gridReminders_Scroll(object sender, ScrollEventArgs e)
        {
            gridReminders.Invalidate();
        }

        private void gridReminders_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            try
            {
                AppointmentReminder item = (AppointmentReminder)gridReminders.Rows[e.RowIndex].DataBoundItem;

                string day = item.Appt.AppointmentDate.Date == DateTime.Now.AddDays(1).Date ? LanguageStrings.AppTomorrow : item.Appt.AppointmentDate.ToString(StringConstants.DATE_FORMAT_TIME);

                e.ToolTipText = _options.Message.Replace(StringConstants.SMS_NAME, item.Appt.User.FirstName);
                e.ToolTipText = e.ToolTipText.Replace(StringConstants.SMS_DAY, day);
                e.ToolTipText = e.ToolTipText.Replace(StringConstants.SMS_TIME, Shared.Utilities.DoubleToTime(item.Appt.StartTime));
                e.ToolTipText = e.ToolTipText.Replace(StringConstants.SMS_EMPLOYEE, item.Appt.EmployeeName.Substring(0, item.Appt.EmployeeName.IndexOf(StringConstants.SYMBOL_SPACE)));
                e.ToolTipText = Shared.Utilities.WordWrap(e.ToolTipText, 30);
            }
            catch
            {
                e.ToolTipText = String.Empty;
            }
        }

        private void gridReminders_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        #endregion Private Methods
    }
}
