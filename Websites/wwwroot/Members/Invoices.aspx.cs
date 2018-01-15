using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SieraDelta.Website;
using Website.Library.Classes;
using Library.Utils;
using Library.BOL.Users;

namespace SieraDelta.Website.Members
{
    public partial class Invoices : BaseWebFormMember
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.MyInvoices;
            LeftContainerControl1.SubOptions = GetAccountOptions();
        }

        protected int GetInvoicePage()
        {
            return (SharedUtils.StrToIntDef((string)Page.RouteData.Values["page"], 1));
        }
    }
}