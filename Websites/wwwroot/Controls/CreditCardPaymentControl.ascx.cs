using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Users;
using Library;
using Library.Utils;

namespace SieraDelta.Website.Controls
{
    public partial class CreditCardPaymentControl : BaseControlClass
    {
        #region Private / Protected Members

        private Library.BOL.Users.CreditCard _cardDetails;

        #endregion Private / Protected Members

        protected void Page_Load(object sender, EventArgs e)
        {
            _cardDetails = GetUser().CardDetails;

            if (_cardDetails == null)
            {
                pCurrentSelection.Visible = false;
                pCurrentSelection.Visible = false;
                hCurrent.Visible = false;
                rbNew.Visible = false;
                rbNew.Checked = true;
                //pCurrentDetails.InnerText = Languages.LanguageStrings.CreditCardNotHeld;
                pUseNewSelection.Visible = false;
                //pDeleteDetails.Visible = false;
            }
            else
            {
                pCurrentDetails.InnerHtml = String.Format("<b>{3}</b>: {0}<br /><b>{4}</b>: XXXX-XXXX-XXXX-{1}<br /><b>{5}</b>: {2}",
                    _cardDetails.CardName, _cardDetails.Last4Digits, _cardDetails.ValidTo,
                    Languages.LanguageStrings.NameOnCard,
                    Languages.LanguageStrings.CardNumber,
                    Languages.LanguageStrings.Expires);
                //pDeleteDetails.Visible = true;
            }

            ProfileCreditCard1.FromBasket();
        }

        #region Public Methods

        /// <summary>
        /// Retrieves the current credit card details
        /// </summary>
        /// <returns></returns>
        public CreditCard GetCardDetails()
        {
            CreditCard Result = null;

            if (rbNew.Checked)
            {
                Result = ProfileCreditCard1.GetCardDetails();
            }
            else
            {
                Result = GetUser().CardDetails;
            }

            return (Result);
        }

        /// <summary>
        /// Validates new credit card details, if existing card then it has already been validated
        /// </summary>
        /// <returns>returns true if the credit card is existing or validates, otherwise returns false</returns>
        public bool ValidateNewCard()
        {
            bool Result = false;

            if (rbNew.Checked)
            {
                Result = ProfileCreditCard1.ValidateDetails();
            }
            else
            {
                Result = true; // previously validated
            }

            return (Result);
        }

        #endregion Public Methods
    }
}