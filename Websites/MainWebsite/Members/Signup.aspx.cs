using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Members
{
    public partial class Signup : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (GetUser() != null)
                DoRedirect("/Members/Index.aspx", true);

            CreateAccount1.AfterCreateAccount += CreateAccount1_AfterCreateAccount;
        }

        void CreateAccount1_AfterCreateAccount(object sender, Controls.CreateAccount.CreateAccountArgs e)
        {
            if (GetUser() != null)
                DoRedirect("/Members/Index.aspx");
        }
    }
}