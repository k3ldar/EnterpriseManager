using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Countries;
using Library.Utils;
using Library.BOL.Users;

namespace Heavenskincare.WebsiteTemplate.Members.Controls
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


                try
                {
                    if (!String.IsNullOrEmpty(Global.MailChimpAPI))
                    {
#warning Need to integrate Mail Chimp Here
                        //if (cbEmailOffers.Checked)
                        //    wrapper.SubscriberAdd(Global.MailChimpList, user.Email);
                        //else
                        //    wrapper.SubscriberRemove(Global.MailChimpList, user.Email);
                    }
                }
                catch (Exception err)
                {
                    Global.SendEmail(err.Message);
                }

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