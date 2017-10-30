using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

using Library.BOL.Mail;

namespace Website.Library.Classes
{
    /// <summary>
    /// Send's an email directly without going into a store
    /// </summary>
    public class EmailSend
    {
        private const string STANDARD_HTML_WRAPPER = "<!DOCTYPE html>" +
            "<html xmlns:fb=\"http://www.facebook.com/2008/fbml\" xmlns:og=\"http://opengraph.org/schema/\">" +
            "<head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />" +
            "</head><body style=\"font-family: Arial; font-size: 1.3em;\">" +
            "<div>{0}</div></body></html>";

        #region Private Members

        private EmailSettingsSingletonClass _emailSettings;


        #endregion Private Members

        #region Constructors

        public EmailSend()
        {
            _emailSettings = EmailSettingsSingletonClass.GetInstance(BaseWebApplication.SMTPHost,
                BaseWebApplication.SMTPPort, BaseWebApplication.SMTPUserName,
                BaseWebApplication.SMTPPassword, BaseWebApplication.SMTPUseSSL);
        }

        #endregion Constructors

        #region Public Methods

        public bool Send(string subject, string message)
        {
            bool Result = false;

            try
            {
                MailMessage msg = new MailMessage();

                msg.Subject = subject;
                msg.IsBodyHtml = true;

                if (message.Contains("<body>"))
                    msg.Body = message;
                else
                    msg.Body = String.Format(STANDARD_HTML_WRAPPER, message);

                msg.From = new MailAddress(_emailSettings.SMTPUsername, _emailSettings.SMTPUsername);

                msg.To.Add(BaseWebApplication.SupportEMail);

                System.Net.Mail.SmtpClient Smtp = new SmtpClient();
                try
                {
                    Smtp.Host = _emailSettings.SMTPServer; // for example gmail smtp server

                    Smtp.EnableSsl = _emailSettings.SMTPSslConnection;
                    Smtp.Port = _emailSettings.SMTPServerPort;

                    Smtp.Credentials = new System.Net.NetworkCredential(
                        _emailSettings.SMTPUsername, _emailSettings.SMTPPassword);

                    Smtp.Send(msg);
                }
                finally
                {
                    Smtp.Dispose();
                    Smtp = null;
                }

                Result = true;
            }
            catch (Exception err)
            {
                Shared.EventLog.Add(err);
            }


            return (Result);
        }

        #endregion Public Methods
    }
}
