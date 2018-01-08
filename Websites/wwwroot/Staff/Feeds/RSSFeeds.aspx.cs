using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library.Utils;
using Website.Library.Classes;

namespace SieraDelta.Website.WebsiteFeeds
{
    public partial class RSSFeeds : BaseWebFormStaff
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rssFeeds.InnerHtml += String.Format("<a href=\"/Staff/SalesLead/RSSNotes.aspx?UserID={0}&Email={1}\">Client Notes</a><br />", GetUser().ID, GetUser().Email);
            rssFeeds.InnerHtml += String.Format("<a href=\"/Staff/SalesLead/RSSVisits.aspx?UserID={0}&Email={1}\">Visits</a><br />", GetUser().ID, GetUser().Email);
            rssFeeds.InnerHtml += String.Format("<a href=\"/Staff/SalesLead/RSSTelephone.aspx?UserID={0}&Email={1}\">Telephone Calls</a><br />", GetUser().ID, GetUser().Email);
            rssFeeds.InnerHtml += String.Format("<a href=\"/Staff/SalesLead/RSSNewSignups.aspx?UserID={0}&Email={1}\">New Signups</a><br />", GetUser().ID, GetUser().Email);
        }
    }
}