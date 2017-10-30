using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.Utils;
using Library.BOL.Therapists;
using Library.BOL.Appointments;

namespace Heavenskincare.WebsiteTemplate.Appointments.Controls
{
    public partial class Step1 : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;

            if (!IsPostBack)
            {
                LoadTreatments();
            }

            btnNext.Text = Languages.LanguageStrings.Next;
        }

        private void LoadTreatments()
        {
            lstTreatments.Items.Clear();
            AppointmentTreatments treats = AppointmentTreatments.Get();

            foreach (AppointmentTreatment treat in treats)
            {
                if (treat.IsActive && !treat.RequireFollowOn)
                {
                    ListItem item = new ListItem(treat.Name, treat.ID.ToString());
                    lstTreatments.Items.Add(item);
                }
            }
        }

        public AppointmentTreatments Selected
        {
            get
            {
                AppointmentTreatments Result = new AppointmentTreatments();

                foreach (ListItem item in lstTreatments.Items)
                {
                    if (item.Selected)
                    {
                        AppointmentTreatment treat = AppointmentTreatments.Get(Convert.ToInt32(item.Value));
                        Result.Add(treat);
                    }
                }

                return (Result);
            }
        }


        #region Events

        public event EventHandler OnNext;

        #endregion Events

        protected void btnNext_Click(object sender, EventArgs e)
        {
            int selCount = 0;

            foreach (ListItem item in lstTreatments.Items)
            {
                if (item.Selected)
                    selCount++;
            }

            if (selCount == 0)
            {
                lblError.Visible = true;
                lblError.Text = Languages.LanguageStrings.SelectAtLeast1Treatment;
                return;
            }

            if (selCount > 3)
            {
                lblError.Visible = true;
                lblError.Text = Languages.LanguageStrings.SelectAMaximumOf3Treatments;
                return;
            }

            if (OnNext != null)
                OnNext(this, EventArgs.Empty);
        }

    }
}