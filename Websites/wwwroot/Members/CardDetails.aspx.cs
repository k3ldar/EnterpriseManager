using System;

using Library.BOL.Websites;

using Website.Library.Classes;

#pragma warning disable IDE1006

namespace SieraDelta.Website.Members
{
    public partial class CreditCard : BaseWebFormMember
    {
        Library.BOL.Users.CreditCard _cardDetails;
            
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!WebsiteSettings.CreditCards.AllowCreditCards)
                DoRedirect("/Site-Error/Invalid-Permission/");

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
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            _cardDetails.Delete();
            DoRedirect("/Account/Card/");
        }
    }
}