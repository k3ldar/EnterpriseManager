using System;

using Website.Library.Classes;

namespace SieraDelta.Website.Members
{
    public partial class DeliveryAddressEdit : BaseWebFormMember
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.DeliveryAddressEdit;
            LeftContainerControl1.SubOptions = GetAccountOptions();
        }

        protected string GetAddressID()
        {
            return ((string)Page.RouteData.Values["id"]);
        }
    }
}