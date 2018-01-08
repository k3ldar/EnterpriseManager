using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library;
using Library.Utils;
using Library.BOL.Invoices;

namespace SieraDelta.Website.Admin
{
    public partial class Index : BaseWebFormAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.MyAccount;
            LeftContainerControl1.SubOptions = GetAccountOptions();

            if (GetFormValue("UpdateTags") == "Yes")
                Library.BOL.TagLines.TagLines.Reset();

            DoRedirect("/staff/Statistics/Index.aspx");
        }
    }
}