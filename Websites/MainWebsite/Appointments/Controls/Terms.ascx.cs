using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library.BOL.CustomWebPages;

namespace Heavenskincare.WebsiteTemplate.Appointments.Controls
{
    public partial class Terms : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnConfrim.Text = Languages.LanguageStrings.AcceptTermsAndConditions;

            if (Library.BOL.CustomWebPages.CustomPages.UseCustomPages)
            {
                CustomPage customPage = CustomPages.Get("Appointment - Terms and Conditions");

                if (customPage != null && customPage.IsActive)
                    divCustomContents.InnerHtml = customPage.PageText;
            }
        }

        #region Events

        public event EventHandler OnNext;

        #endregion Events

        protected void btnConfrim_Click(object sender, EventArgs e)
        {
            if (OnNext != null)
                OnNext(this, EventArgs.Empty);
        }

    }
}