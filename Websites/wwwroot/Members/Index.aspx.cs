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
    public partial class Index : BaseWebFormMember
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.MyAccount;
            LeftContainerControl1.SubOptions = GetAccountOptions();


            divUpdated.Visible = GetFormValue("profileUpdated", String.Empty).ToUpper() == "TRUE";
        }

        protected override string GetAccountOptions()
        {
            string Result = base.GetAccountOptions();

            return (Result);
        }
    }
}