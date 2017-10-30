using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library;
using Library.Utils;
using Library.BOL.MailList;

using Heavenskincare.WebsiteTemplate.Controls;

namespace Heavenskincare.WebsiteTemplate.Staff.Admin
{
    public partial class SubScribers : BaseWebFormAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> subscribers = MailLists.Subscribers();

            foreach (KeyValuePair<string, string> item in subscribers)
            {
                divOptions.InnerHtml += String.Format("<p>{0} - {1}</p>\r\n", item.Value, item.Key);
            }
        }
    }
}