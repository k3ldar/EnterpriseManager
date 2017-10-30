using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library.BOL.CustomWebPages;
using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Offers
{
    public partial class Unsubscribe : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Global.AllowMailListSubscribers)
            {
                DoRedirect("/Index.aspx", true);
            }

            LeftContainerControl1.HideSubscription = true;

            if (Library.BOL.CustomWebPages.CustomPages.UseCustomPages)
            {
                CustomPage customPage = CustomPages.Get("Mail List - Unsubscribe");

                if (customPage != null && customPage.IsActive)
                    divCustomContents.InnerHtml = customPage.PageText;
            }
        }

        protected void MailListUnsubscribe1_OnUnsubscribe(object sender, EventArgs e)
        {
            if (Library.BOL.CustomWebPages.CustomPages.UseCustomPages)
            {
                CustomPage customPage = CustomPages.Get("Mail List - Unsubscribe Success");

                if (customPage != null && customPage.IsActive)
                    divCustomContents.InnerHtml = customPage.PageText;
            }
            else
                divCustomContents.InnerHtml = String.Format("<p>{0}</p>", Languages.LanguageStrings.MailListUnsubscribed);

            MailListUnsubscribe1.Visible = false;

            try
            {
                if (!String.IsNullOrEmpty(Global.MailChimpAPI))
                {
#warning Need to integrate Mail Chimp Here
                    //string listID = wrapper.ListIdGet(Global.MailChimpList);

                    //wrapper.SubscriberRemove(Global.MailChimpList, MailListUnsubscribe1.Email);
                }
            }
            catch (Exception err)
            {
                Global.SendEmail(err.Message);
            }

        }

        protected void MailListUnsubscribe1_OnUnsubscribeFailed(object sender, EventArgs e)
        {
            if (Library.BOL.CustomWebPages.CustomPages.UseCustomPages)
            {
                CustomPage customPage = CustomPages.Get("Mail List - Unsubscribe Fail");

                if (customPage != null && customPage.IsActive)
                    divCustomContents.InnerHtml = customPage.PageText;
            }
            else
                divCustomContents.InnerHtml = String.Format("<p>{0}</p>", Languages.LanguageStrings.MailListUnsubscribeFail);

            MailListUnsubscribe1.Visible = true;
        }
    }
}