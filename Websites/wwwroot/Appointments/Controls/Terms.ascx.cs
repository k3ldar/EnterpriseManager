using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SieraDelta.WebsiteTemplate.Website.Appointments.Controls
{
    public partial class Terms : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnConfrim.Text = SieraDelta.Languages.LanguageStrings.AcceptTermsAndConditions;
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