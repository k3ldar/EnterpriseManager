using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;

namespace SieraDelta.Website.Members
{
    public partial class Logout : BaseWebFormMember
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.MyAccount;
            LeftContainerControl1.SubOptions = GetAccountOptions();
        }
    }
}