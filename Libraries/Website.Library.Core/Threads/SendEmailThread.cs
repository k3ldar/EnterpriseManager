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
 *  File: SendEmailThread.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  17/03/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using Shared.Classes;

using lib = Library;
using Library.BOL.Mail;
using Library.BOL.Websites;

using Website.Library.Core.Interfaces;

namespace Website.Library.Core.Threads
{
    internal sealed class SendEmailThread : ThreadManager
    {
        #region Private Members

        private EmailSettingsSingletonClass _emailSettings;

        private readonly IBaseWebApplication _baseWebApplication;

        private readonly ILogging _logging;

        private EmailMessage _emailClass;

        //private static Int64 _emailQueueSize = 0;
        private static int _emailMaxHistorySize = 50;

        #endregion Private Members

        #region Constructors

        internal SendEmailThread(IBaseWebApplication baseWebApplication, ILogging logging)
            : base(null, new TimeSpan(0, 1, 0))
        {
            _baseWebApplication = baseWebApplication ?? throw new ArgumentNullException(nameof(baseWebApplication));
            _logging = logging ?? throw new ArgumentNullException(nameof(logging));

            HangTimeout = 0;
            RunAtStartup = false;
            _emailSettings = EmailSettingsSingletonClass.GetInstance(WebsiteSettings.Email.SMTPHost,
                WebsiteSettings.Email.SMTPPort, WebsiteSettings.Email.SMTPUserName,
                WebsiteSettings.Email.SMTPPassword, WebsiteSettings.Email.SMTPUseSSL);
        }

        #endregion Constructors

        #region Overridden Methods

        protected override bool Run(object parameters)
        {
            try
            {
                // Create new Email Object
                _emailClass = new EmailMessage
                {
                    // Set SMTP Sever Settings
                    SMTPServerName = _emailSettings.SMTPServer,
                    SMTPServerPort = _emailSettings.SMTPServerPort,
                    SMTPUserName = _emailSettings.SMTPUsername,
                    SMTPUserPassword = _emailSettings.SMTPPassword,
                    SMTPSSL = _emailSettings.SMTPSslConnection,
                    MaximumSendAttempts = _emailSettings.EmailMaxSendAttempt
                };

                // Send email and record any errors

                EmailStatusReport _mailServerMesages = _emailClass.Send();

                if (_mailServerMesages.Count > 0)
                {
                    using (TimedLock.Lock(Services.BaseWebApplication.EmailLockObject))
                    {
                        if (Services.BaseWebApplication._emailServerHistory.Count > _emailMaxHistorySize)
                            Services.BaseWebApplication._emailServerHistory.Clear();

                        Services.BaseWebApplication._emailServerHistory.Add(_mailServerMesages);
                    }
                }
            }
            catch (Exception err)
            {
                if (!err.Message.Contains(lib.StringConsts.ERROR_THREAD_ABORTED))
                    _logging.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err);
            }

            return (true);
        }

        #endregion Overridden Methods
    }
}
