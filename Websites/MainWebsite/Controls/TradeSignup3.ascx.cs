using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Countries;
using Library.Utils;
using Library.BOL.Users;

namespace Heavenskincare.WebsiteTemplate.Controls
{
    public partial class TradeSignup3 : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnNext.Text = Languages.LanguageStrings.Submit;
            lblError.Visible = false;
        }

        protected void btnNext_Click(object sender, System.EventArgs e)
        {
            try
            {
                ValidateDetails(HSCUtils.ReplaceHTMLElements(txtClients.Text), 0, Languages.LanguageStrings.TradeSignupPage3A);
                ValidateDetails(HSCUtils.ReplaceHTMLElements(txtTreatments.Text), 0, Languages.LanguageStrings.TradeSignupPage3B);
                ValidateDetails(HSCUtils.ReplaceHTMLElements(txtProductsUse.Text), 0, Languages.LanguageStrings.TradeSignupPage3C);
                RaiseNextPage(3);
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

            Result += String.Format("How many clients do you treat: {0}<br />", txtClients.Text);
            Result += String.Format("What Products do you currently use:<br /> <p>{0}</p>", txtProductsUse.Text.Replace("\r", "<br />"));
            Result += String.Format("Which Heaven Treatments are you interested in:<br /> <p>{0}</p>", txtTreatments.Text.Replace("\r", "<br />"));
            Result += String.Format("Any other information:<br /> <p>{0}</p>", txtFurther.Text.Replace("\r", "<br />"));

            return (Result);
        }

    }
}