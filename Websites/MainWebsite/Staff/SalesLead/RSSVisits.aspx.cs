using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Xml;

using Library;
using Library.Utils;
using Library.BOL.RSS;
using Library.BOL.Users;
using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.SalesLead
{
    public partial class RSSVisits : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            int userID = GetFormValue("UserID", -1);

            Library.BOL.Users.User user = Library.BOL.Users.User.UserGet(userID);

            if (user != null)
            {
                if (user.Email == GetFormValue("Email"))// && user.Password == HSCUtils.Decrypt(HttpUtility.UrlDecode(GetFormValue("Password"))))
                {
                    // Clear any previous output from the buffer
                    Response.Clear();
                    Response.ContentType = "text/xml";
                    XmlTextWriter feedWriter
                      = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);

                    feedWriter.WriteStartDocument();

                    // These are RSS Tags
                    feedWriter.WriteStartElement("rss");
                    feedWriter.WriteAttributeString("version", "2.0");

                    feedWriter.WriteStartElement("channel");
                    feedWriter.WriteElementString("title", "Visits");
                    feedWriter.WriteElementString("link", String.Format("http://staff.heavenskincare.com/SalesLead/RSSVisits.aspx?UserID={0}&Email={1}", user.ID, user.Email));
                    feedWriter.WriteElementString("description", "Sales Leads Visits");
                    feedWriter.WriteElementString("copyright", "Copyright (c) 2012 Heavenskincare.com. All rights reserved.");

                    // Get list of 20 most recent posts
                    RSSFeed rssFeed = RSSFeed.Get(Enums.RSSFeedType.Visits);

                    // Write all Posts in the rss feed
                    foreach (RSSItem item in rssFeed)
                    {
                        feedWriter.WriteStartElement("item");
                        feedWriter.WriteElementString("title", item.Title);
                        feedWriter.WriteElementString("description", item.Description);
                        feedWriter.WriteElementString("link", item.Link);
                        feedWriter.WriteElementString("pubDate", item.PublishedDate.ToString());
                        feedWriter.WriteEndElement();
                    }

                    // Close all open tags tags
                    feedWriter.WriteEndElement();
                    feedWriter.WriteEndElement();
                    feedWriter.WriteEndDocument();
                    feedWriter.Flush();
                    feedWriter.Close();
                    feedWriter = null;
                }
                else
                {
                    Response.Write("Invalid Credentials");
                }
            }
            else
                Response.Write("Invalid Credentials");

            Response.End();
        }
    }
}