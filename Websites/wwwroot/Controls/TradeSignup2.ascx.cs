using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Countries;
using Library.Utils;
using Library.BOL.Users;

namespace SieraDelta.Website.Controls.Controls
{
    public partial class TradeSignup2 : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnNext.Text = Languages.LanguageStrings.Next;
            lblError.Visible = false;
        }

        protected void btnNext_Click(object sender, System.EventArgs e)
        {
            try
            {
                    ValidateDetails(SharedUtils.ReplaceHTMLElements(txtRooms.Text), 0, Languages.LanguageStrings.TradeSignupPage2A);
                    ValidateDetails(SharedUtils.ReplaceHTMLElements(txtHear.Text), 0, Languages.LanguageStrings.TradeSignupPage2B);
                    ValidateDetails(SharedUtils.ReplaceHTMLElements(txtSpecialise.Text), 0, Languages.LanguageStrings.TradeSignupPage2C);
                    ValidateDetails(SharedUtils.ReplaceHTMLElements(txtRooms.Text), 0, Languages.LanguageStrings.TradeSignupPage2D);
                    ValidateDetails(SharedUtils.ReplaceHTMLElements(txtTherapists.Text), 0, Languages.LanguageStrings.TradeSignupPage2E);
                    ValidateDetails(SharedUtils.ReplaceHTMLElements(txtTrading.Text), 0, Languages.LanguageStrings.TradeSignupPage2F);
                    ValidateDetails(SharedUtils.ReplaceHTMLElements(txtTreatments.Text), 0, Languages.LanguageStrings.TradeSignupPage2G);
                    RaiseNextPage(2);
            }
            catch (System.Exception Err)
            {
                lblError.Visible = true;
                lblError.Text = Err.Message;
            }
        }


        #region Private Methods

        private void RaiseNextPage(int Page)
        {
            if (OnNextPage != null)
                OnNextPage(this, new NextPageArgs(Page));
        }

        #endregion Private Methods

        #region Delegates



        #endregion Delegates

        #region Events

        public event WizardNextPageDelegate OnNextPage;


        #endregion Events

        public string GetData()
        {
            string Result = "";

            Result += String.Format("No of Rooms: {0}<br />", txtRooms.Text);
            Result += String.Format("Why interested in Heaven products: {0}<br />", txtInterested.Text);
            Result += String.Format("Heard about Heaven: {0}<br />", txtHear.Text);
            Result += String.Format("What business do you specialise in: {0}<br />", txtSpecialise.Text);
            Result += String.Format("How long have you been trading: {0}<br />", txtTrading.Text);
            Result += String.Format("How many therapists work for you: {0}<br />", txtTherapists.Text);
            Result += String.Format("What treatments do you offer:<br /> <p>{0}</p>", txtTreatments.Text.Replace("\r", "<br />"));

            return (Result);
        }

    }
}