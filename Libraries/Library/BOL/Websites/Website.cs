using System;

namespace Library.BOL.Websites
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
