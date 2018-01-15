using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;
using System.IO;

using lib = Library;
using Shared.Classes;

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

        public static bool ShowSalonsMenu { get; set; }

        public static bool ShowSalonFinder { get; set; }
        public static bool ShowClientHeader { get; set; }
        public static bool ShowSalonHeader { get; set; }


        public static bool ShowTreatmentsMenu { get; set; }

        public static bool ShowTreatmentsBrochure { get; set; }

        public static bool ShowDistributorsMenu { get; set; }

        public static bool ShowTipsAndTricksMenu { get; set; }

        public static bool ShowDownloadMenu { get; set; }

        


        /// <summary>
        /// Determines wether terms and conditions are shown
        /// </summary>
        public static bool ShowTermsAndConditions { get; set; }

        /// <summary>
        /// Determines wether the returns policy is shown or not
        /// </summary>
        public static bool ShowReturnsPolicy { get; set; }

        /// <summary>
        /// Show Trade Page
        /// </summary>
        public static bool ShowTradePage { get; set; }

        /// <summary>
        /// Determines wether the Privacy Policy is shown or not
        /// </summary>
        public static bool ShowPrivacyPolicy { get; set; }

        #endregion Site Template Settings


        /// <summary>
        /// Current Style sheet being used
        /// </summary>
        public static string StyleSheet = "style9.css";


        public static string StyleSheetLocation = "/css/";

        /// <summary>
        /// Determines wether XML Image Files are created
        /// </summary>
        public static bool CreateXMLImageFiles { get; set; }

        /// <summary>
        /// Determines wether routine database maintenance is run
        /// 
        /// Used for websites that share a database
        /// </summary>
        public static bool AllowRoutineMaintenance { get; set; }


        public static bool AllowUseOfCurrencyConversion { get; set; }

        /// <summary>
        /// Website which is mapped to this site
        /// </summary>
        public static string MappedWebsite { get; set; }

        /// <summary>
        /// Email used for no reply
        /// </summary>
        public static string NoReplyEmail { get; set; }


        public static string NoReplyName { get; set; }

        /// <summary>
        /// Returns the address across 1 line formatted for HTML
        /// </summary>
        public static string Address { get; set; }

        /// <summary>
        /// Date format used by the website
        /// </summary>
        public static string WebsiteDateFormat { get; set; }

        /// <summary>
        /// Name of basket
        /// </summary>
        public static string BasketName { get; set; }

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
        /// Returns the root url for the website
        /// </summary>
        public static string RootURL { get; set; }

        /// <summary>
        /// Returns the root path for the website
        /// </summary>
        public static string RootPath { get; set; }

        /// <summary>
        /// Using left to right or right to left character set?
        /// </summary>
        public static bool UseLeftToRight { get; set; }

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

        internal static string Encrypt(string InStr)
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

        internal static string Decrypt(string InStr)
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
        //        String.Format("Website Error (3) - {0}", GlobalClass.DistributorWebsite), 
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
            SendEMail(ToName, ToEMail, Title, Msg, GlobalClass.NoReplyName, GlobalClass.NoReplyEmail);
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
