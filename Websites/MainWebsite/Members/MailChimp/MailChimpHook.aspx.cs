using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Heavenskincare.WebsiteTemplate.Members.MailChimp
{
    public partial class MailChimpHook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["type"] != null && (Request.Form["type"] == "unsubscribe") ||
                (Request.Form["type"] == "subscribe"))
            {
                try
                {
                    string email = Request.Form["data[merges][EMAIL]"];
                    //now you can do insert/update data in your local database

                    if (Request.Form["type"] == "subscribe")
                        Library.BOL.MailList.MailLists.Subscribe(email, email);
                    else if (Request.Form["type"] == "unsubscribe")
                        Library.BOL.MailList.MailLists.UnSubscribe(email, "sent from MailChimp");
                    else
                        Global.SendEmail("Invalid Email Settings", Request.Form.AllKeys.ToString());
                }
                catch (Exception error)
                {
                    if (!error.Message.Contains("UNQ_WS_MAIL_SUBSCRIBERS_EMAIL"))
                        throw;
                }

            }
        }
    }
}