using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SieraDelta.Website.Library.Classes;
using SieraDelta.Library.Utils;
using SieraDelta.Library.BOL.Therapists;
using SieraDelta.Library.BOL.Appointments;

namespace SieraDelta.WebsiteTemplate.Website.Appointments.Controls
{
    public partial class Step2 : BaseControlClass
    {
        #region Private Members

        private AppointmentTreatments _treatments;

        #endregion Private Members

        protected void Page_Load(object sender, EventArgs e)
        {
            btnNext.Text = SieraDelta.Languages.LanguageStrings.Next;

            lblError.Visible = false;

            if (!IsPostBack)
            {
                calDate.SelectedDate = NextWorkingDay(2);
                LoadStartTimes();
            }
        }

        private DateTime NextWorkingDay(int offset)
        {
            DateTime Result = DateTime.Now.Date.AddDays(1 + offset);

            if (Result.DayOfWeek == DayOfWeek.Sunday)
                Result = Result.AddDays(1);

            return (Result);
        }

        private void LoadTherapists()
        {
            lstTherapist.Items.Clear();
            Therapists therapists = Therapists.Get();

            lstTherapist.Items.Add(new ListItem(SieraDelta.Languages.LanguageStrings.AnyTherapist, "-1"));

            foreach (Therapist ther in therapists)
            {
                if (ther.HasTreatments && ther.PublicDiary)
                {
                    if (ther.CompareTreatments(_treatments))
                    {
                        ListItem item = new ListItem(ther.EmployeeName, ther.EmployeeID.ToString());
                        lstTherapist.Items.Add(item);
                    }
                }
            }
        }

        private void LoadStartTimes()
        {
            HSCUtils u = new HSCUtils();
            lstStartTime.Items.Clear();

            for (Double t = 9.0; t <= 18.00; t = t + 0.25)
            {
                ListItem item = new ListItem(u.DoubleToTime(t));
                lstStartTime.Items.Add(item);
            }

        }

        #region Events

        public event EventHandler OnNext;

        #endregion Events

        #region Properties

        /// <summary>
        /// Sets the treatments that the user selected
        /// </summary>
        public AppointmentTreatments Treatments
        {
            set
            {
                _treatments = value;

                LoadTherapists();
            }
        }

        /// <summary>
        /// Returns selected therapists
        /// </summary>
        public Therapists Therapists
        {
            get
            {
                Therapists therapists = new Therapists();

                if (lstTherapist.SelectedValue == "-1")
                {
                    foreach (ListItem item in lstTherapist.Items)
                    {
                        if (item.Value != "-1")
                        {
                            therapists.Add(Therapist.Get(Convert.ToInt64(item.Value)));
                        }
                    }
                }
                else
                {
                    therapists.Add(Therapist.Get(Convert.ToInt64(lstTherapist.SelectedValue)));
                }

                return (therapists);
            }
        }

        public DateTime SelectedDate
        {
            get
            {
                return (calDate.SelectedDate);
            }
        }

        public double SelectedTime
        {
            get
            {
                HSCUtils u = new HSCUtils();
                return (u.TimeToDouble(lstStartTime.SelectedValue));
            }
        }

        public string Notes
        {
            get
            {
                return (txtNotes.Text);
            }
        }

        #endregion Properties

        protected void calDate_SelectionChanged(object sender, EventArgs e)
        {
            if (calDate.SelectedDate.Date < DateTime.Now.AddDays(1).Date || calDate.SelectedDate.DayOfWeek == DayOfWeek.Sunday)
            {
                calDate.SelectedDate = NextWorkingDay(2);
                lblError.Visible = true;
                lblError.Text = SieraDelta.Languages.LanguageStrings.UnableBookCurrentPast;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (OnNext != null)
                OnNext(this, EventArgs.Empty);
        }
    }
}