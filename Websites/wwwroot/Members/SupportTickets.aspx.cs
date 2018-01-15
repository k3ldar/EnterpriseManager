using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library.Utils;
using Website.Library.Classes;

namespace SieraDelta.Website.Members
{
    public partial class SupportTickets : BaseWebFormMember
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.MyAccount;
            LeftContainerControl1.SubOptions = GetAccountOptions();
        }

        protected int GetSupportTicketPage()
        {
            return (SharedUtils.StrToIntDef((string)Page.RouteData.Values["page"], 1));
        }
    }
}