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
 *  File: Website.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

namespace SharedBase.BOL.Websites
{
    public class Website : BaseObject
    {
        #region Private Members

        private const string ENCRYPTION_KEY = "Poiasd;o8o;aercnaeicfj#';lasdjf";

        private string _ftpPassword;

        #endregion Private Members

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="url"></param>
        /// <param name="ftpHost"></param>
        /// <param name="ftpPort"></param>
        /// <param name="ftpUsername"></param>
        /// <param name="ftpPassword"></param>
        public Website(int id, string url, string ftpHost, int ftpPort, string ftpUsername, string ftpPassword, string ftpRoot)
        {
            ID = id;
            URL = url;
            FtpHost = ftpHost;
            FtpPort = ftpPort;
            FtpUserName = ftpUsername;
            _ftpPassword = ftpPassword;
            RootPath = ftpRoot;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Unique ID
        /// </summary>
        public int ID { get; internal set; }

        /// <summary>
        /// Website URL
        /// </summary>
        public string URL { get; set; }


        public string Domain
        {
            get
            {
                if (String.IsNullOrEmpty(URL))
                    return (String.Empty);

                Uri uri = new Uri(URL);

                if (uri.Host == "localhost")
                    return (uri.Authority);
                else
                    return (uri.Host);
            }
        }

        /// <summary>
        /// FTP Host/IP Address
        /// </summary>
        public string FtpHost { get; set; }

        /// <summary>
        /// Ftp Port
        /// </summary>
        public int FtpPort { get; set; }

        /// <summary>
        /// Ftp Username
        /// </summary>
        public string FtpUserName { get; set; }

        /// <summary>
        /// FTP Password
        /// </summary>
        public string FtpPassword
        {
            get
            {
                if (String.IsNullOrEmpty(_ftpPassword))
                    return (String.Empty);

                return (Utils.StringCipher.Decrypt(_ftpPassword, ENCRYPTION_KEY));
            }

            set
            {
                _ftpPassword = Utils.StringCipher.Encrypt(value, ENCRYPTION_KEY);
            }
        }

        public string RootPath { get; set; }

        #endregion Properties

        #region Methods

        public bool TestFTPConnection(bool throwException = true)
        {
            try
            {
                Shared.Classes.ftp ftpClient = new Shared.Classes.ftp(FtpHost, FtpUserName, FtpPassword, 2048,
                    true, true, true, FtpPort);
                try
                {
                    // test the connection by getting a directory listing
                    ftpClient.DirectoryListSimple("/");
                    return (true);
                }
                finally
                {
                    ftpClient = null;
                }
            }
            catch
            {
                if (throwException)
                    throw;
            }

            return (false);
        }

        #endregion Methods

        #region Static Methods

        public static string EncryptPassword(string s)
        {
            if (String.IsNullOrWhiteSpace(s))
                return (String.Empty);

            return (Utils.StringCipher.Encrypt(s, ENCRYPTION_KEY));
        }

        #endregion Static Methoods
    }
}
