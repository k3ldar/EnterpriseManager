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
    public partial class MailLists : BaseWebForm
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
                CustomPage customPage = CustomPages.Get("Mail List - Subscribe");

                if (customPage != null && customPage.IsActive)
                    divCustomContents.InnerHtml = customPage.PageText;
            }
        }

        protected void MailListSubscribe1_OnSubscribed(object sender, EventArgs e)
        {
            if (Library.BOL.CustomWebPages.CustomPages.UseCustomPages)
            {
                CustomPage customPage = CustomPages.Get("Mail List - Subscribed");

                if (customPage != null && customPage.IsActive)
                    divCustomContents.InnerHtml = customPage.PageText;
            }
            else
                divCustomContents.InnerHtml = String.Format("<p>{0}</p>", Languages.LanguageStrings.MailListSubscribed);

            MailListSubscribe1.Visible = false;

            try
            {
                if (!String.IsNullOrEmpty(Global.MailChimpAPI))
                {
#warning Need to integrate Mail Chimp Here

                    //wrapper.SubscriberAdd(Global.MailChimpList, MailListSubscribe1.Email);
                }
            }
            catch (Exception err)
            {
                Global.SendEmail(err.Message);
            }
        }
    }
}