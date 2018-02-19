/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *  Enterprise Manager is distributed under the GNU General Public License version 3 and  
 *  is also available under alternative licenses negotiated directly with Simon Carter.  
 *  If you obtained Enterprise Manager under the GPL, then the GPL applies to all loadable 
 *  Enterprise Manager modules used on your system as well. The GPL (version 3) is 
 *  available at https://opensource.org/licenses/GPL-3.0
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 *  without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 *  See the GNU General Public License for more details.
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: SystemEmail.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using Library.BOL.Invoices;
using Library.BOL.Orders;
using Library.BOL.Products;
using Library.BOL.StockControl;
using Library.BOL.Users;
using Library.BOL.Websites;

namespace Library.BOL.Mail
{
    /// <summary>
    /// System Email Message
    /// </summary>
    [Serializable]
    public sealed class SystemEmail : BaseObject
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        public SystemEmail (Int64 id, string name, string subject, string message, bool allowSend)
        {
            ID = id;
            Name = name;
            Subject = subject;
            Message = message;
            AllowSend = allowSend;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Unique ID of email
        /// </summary>
        public Int64 ID { get; private set; }

        /// <summary>
        /// Unique name of email
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Subject of email
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Message content
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// If true the email can be sent, otherwise the email will not be sent
        /// </summary>
        public bool AllowSend { get; set; }

        #endregion Properties

        #region Public Methods

#if DEBUG
#warning what other replaceable strings are there?

        /*
         Replaceable strings for emails

        [GROUPID] - Announcement Group ID
        [ITEMID] - Announcement ID
        */
#endif

        public string Format(User user, Product product, bool convertToHtml = true)
        {
            string Result = DefaultFormatItems(user, convertToHtml);

            Result = Result.Replace("[PRODUCTID]", product.ID.ToString());

            return (Result);
        }

        public string Format(User user, StockItem stockItem, Product product, bool convertToHtml = true)
        {
            string Result = DefaultFormatItems(user, convertToHtml);

            Result = Result.Replace("[STOCKITEM]", stockItem.ID.ToString());
            Result = Result.Replace("[PRODUCTID]", product.ID.ToString());

            return (Result);
        }

        public string Format(User user, bool convertToHtml = true)
        {
            string Result = DefaultFormatItems(user, convertToHtml);

            Result = Result.Replace("[PASSWORD]", user.Password);

            return (Result);
        }

        public string Format(Invoice invoice, bool convertToHtml = true)
        {
            string Result = DefaultFormatItems(invoice.User, convertToHtml);

            Result = Result.Replace("[INVOICENUMBER]", invoice.ID.ToString());

            return (Result);
        }

        public string Format(Order order, bool convertToHtml = true)
        {
            string Result = DefaultFormatItems(order.User, convertToHtml);

            Result = Result.Replace("[ORDERNUMBER]", order.ID.ToString());

            return (Result);
        }

        /// <summary>
        /// Save's the current system email
        /// </summary>
        public override void Save()
        {
            DAL.FirebirdDB.SystemEmailSave(this);
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Replaces all default items within a mail message and
        /// optionally converts to an html email message
        /// </summary>
        /// <param name="user">User who is receiving the email</param>
        /// <param name="convertToHtml">if true email is converted to html email</param>
        /// <returns>Formatted mail message</returns>
        private string DefaultFormatItems(User user, bool convertToHtml)
        {
            string message = Message;

            message = message.Replace("[COMPANY]", LibraryHelperClass.SettingsGet("POS_BUS_NAME"));

            Website defaultSite = Websites.Websites.Primary();

            if (defaultSite != null)
            {
                message = message.Replace("[URL]", defaultSite.URL);
                message = message.Replace("[CONTACTUS]", "<a href=\"" + defaultSite.URL + "/Contactus.aspx\">");
                message = message.Replace("[CONTACTUS_END]", "</a>");

                message = message.Replace("[ORDERURL]", "<a href=\"" + defaultSite.URL + "/Account/Orders/\">");
                message = message.Replace("[ORDERURLEND]", "</a>");
            }

            message = message.Replace("[ADDRESS]", LibraryHelperClass.SettingsGet("POS_BUS_ADDR"));
            message = message.Replace("[TELEPHONE]", LibraryHelperClass.SettingsGet("POS_BUS_TEL"));

            if (user != null)
            {
                message = message.Replace("[USERNAME]", user.UserName);
                message = message.Replace("[EMAILADDRESS]", user.Email);
                message = message.Replace("[FIRSTNAME]", user.FirstName);
            }

            if (!convertToHtml)
                return (message);
            
            string Result = String.Format("<html><head><link href=\"{0}/styles/email.css\" type=\"text/css\" rel=\"stylesheet\" />" +
                "</head><body bgColor=\"#ffffff\">" +
                "<table cellSpacing=\"0\" cellPadding=\"0\" width=\"100%\" border=\"0\" height=\"100%\"><TR>" +
                "<TD class=\"PageBorderTopLeftCorner\" vAlign=\"top\" align=\"left\" width=\"18\" height=\"17\">&nbsp;</TD>" +
                "<TD class=\"PageBorderTop\" vAlign=\"top\" align=\"left\" height=\"17\">&nbsp;</TD>" +
                "<TD class=\"PageBorderTopRightCorner\" vAlign=\"top\" align=\"right\" width=\"18\" height=\"17\">&nbsp;</TD>" +
                "</TR><TR><TD class=\"PageBorderLeft\" vAlign=\"top\" align=\"left\" height=\"25\"></TD>" +
                "<TD class=\"TextBodySubHeader\" vAlign=\"middle\" align=\"left\" height=\"25\">" +
                "<img src=\"{0}/Images/logo/logo_25.jpg\" border=\"0\" align=\"left\" alt=\"logo\" /><span class=\"TextBodySubHeader\"><b>" +
                "{1} </b></span><br><hr>" +
                "</TD><TD class=\"PageBorderRight\" vAlign=\"top\" align=\"right\" height=\"25\"></TD></TR><TR>" +
                "<TD class=\"PageBorderLeft\" vAlign=\"top\" align=\"left\">&nbsp;</TD><TD class=\"TextBodySmall\">" +
                "<br><br>{2}<br />" +
                "</TD><TD class=\"PageBorderRight\" vAlign=\"top\" align=\"right\"></TD></TR><TR>" +
                "<TD class=\"PageBorderBottomLeftCorner\" vAlign=\"top\" align=\"left\" width=\"18\" height=\"18\">&nbsp;</TD>" +
                "<TD class=\"PageBorderBottom\" vAlign=\"bottom\" align=\"left\">&nbsp;</TD>" +
                "<TD class=\"PageBorderBottomRightCorner\" vAlign=\"bottom\" align=\"right\" width=\"18\" height=\"18\">&nbsp;</TD>" +
                "</TR></table></body></html>",
                defaultSite == null ? String.Empty : defaultSite.URL, Subject, message);

            Result = Result.Replace("\r\n", "<br />");

            return (Result);
        }

        #endregion Private Methods
    }
}
