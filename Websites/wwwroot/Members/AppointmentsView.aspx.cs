using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Languages;
using Website.Library.Classes;
using Library.BOL.Appointments;
using Library.Utils;

namespace SieraDelta.Website.Members
{
    public partial class ViewSalonAppointment : BaseWebFormMember
    {
        Appointment _appointment;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Global.AllowCreditCards)
            {
                DoRedirect("/Error/InvalidPermissions", true);
            }

            lblError.Visible = false;
            _appointment = Appointments.Get(SharedUtils.StrToIntDef((string)Page.RouteData.Values["id"], -1));
            btnCancel.Visible = false;

            if (_appointment == null || _appointment.UserID != GetUserSession().UserID)
                DoRedirect("/Account/Appointments/");

            TimeSpan span = _appointment.AppointmentAsDateTime() - DateTime.Now;

            switch (_appointment.Status)
            {
                case Library.Enums.AppointmentStatus.Confirmed:
                    if (span.TotalHours > 48)
                        btnCancel.Visible = true;

                    break;
                case Library.Enums.AppointmentStatus.Requested:
                    if (span.TotalHours > 48)
                        btnCancel.Visible = true;

                    break;
            }
        }

        protected string GetApptDateTime()
        {
            return (Shared.Utilities.DateTimeToStr(_appointment.AppointmentAsDateTime(), WebCulture));
        }

        protected string GetApptDuration()
        {
            return (String.Format("{0} minutes", _appointment.Duration));
        }

        protected string GetApptTherapist()
        {
            return (_appointment.EmployeeName);
        }

        protected string GetApptStatus()
        {
            return (Shared.Utilities.SplitCamelCase(_appointment.Status.ToString()));
        }

        protected string GetApptDateCreated()
        {
            return (Shared.Utilities.DateTimeToStr(_appointment.Created, WebCulture));
        }

        protected string GetApptDateAltered()
        {
            return (Shared.Utilities.DateTimeToStr(_appointment.LastAltered, WebCulture));
        }

        protected string GetApptID()
        {
            return (_appointment.ID.ToString());
        }

        protected string GetApptAlteredBy()
        {
            return (_appointment.LastAlteredBy);
        }

        protected string GetApptTreatment()
        {
            return (_appointment.TreatmentName);
        }

        protected string GetApptLocked()
        {
            return (String.Format("{0} {1}", 
                _appointment.IsLocked ? LanguageStrings.Yes : Languages.LanguageStrings.No, 
                _appointment.IsLocked ? String.Format(LanguageStrings.AppDiaryApptLockedBy, _appointment.LockedByName) : String.Empty));
        }

        protected string GetApptNotes()
        {
            return (LibUtils.PreProcessPost(_appointment.Notes));
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (!pCancelReason.Visible)
            {
                pCancelReason.Visible = true;
            }
            else
            {
                if (txtCancelReason.Text.Length < 10)
                {
                    lblError.Text = "Please enter a valid reason for cancelling your appointment";
                    lblError.Visible = true;
                }
                else
                {
                    TimeSpan span = _appointment.AppointmentAsDateTime() - DateTime.Now;

                    switch (_appointment.Status)
                    {
                        case Library.Enums.AppointmentStatus.Confirmed:

                            if (span.TotalHours > 48)
                            {
                                Global.SendEMail("Heaven Salon", "salon@heavenskincare.com", "Cancelled Appointment",
                                    String.Format("{0}<br /> has been cancelled by the user online<br /><br />Reason:<br />{1}",
                                    _appointment.ToString(), txtCancelReason.Text));

                                _appointment.Notes = txtCancelReason.Text;
                                _appointment.Status = Library.Enums.AppointmentStatus.CancelledByStaff;
                                _appointment.Save(GetUser());
                            }

                            break;
                        case Library.Enums.AppointmentStatus.Requested:
                            if (span.TotalHours > 48)
                            {
                                Global.SendEMail("Heaven Salon", "salon@heavenskincare.com", "Cancelled Appointment",
                                    String.Format("{0}<br /> has been cancelled by the user online<br /><br />Reason:<br />{1}",
                                    _appointment.ToString(), txtCancelReason.Text));
                                Global.SendEMail("web master", "web.master@heavenskincare.com", "Cancelled Appointment",
                                    String.Format("{0}<br /> has been cancelled by the user online<br /><br />Reason:<br />{1}",
                                    _appointment.ToString(), txtCancelReason.Text));

                                _appointment.Notes = txtCancelReason.Text;
                                _appointment.Status = Library.Enums.AppointmentStatus.CancelledByStaff;
                                _appointment.Save(GetUser());
                            }

                            break;
                    }

                    DoRedirect(String.Format("/Account/Appointments/View/{0}/", _appointment.ID));
                }
            }
        }

    }
}