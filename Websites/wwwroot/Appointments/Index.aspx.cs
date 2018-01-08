using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SieraDelta.Website.Library.Classes;

using SieraDelta.Library.BOL.Users;

namespace SieraDelta.WebsiteTemplate.Website.Appointments
{
    public partial class Index : BaseWebFormMember
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Global.AllowSalonBookings)
            {
                NotAllowed1.Visible = true;
                Terms1.Visible = false;
                PreConditions1.Visible = false;
                Step11.Visible = false;
                Step21.Visible = false;
                Step31.Visible = false;
                return;
            }

            if (!IsPostBack)
            {
                User user = GetUser();

                if (user.History.CancelledOrNoShow())
                {
                    NotAllowed1.Visible = true;
                    Terms1.Visible = false;
                    PreConditions1.Visible = false;
                    Step11.Visible = false;
                    Step21.Visible = false;
                    Step31.Visible = false;
                }
                else
                {
                    Terms1.Visible = true;
                    PreConditions1.Visible = false;
                    Step11.Visible = false;
                    Step21.Visible = false;
                    Step31.Visible = false;
                    NotAllowed1.Visible = false;
                }
            }

            Terms1.OnNext += new EventHandler(Terms1_OnNext);
            PreConditions1.OnNext += new EventHandler(PreConditions1_OnNext);
            Step11.OnNext += new EventHandler(Step11_OnNext);
            Step21.OnNext += new EventHandler(Step21_OnNext);
            Step31.TryAgain += new EventHandler(Step31_TryAgain);

            if (Step31.Visible)
            {
                Step31.Treatments = Step11.Selected;
                Step31.Therapists = Step21.Therapists;
                Step31.StartTime = Step21.SelectedTime;
                Step31.Date = Step21.SelectedDate;
                Step31.Notes = Step21.Notes;
            }
        }

        void PreConditions1_OnNext(object sender, EventArgs e)
        {
            PreConditions1.Visible = false;
            Step11.Visible = true;
        }

        void Terms1_OnNext(object sender, EventArgs e)
        {
            Terms1.Visible = false;
            PreConditions1.Visible = true;
            PreConditions1.Loading();
        }

        void Step31_TryAgain(object sender, EventArgs e)
        {
            DateTime nextDate = (DateTime)Session["SELECTED_DATE"];
            nextDate = nextDate.AddDays(1);
            Session["SELECTED_DATE"] = nextDate;
            Step31.Treatments = Step11.Selected;
            Step31.Therapists = Step21.Therapists;
            Step31.StartTime = Step21.SelectedTime;
            Step31.Date = nextDate;
            Step31.FindAppointment();
        }

        void Step21_OnNext(object sender, EventArgs e)
        {
            Step21.Visible = false;
            Step31.Visible = true;
            Step31.Treatments = Step11.Selected;
            Step31.Therapists = Step21.Therapists;
            Step31.StartTime = Step21.SelectedTime;
            Step31.Date = Step21.SelectedDate;
            Session["SELECTED_DATE"] = Step21.SelectedDate;
            Step31.FindAppointment();
        }

        void Step11_OnNext(object sender, EventArgs e)
        {
            Step11.Visible = false;
            Step21.Treatments = Step11.Selected;
            Step21.Visible = true;
        }
    }
}