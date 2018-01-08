using System;
using System.Collections.Generic;
using System.Linq;
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

namespace SieraDelta.Website.SalesLead
{
    public partial class RSSNotes : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SieraDeltaUtils u = new SieraDeltaUtils();
            int userID = GetFormValue("UserID", -1);

            Library.BOL.Users.User user = Library.BOL.Users.User.UserGet(userID);

            if (user != null)
            {
                if (user.Email == GetFormValue("Email"))// && user.Password == SharedUtils.Decrypt(HttpUtility.UrlDecode(GetFormValue("Password"))))
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
                    feedWriter.WriteElementString("title", "Client Notes");
                    feedWriter.WriteElementString("link", String.Format("http://staff.SieraDelta.com/SalesLead/RSSNotes.aspx?UserID={0}&Email={1}", user.ID, user.Email));
                    feedWriter.WriteElementString("description", "Sales Leads Client Notes");
                    feedWriter.WriteElementString("copyright",
                      "Copyright (c) 2012 SieraDelta.com. All rights reserved.");

                    // Get list of 20 most recent posts
                    RSSFeed rssFeed = RSSFeed.Get(Enums.RSSFeedType.ClientNotes);

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