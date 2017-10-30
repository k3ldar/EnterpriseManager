using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library.BOL.Users;
using Library.Utils;
using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Members
{
    public partial class MemberDetails : BaseWebFormMember
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.DeliveryAddressEdit;
            LeftContainerControl1.SubOptions = GetAccountOptions();
        }
    }
}