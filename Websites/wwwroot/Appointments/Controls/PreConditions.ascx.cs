using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SieraDelta.Website.Library.Classes;
using SieraDelta.Library.BOL.Users;

namespace SieraDelta.WebsiteTemplate.Website.Appointments.Controls
{
    public partial class PreConditions : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnNext.Text = SieraDelta.Languages.LanguageStrings.Next;
        }

        public void Loading()
        {
            User user = GetUser();

            if (user == null)
                DoRedirect("/members/Login.apx?redirect=/appointments/Index.aspx", true);

            if (!String.IsNullOrEmpty(user.Telephone) && user.CardDetails != null)
                if (OnNext != null)
                    OnNext(this, EventArgs.Empty);
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            DoRedirect("/members/CardDetails.aspx?redirect=/appointments/Index.aspx");
        }

        #region Events

        public event EventHandler OnNext;

        #endregion Events


    }
}