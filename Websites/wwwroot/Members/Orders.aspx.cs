using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.Utils;
using Library.BOL.Users;

namespace SieraDelta.Website.Members
{
    public partial class Orders : BaseWebFormMember
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.MyAccount;
            LeftContainerControl1.SubOptions = GetAccountOptions();
        }

        protected int GetOrderPage()
        {
            return (SharedUtils.StrToIntDef((string)Page.RouteData.Values["page"], 1));
        }
    }
}