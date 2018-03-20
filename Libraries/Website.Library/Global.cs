using System;

using lib = Library;
using Shared.Classes;
using Library.BOL.Websites;

namespace Website.Library
{
    public static class GlobalClass
    {
        #region Private Members


        #endregion Private Members

        #region Internal Members

        public static CacheManager InternalCacheShort = new CacheManager("Website Internal Cache 5 Minutes", new TimeSpan(0, 5, 0));

        public static CacheManager InternalCache = new CacheManager("Website Internal Cache", lib.DAL.DALHelper.CacheLimit);

        #endregion Internal Members

        #region Properties


        #region Site Template Settings

        /// <summary>
        /// if true, top products shown on products menu, otherwise categories are shown
        /// </summary>
        public static bool ShowTopProducts { get; set; }



      

        #endregion Site Template Settings



        public static bool AllowUseOfCurrencyConversion { get; set; }

        /// <summary>
        /// Website which is mapped to this site
        /// </summary>
        public static string MappedWebsite { get; set; }

        /// <summary>
        /// Returns the address across 1 line formatted for HTML
        /// </summary>
        public static string Address { get; set; }

        /// <summary>
        /// Returns the Database Connection String
        /// </summary>
        internal static string ConnString
        {
            get
            {
                string ConfigFile = Shared.Utilities.CurrentPath(true) + @"HSCConfig.xml";
                return (Shared.XML.GetXMLValue("Settings", "RootPath", ConfigFile));
            }
        }

        /// <summary>
        /// Default static Keywords
        /// </summary>
        public static string DefaultMetaKeyWords { get; set; } 

        #endregion Properties

        #region Internal Methods

        internal static string GetRandomPassword()
        {
            string AcceptableChars = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ.";
            string Result = "";
            Random rnd = new Random();

            for (int i = 0; i < 9; i++)
            {
                int ch = rnd.Next(AcceptableChars.Length - 1);
                Result += AcceptableChars.Substring(ch, 1);
            }

            return Result;
        }

        internal static string GetRandomKey()
        {
            string Result = "";
            Random rnd = new Random();

            for (int i = 0; i < 3; i++)
            {
                char s = (char)(byte)rnd.Next(65, 91);
                Result = Result + s;
            }

            Result = Result + "-";

            for (int i = 0; i < 6; i++)
            {
                Result = Result + Convert.ToString(rnd.Next(9));
            }

            return Result;
        }

        internal static string GetRandomDiscountCoupon()
        {
            string Result = "";
            Random rnd = new Random();

            for (int i = 0; i < 3; i++)
            {
                char s = (char)(byte)rnd.Next(65, 91);
                Result = Result + s;
            }

            Result = Result + "-";

            for (int i = 0; i < 6; i++)
            {
                Result = Result + Convert.ToString(rnd.Next(9));
            }

            Result = Result + "-";

            for (int i = 0; i < 3; i++)
            {
                char s = (char)(byte)rnd.Next(65, 91);
                Result = Result + s;
            }

            return Result;
        }

        #region Encryption

        public static string Encrypt(string InStr)
        {
            if (InStr.Length == 0)
                return "";

            Random rnd = new Random();
            Char C = (Char)((InStr.Length + 50));
            string Result = Convert.ToString(C);
            int Offset = rnd.Next(1, 30);
            Result = Result + Convert.ToString((Char)(Offset + 30));


            //buffer out to 50 char string
            while (InStr.Length < 50)
            {
                InStr = InStr + (Char)rnd.Next(20, 120);
            }

            for (int I = 0; I <= InStr.Length - 1; I++)
            {
                Result = Result + (Char)rnd.Next(35, 125);
                Result = Result + (Char)rnd.Next(35, 125);
                Result = Result + (Char)(Byte)(InStr[I] + Offset);
            }

            return Result;
        }

        public static string Decrypt(string InStr)
        {
            if (String.IsNullOrEmpty(InStr))
                return (String.Empty);
            try
            {
                int Len = (Char)((InStr[0]) - 50);
                int Offset = (Char)(InStr[1] - 30);

                string Result = "";
                int J = 1;

                for (int I = 2; I <= InStr.Length - 1; I++)
                {
                    if ((J % 3) == 0)
                    {
                        Result = Result + (Char)(Byte)(InStr[I] - Offset);

                        if ((Result.Length) == Len)
                        {
                            return Result;
                        }
                    }

                    J = J + 1;
                }

                return Result;
            }
            catch
            {
                return "";
            }
        }

        #endregion Encryption

        #region Emails

        /// <summary>
        /// Sends an email to webadmin
        /// </summary>
        /// <param name="ErrorMessage">Error Message</param>
        //internal static void SendEmail(string ErrorMessage)
        //{
        //    SendEMail(GlobalClass.SupportName, GlobalClass.SupportEMail, 
        //        String.Format("Website Error (3) - {0}", WebsiteSettings.DistributorWebsite), 
        //        ErrorMessage);
        //}


        /// <summary>
        /// Sends an email to webadmin
        /// </summary>
        /// <param name="Message">Message</param>
        /// <param name="Title">Title of email</param>
        //internal static void SendEmail(string Title, string Message)
        //{
        //    SendEMail(GlobalClass.SupportName, GlobalClass.SupportEMail, Title, Message);
        //}


        internal static void SendEMail(string ToName, string ToEMail, string Title,
            string Msg)
        {
            SendEMail(ToName, ToEMail, Title, Msg, WebsiteSettings.Email.NoReplyName, WebsiteSettings.Email.NoReplyEmail);
        }

        internal static void SendEMail(string ToName, string ToEMail, string Title,
            string Msg, string FromName, string FromEMail)
        {
            lib.BOL.Mail.Emails.Add(ToName, ToEMail, FromName, FromEMail, Title, Msg);
        }

        #endregion Emails

        #endregion Internal Methods
    }
}
