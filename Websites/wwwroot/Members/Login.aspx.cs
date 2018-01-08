using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;

namespace SieraDelta.Website.Members
{
    public partial class Login : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MemberLogin1.AfterLogin += new SieraDelta.Website.Members.Controls.MemberLogin.AfterLoginArgs(MemberLogin1_AfterLogin);
        }

        private void MemberLogin1_AfterLogin(object sender, EventArgs e)
        {
            string url = GetFormValue("Redirect", "/Members/Index.aspx");
            DoRedirect(url, true);
        }
    }
}