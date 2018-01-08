using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Website.Library.Classes;
using Library;
using Library.Utils;
using Library.BOL.Appointments;

namespace SieraDelta.Website.Members.Controls
{
    public partial class ProfileAppointments : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BuildAppointments();
        }

        private void BuildAppointments()
        {
            //SieraDeltaUtils u = new SieraDeltaUtils();

            int page = GetFormValue("Page", 1);
            foreach (Appointment appt in Library.BOL.Appointments.Appointments.Get(GetUser(), page, 10))
            {
                HtmlTableRow r = new HtmlTableRow();
                tblAppointments.Rows.Add(r);

                HtmlTableCell cApptDate = new HtmlTableCell();
                cApptDate.InnerText = SharedUtils.DateTimeToStr(appt.AppointmentAsDateTime(), WebCulture);
                r.Cells.Add(cApptDate);

                HtmlTableCell cTreatment = new HtmlTableCell();
                r.Cells.Add(cTreatment);
                cTreatment.InnerText = appt.TreatmentName;

                HtmlTableCell cStatus = new HtmlTableCell();
                r.Cells.Add(cStatus);
                cStatus.InnerText = SharedUtils.SplitCamelCase(appt.Status.ToString());

                HtmlTableCell cLink = new HtmlTableCell();
                r.Cells.Add(cLink);
                cLink.InnerHtml = String.Format("<a href=\"/Members/ViewSalonAppointment.aspx?id={0}\">{1}</a>", appt.ID, Languages.LanguageStrings.View);
            }
        }

    }
}