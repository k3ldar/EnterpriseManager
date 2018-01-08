using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Countries;
using Library.Utils;
using Library.BOL.Users;

namespace SieraDelta.Website.Members.Controls
{
    public partial class ProfileSpecialOffers : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnUpdateSpecialOffers.Text = Languages.LanguageStrings.Submit;
            lblError.Visible = false;

            if (!IsPostBack)
            {
                User user = GetUser();
                cbEmailOffers.Checked = user.OffersEmail;
                cbPostalOffers.Checked = user.OffersPost;
                cbTelephoneOffers.Checked = user.OffersTelephone;
            }
        }

        protected void btnUpdateSpecialOffers_Click(object sender, System.EventArgs e)
        {
            try
            {
                User user = GetUser();
                user.OffersTelephone = cbTelephoneOffers.Checked;
                user.OffersPost = cbPostalOffers.Checked;
                user.OffersEmail = cbEmailOffers.Checked;
                user.Save();
                DoRedirect("/Members/Index.aspx?profileUpdated=true", true);
            }
            catch (System.Exception Err)
            {
                lblError.Visible = true;
                lblError.Text = Err.Message;
            }
        }
    }
}