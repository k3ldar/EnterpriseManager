using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Heavenskincare.WebsiteTemplate;
using Website.Library.Classes;
using Library.Utils;
using Library.BOL.Users;

namespace Heavenskincare.WebsiteTemplate.Members
{
    public partial class Invoices : BaseWebFormMember
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.MyInvoices;
            LeftContainerControl1.SubOptions = GetAccountOptions();
        }
    }
}