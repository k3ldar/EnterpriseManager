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
