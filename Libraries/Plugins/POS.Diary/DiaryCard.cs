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
 *  File: DiaryCard.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System.Drawing;

using SharedControls.Forms;
using Languages;
using Library;
using Library.BOL.Appointments;

using POS.Base.Classes;
using POS.Base.Plugins;
using Library.BOL.Users;

namespace POS.Diary
{
    public class DiaryCard : HomeCard
    {
        #region Private Members

        POS.Diary.Controls.SalonCalendarControl _salonControl;

        #endregion Private Members

        public DiaryCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.ViewDiary));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.Calendar);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (HelpTopics.Diary);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_salonControl == null)
            {
                _salonControl = new POS.Diary.Controls.SalonCalendarControl();
                _salonControl.PayNow += saloncontrol_PayNow;
            }

            return (_salonControl);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppDiaryTab);
        }

        public override int StatusPanelCount()
        {
            return (_salonControl.GetStatusCount());
        }

        public override string StatusPanelText(int index)
        {
            return (_salonControl.GetStatusText(index));
        }

        public override string StatusPanelHint(int index)
        {
            return (_salonControl.GetStatusHint(index));
        }

        public override int SortOrder()
        {
            return (20);
        }

        #region Private Members


        private void saloncontrol_PayNow(object sender, SalonDiary.Controls.AppointmentPayNowEventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionCalendar(SecurityEnums.SecurityPermissionsCalendar.TakePayment))
                RaisePayNow(e.Appointment);
            else
                ((BaseForm)Parent.ParentForm).ShowError(LanguageStrings.AppTillTakePayments, LanguageStrings.AppPermissionTakePayment);
        }

        internal void RaisePayNow(Library.BOL.Appointments.Appointment appointment)
        {
            if (appointment.MasterAppointment > -1)
                appointment = Appointments.Get(appointment.MasterAppointment);

            Parent.RaiseEventNotification(new NotificationEventArgs(StringConstants.PLUGIN_EVENT_TAKE_PAYMENT, appointment));
        }

        #endregion Private Members
    }
}
