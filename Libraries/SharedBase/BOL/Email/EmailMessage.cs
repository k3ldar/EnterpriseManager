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
 *  File: EmailMessage.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

using System.Net;
using System.Net.Mail;


namespace SharedBase.BOL.Mail
{

    /// <summary>
    /// Contains the required information to send queued email messages returned from the BOL/DAL layer
    /// </summary>
    [Serializable]
    public sealed class EmailMessage : MailMessage
    {

        #region Private members

        private string _fromName;
        private string _smtpServerName;
        private string _smtpUserName;
        private string _smtpUserPassword;
        private string _smtpUserDomain;
        private int _smtpServerPort;
        private bool _smtpSSL;
        private bool _removeSentEmail;
        private static Int64 _queueSize;
        private Int16 _maxSentAttempts;

        #endregion

        #region Public Events

        //#if NET2_0

        ///// <summary>
        ///// Event arises when a message has been sent successfully
        ///// </summary>
        //public event EventEmailSent MessageSent;

        //#endif

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public EmailMessage()
            : base()
        {
            InitialiseMembers();
        }

#if NET2_0

        /// <summary>
        /// 
        /// </summary>
        /// <param name="To"></param>
        /// <param name="From"></param>
        public EmailMessage(string To, string From)
            : base(From, To)
        {
            InitialiseMembers();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="To"></param>
        /// <param name="From"></param>
        /// <param name="Subject"></param>
        /// <param name="Body"></param>
        public EmailMessage(string To, string From, string Subject, string Body)
            : base(From, To, Subject, Body)
        {
            InitialiseMembers();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="From"></param>
        /// <param name="To"></param>
        public EmailMessage(MailAddress From, MailAddress To)
            : base(From, To)
        {
            InitialiseMembers();
        }

#endif

        #endregion

        #region Public Properties

        /// <summary>
        /// Get/Set the maximum number of times a send attempt will be made for an email
        /// </summary>
        public Int16 MaximumSendAttempts
        {
            get
            {
                return _maxSentAttempts;
            }
            set
            {
                _maxSentAttempts = value;
            }
        }

        /// <summary>
        /// Remove sent email from the database
        /// </summary>
        public bool RemoveSentEmail
        {
            set
            {
                _removeSentEmail = value;
            }
            get
            {
                return _removeSentEmail;
            }
        }

        /// <summary>
        /// The display name that will appear
        /// in the recipient mail client
        /// </summary>
        public string FromName
        {
            set
            {
                _fromName = value;
            }
            get
            {
                return _fromName;
            }
        }

        /// <summary>
        /// SMTP server (name or IP address)
        /// </summary>
        public string SMTPServerName
        {
            set
            {
                _smtpServerName = value;
            }
            get
            {
                return _smtpServerName;
            }
        }

        /// <summary>
        /// Username for a SMTP server
        /// </summary>
        public string SMTPUserName
        {
            set
            {
                _smtpUserName = value;
            }
            get
            {
                return _smtpUserName;
            }
        }

        /// <summary>
        /// Password for a SMTP server
        /// </summary>
        public string SMTPUserPassword
        {
            set
            {
                _smtpUserPassword = value;
            }
            get
            {
                return _smtpUserPassword;
            }
        }

        /// <summary>
        /// Domain for User
        /// </summary>
        public string SMTPUserDomain
        {
            set
            {
                _smtpUserDomain = value;
            }
            get
            {
                return _smtpUserDomain;
            }
        }

        /// <summary>
        /// SMTP server port (default 25)
        /// </summary>
        public int SMTPServerPort
        {
            set
            {
                _smtpServerPort = value;
            }
            get
            {
                return _smtpServerPort;
            }
        }

        /// <summary>
        /// If SMTP server requires SSL
        /// </summary>
        public bool SMTPSSL
        {
            set
            {
                _smtpSSL = value;
            }
            get
            {
                return _smtpSSL;
            }
        }

        #endregion

        #region Public Static Methods

        /// <summary>
        /// Retrieves the size of the email queue
        /// </summary>
        /// <param name="BoardID">Board ID</param>
        /// <returns>Number of emails in the send queue</returns>
        public static Int64 QueueSize()
        {
            RefreshQueueInformation();
            return _queueSize;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Send Email
        /// </summary>
        /// <returns>Status information</returns>
        public EmailStatusReport Send()
        {
            if (_smtpServerName.Length == 0)
            {
                throw new Exception("SMTP Server not specified");
            }

            //create SMTP Client and add credentials
            SmtpClient smtpClient = new SmtpClient(_smtpServerName, _smtpServerPort);


            // Email with Authentication 
            smtpClient.UseDefaultCredentials = false;

            if (_smtpUserDomain == null || _smtpUserDomain.Length == 0)
                smtpClient.Credentials = new NetworkCredential(_smtpUserName, _smtpUserPassword);
            else
                smtpClient.Credentials = new NetworkCredential(_smtpUserName, _smtpUserPassword, _smtpUserDomain);


            EmailStatusReport Result = new EmailStatusReport();

            try
            {
                if (_smtpServerName.Length != 0)
                {

                    int emailsSent = 0;

                    //try to send the message
                    try
                    {
                        Emails emails = DAL.FirebirdDB.EmailsGet(false, _maxSentAttempts);
                        Result.UnsentMessages = emails.Count;
                        Result.InitialQueueSize = emails.Count;

                        foreach (Email email in emails)
                        {
                            try
                            {
                                // Email with Authentication 
                                smtpClient.UseDefaultCredentials = false;

                                if (_smtpUserDomain == null || _smtpUserDomain.Length == 0)
                                    smtpClient.Credentials = new NetworkCredential(email.Sender, _smtpUserPassword);
                                else
                                    smtpClient.Credentials = new NetworkCredential(email.Sender, _smtpUserPassword, _smtpUserDomain);


                                MailMessage message = new MailMessage(email.Sender, email.Recipient, email.Subject, email.Message);

                                if (email.FromName.Length > 0)
                                {
                                    message.From = new MailAddress(email.Sender, email.FromName);

                                    this.Headers.Add("From",
                                          string.Format("{0} <{1}>",
                                          email.FromName, email.Sender));
                                }


                                message.IsBodyHtml = true; // (message.Body.ToUpper().StartsWith("<HTML>"));

                                //if (message.IsBodyHtml)
                                //{
                                //    message.Body = message.Body.Replace("\n", "<br />");
                                //    //message.Body = ConvertPlainTextLinkToHTML(message.Body, email.URL);
                                //}

                                try
                                {
                                    smtpClient.Send(message);
                                    DAL.FirebirdDB.EmailMarkSent(email, String.Format("{0} - {1}", email.Subject, email.Recipient.ToString()));
                                    emailsSent++;
                                    Result.UnsentMessages--;
                                    Result.Add(new StatusReportEntry(email.Subject, email.Recipient));
                                }
                                catch (Exception Ex)
                                {
                                    // Record an email sent attemp for the message
                                    DAL.FirebirdDB.EmailRecordSentAttempt(email, Ex.Message.ToString());

                                    Exception curException = Ex;
                                    while (curException != null)
                                    {
                                        string details = "details unknown";
                                        try
                                        {
                                            details = String.Format("{0} - {1}", email.Recipient, email.Subject);
                                            Result.Add(new StatusReportEntry(details, null));
                                        }
                                        catch
                                        {
                                        }

                                        if (curException.InnerException == null)
                                            Result.Add(new StatusReportEntry(curException.Message, null));

                                        curException = curException.InnerException;
                                    }

                                    return (Result);
                                }
                            }
                            catch (Exception err)
                            {
                                // Record an email sent attemp for the message
                                DAL.FirebirdDB.EmailRecordSentAttempt(email, err.Message.ToString());
                                throw;
                            }
                        }

                        // Mark Report Complete
                        Result.ReportComplete();

                        // Remove sent emails for the board
                        if (_removeSentEmail)
                        {
                            DAL.FirebirdDB.EmailDeleteSent();
                        }
                    }
                    catch (Exception Ex)
                    {
                        return new EmailStatusReport(new StatusReportEntry(Ex.Message, null));
                    }

                    return (Result);
                }
            }
            catch
            {
                //ignore errors
            }

            return new EmailStatusReport(new StatusReportEntry("SMTP Server not specified", null));

        }


        public bool Send(string senderName, string senderEmail, string recipientName, string recipientEmail, string subject, string messageBody)
        {
            bool Result = false;

            if (_smtpServerName.Length == 0)
            {
                throw new Exception("SMTP Server not specified");
            }

            //create SMTP Client and add credentials
            SmtpClient smtpClient = new SmtpClient(_smtpServerName, _smtpServerPort);


            // Email with Authentication 
            smtpClient.UseDefaultCredentials = false;

            if (_smtpUserDomain == null || _smtpUserDomain.Length == 0)
                smtpClient.Credentials = new NetworkCredential(_smtpUserName, _smtpUserPassword);
            else
                smtpClient.Credentials = new NetworkCredential(_smtpUserName, _smtpUserPassword, _smtpUserDomain);




            if (_smtpServerName.Length != 0)
            {
                // Email with Authentication 
                smtpClient.UseDefaultCredentials = false;

                if (_smtpUserDomain == null || _smtpUserDomain.Length == 0)
                    smtpClient.Credentials = new NetworkCredential(senderEmail, _smtpUserPassword);
                else
                    smtpClient.Credentials = new NetworkCredential(senderEmail, _smtpUserPassword, _smtpUserDomain);


                MailMessage message = new MailMessage(senderEmail,recipientEmail, subject, messageBody);

                if (senderName.Length > 0)
                {
                    message.From = new MailAddress(senderEmail, senderName);

                    this.Headers.Add("From",
                          string.Format("{0} <{1}>",
                          senderName, senderEmail));
                }


                message.IsBodyHtml = true;


                smtpClient.Send(message);
                Result = true;

            }


            return (Result);
        }

        #endregion

        #region Private Methods

        private void InitialiseMembers()
        {
            _fromName = string.Empty;
            _smtpServerName = string.Empty;
            _smtpUserName = string.Empty;
            _smtpUserPassword = string.Empty;
            _smtpServerPort = 25;
            _smtpSSL = false;
            _removeSentEmail = false;
            _queueSize = 0;
            _maxSentAttempts = 10;
        }

        private static void RefreshQueueInformation()
        {
            DAL.FirebirdDB.EmailQueueStatistics(out _queueSize);
        }

        #endregion

        #region Public Static Event Handlers

#if NET2_0

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //public static void SmtpClient_OnCompleted(object sender, AsyncCompletedEventArgs e)
        //{
        //  //Get the Original MailMessage object
        //  MailMessage mail= (MailMessage)e.UserState;

        //  //write out the subject
        //  string subject = mail.Subject;

        //  if (e.Cancelled)
        //  {
        //      System.Diagnostics.Debug.WriteLine("Send canceled for mail with subject [{0}].", subject);
        //  }
        //  if (e.Error != null)
        //  {
        //      System.Diagnostics.Debug.WriteLine("Error {1} occurred when sending mail [{0}] ", subject, e.Error.ToString());
        //  }
        //  else
        //  {
        //      System.Diagnostics.Debug.WriteLine("Message [{0}] sent.", subject );
        //  }
        //}

#endif

        #endregion

        #region Public Static Methods

        /// <summary>
        /// Convert a plain text link to a html link
        /// </summary>
        /// <param name="Message">Message containing plain text link</param>
        /// <param name="Link">link used for conversion (can be a partial link)</param>
        /// <returns>Message with links converted</returns>
        public static string ConvertPlainTextLinkToHTML(string Message, string Link)
        {
            string convertedMessage = Message;

            // Set Regular Expression string
            StringBuilder regexSearch = new StringBuilder(@"\b");
            regexSearch.Append(Link);
            regexSearch.Append(@"?[\w\d\.\/\:\?\=\&]+[^\<^\s^\)^""]?\b");

            Regex regexObj = new Regex(regexSearch.ToString(), RegexOptions.IgnoreCase);

            //Check to see if there is a match in the message
            if (regexObj.IsMatch(Message))
            {
                // Initialise Variables
                string replacementLink = string.Empty;
                convertedMessage = string.Empty;
                int position = 0;

                // Loop through the matches
                foreach (Match match in regexObj.Matches(Message))
                {
                    // Copy part of message into converted message
                    convertedMessage += Message.Substring(position, match.Index - position);

                    // Create replacement link and attach it to the message
                    replacementLink = @"<A href=" + match.ToString() + " target=\"_blank\">" + match.ToString() + "</A>";
                    convertedMessage += replacementLink; // Insert new link

                    // Set position
                    position = match.Index + match.Length;
                }

                // Copy remaining part of message into converted message
                if (position < Message.Length)
                    convertedMessage += Message.Substring(position);

                regexObj = null;
            }

            return convertedMessage;
        }

        #endregion

    }

} // End of Namespace
