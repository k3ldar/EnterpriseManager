using System;
using System.Web.UI.WebControls;

using Website.Library.Classes;

using Shared;

namespace SieraDelta.Website.Members.Controls
{
    public partial class ProfileCreditCard : BaseControlClass
    {
        #region Public Methods

        public Library.BOL.Users.CreditCard GetCardDetails()
        {
            Library.BOL.Users.CreditCard Result = null;

            Result = new Library.BOL.Users.CreditCard(-1, GetUser(), txtCardNumber.Text, 
                txtCardNumber.Text.Substring(txtCardNumber.Text.Length - 4), 
                String.Format("{0}/{1}", ddlFromMonth.SelectedItem, ddlFromYear.SelectedItem),
                String.Format("{0}/{1}", ddlToMonth.SelectedItem, ddlToYear.SelectedItem),
                txtName.Text, txtLast3.Text, Validation.CardType(txtCardNumber.Text));

            return (Result);
        }

        /// <summary>
        /// Indicates the control is being used from in a shopping cart and alters styles, and what
        /// is visible accordingly
        /// </summary>
        public void FromBasket()
        {
            dMain.Attributes.Clear();
            btnSubmit.Visible = false;
            cbStoreDetails.Visible = Global.AllowCreditCards;
            lblStoreDetails.Visible = Global.AllowCreditCards;
            lblError.Attributes.Add("style", "max-width: 290px; word-wrap:normal; width: 280px;color: red;text-align: left;");
        }

        public bool ValidateDetails()
        {
            bool Result = false;

            try
            {
                if (String.IsNullOrEmpty(txtLast3.Text) || txtLast3.Text.Length < 3 || txtLast3.Text.Length > 4)
                    throw new Exception(Languages.LanguageStrings.EnterLast3Digits);

                string cardNum = Validation.Validate(txtCardNumber.Text, ValidationTypes.CreditCard);
                string cardName = Validation.Validate(txtName.Text, ValidationTypes.AlphaNumeric);
                string cardLast3 = Validation.Validate(txtLast3.Text, ValidationTypes.IsNumeric);
                string cardValidFrom = Validation.Validate(String.Format("{0}/{1}", ddlFromMonth.SelectedItem, ddlFromYear.SelectedItem), ValidationTypes.CardValidFrom);
                string cardValidTo = Validation.Validate(String.Format("{0}/{1}", ddlToMonth.SelectedItem, ddlToYear.SelectedItem), ValidationTypes.CardValidTo);

                //validation
                if (!cardName.ToLower().Contains(GetUser().LastName.ToLower()))
                    throw new Exception(Languages.LanguageStrings.SurnameMustMatchCard);

                //validate card type, will throw exception if error
                Validation.CardType(cardNum);

                if (cardLast3.Length != 3)
                    throw new Exception(Languages.LanguageStrings.EnterLast3Digits);


                Library.BOL.Users.CreditCard newCard =
                    new Library.BOL.Users.CreditCard(-1, GetUser(), Library.Utils.StringCipher.Encrypt(cardNum, "Heaven@_13A"), cardNum.Substring(cardNum.Length - 4, 4),
                        cardValidFrom, cardValidTo, txtName.Text, txtLast3.Text, (Shared.AcceptedCreditCardTypes)Convert.ToInt32(ddlCardType.SelectedValue));

                if (cbStoreDetails.Visible && cbStoreDetails.Checked)
                    Library.BOL.Users.CreditCard.Add(newCard, GetUser());

                Result = true;
            }
            catch (Exception err)
            {
                Global.SendEmail(err.Message);
                lblError.Visible = true;
                lblError.InnerText = err.Message;
                Result = false;
            }

            return (Result);
        }

        #endregion Public Methods

        #region Properties

        #endregion Properties

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;

            if (!IsPostBack)
                LoadDetails();

            if (GetUser().CardDetails == null)
                btnSubmit.Text = Languages.LanguageStrings.AddNewCard;
            else
                btnSubmit.Text = Languages.LanguageStrings.UpdateCardDetails;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtLast3.Text))
                    throw new Exception(Languages.LanguageStrings.EnterLast3Digits);

                string cardNum = Validation.Validate(txtCardNumber.Text, ValidationTypes.CreditCard);
                string cardName = Validation.Validate(txtName.Text, ValidationTypes.AlphaNumeric);
                string cardLast3 = Validation.Validate(txtLast3.Text, ValidationTypes.IsNumeric);
                string cardValidFrom = Validation.Validate(String.Format("{0}/{1}", ddlFromMonth.SelectedItem, ddlFromYear.SelectedItem), ValidationTypes.CardValidFrom);
                string cardValidTo = Validation.Validate(String.Format("{0}/{1}", ddlToMonth.SelectedItem, ddlToYear.SelectedItem), ValidationTypes.CardValidTo);

                //validation
                if (!cardName.ToLower().Contains(GetUser().LastName.ToLower()))
                    throw new Exception(Languages.LanguageStrings.SurnameMustMatchCard);

                //validate card type, will throw exception if error
                Validation.CardType(cardNum);

                if (cardLast3.Length != 3)
                    throw new Exception(Languages.LanguageStrings.EnterLast3Digits);
                

                Library.BOL.Users.CreditCard newCard =
                    new Library.BOL.Users.CreditCard(-1, GetUser(), Library.Utils.StringCipher.Encrypt(cardNum, "Heaven@_13A"), cardNum.Substring(cardNum.Length - 4, 4),
                        cardValidFrom, cardValidTo, txtName.Text, txtLast3.Text, (Shared.AcceptedCreditCardTypes)Convert.ToInt32(ddlCardType.SelectedValue));

                Library.BOL.Users.CreditCard.Add(newCard, GetUser());
                DoRedirect("/Account/?profileUpdated=true", true);
            }
            catch (Exception err)
            {
                Global.SendEmail(err.Message);
                lblError.Visible = true;
                lblError.InnerText = err.Message;
            }
        }

        #endregion Protected Methods

        #region Private Methods

        private void LoadDetails()
        {
            //accepted card types
            ddlCardType.Items.Add(new ListItem("Visa", "1"));
            ddlCardType.Items.Add(new ListItem("MasterCard", "2"));
            ddlCardType.Items.Add(new ListItem("VisaDebit", "3"));
            ddlCardType.SelectedIndex = 2;

            //valid from
            ddlFromMonth.SelectedIndex = 0;

            for (int i = 0; i > -5; i--)
                ddlFromYear.Items.Add(new ListItem(DateTime.Now.AddYears(i).Year.ToString().Substring(2, 2)));

            //valid to
            ddlToMonth.SelectedIndex = 0;

            for (int i = 0; i < 6; i++)
                ddlToYear.Items.Add(new ListItem(DateTime.Now.AddYears(i).Year.ToString().Substring(2, 2)));
        }

        #endregion Private Methods
    }
}