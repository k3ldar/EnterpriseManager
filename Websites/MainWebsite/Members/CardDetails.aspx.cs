using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.CustomWebPages;

namespace Heavenskincare.WebsiteTemplate.Members
{
    public partial class CreditCard : BaseWebFormMember
    {
        Library.BOL.Users.CreditCard _cardDetails;
            
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Global.AllowCreditCards)
                DoRedirect("/Error/InvalidPermissions.aspx");

            btnRemove.Text = Languages.LanguageStrings.RemoveCardDetails;
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.MyAccount;
            LeftContainerControl1.SubOptions = GetAccountOptions();
            _cardDetails = GetUser().CardDetails;

            if (_cardDetails == null)
            {
                pCurrentDetails.InnerText = Languages.LanguageStrings.CreditCardNotHeld;
                pDeleteDetails.Visible = false;
            }
            else
            {
                pCurrentDetails.InnerHtml = String.Format("<b>{3}</b>: {0}<br /><b>{4}</b>: XXXX-XXXX-XXXX-{1}<br /><b>{5}</b>: {2}",
                    _cardDetails.CardName, _cardDetails.Last4Digits, _cardDetails.ValidTo,
                    Languages.LanguageStrings.NameOnCard,
                    Languages.LanguageStrings.CardNumber,
                    Languages.LanguageStrings.Expires);
                pDeleteDetails.Visible = true;
            }

            if (Library.BOL.CustomWebPages.CustomPages.UseCustomPages)
            {
                CustomPage customPage = CustomPages.Get("Members - Credit Card Details");

                if (customPage != null && customPage.IsActive)
                    divCustomContents.InnerHtml = customPage.PageText;
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            if (_cardDetails == null)
                _cardDetails = GetUser().CardDetails;

            _cardDetails.Delete();
            DoRedirect("/Members/CardDetails.aspx");
        }
    }
}