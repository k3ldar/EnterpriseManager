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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: Utils.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Reflection;

using Library.BOL.Basket;
using Library.BOL.Users;

using Shared;
using Shared.Classes;

namespace Library.Utils
{

    /// <summary>
    /// Summary description for Utils.
    /// </summary>
    public static class SharedUtils
    {
        #region Public Methods

        public static string SEOName(string s)
        {
            s = s.Replace(" & ", " and ");
            const string ACCEPTABLE_CHARACTERS = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXY";

            string Result = String.Empty;

            foreach (char c in s)
            {
                if (ACCEPTABLE_CHARACTERS.Contains(c.ToString()))
                    Result += c;
                else
                    Result += "-";
            }

            while (Result.Contains("--"))
                Result = Result.Replace("--", "-");

            return (Result);
        }

        /// <summary>
        /// Determines wether a string starts with a number or not
        /// </summary>
        /// <param name="s">string to test</param>
        /// <returns>bool, true if starts with a number, otherwise false</returns>
        public static bool StartsWithNumber(string s)
        {
            return (Regex.IsMatch(s, @"^\d+"));
        }

        public static string BufferText(string Text, int Length)
        {
            string Result = Text;

            while (Result.Length < Length)
                Result += " ";

            return (Result);
        }

        public static string TimeToString(int Time)
        {
            string Result = "";
            int time = Time;
            int hours = (int)time / 60;
            int mins = (time - (hours * 60));

            if (hours == 0)
            {
                Result = String.Format("{0} minutes", mins);
            }
            else
            {
                if (hours > 1)
                {
                    if (mins == 0)
                        Result = String.Format("{0} hours", hours);
                    else
                        Result = String.Format("{0} hours and {1} minutes", hours, mins);
                }
                else
                {
                    if (mins == 0)
                        Result = String.Format("{0} hour", hours);
                    else
                        Result = String.Format("{0} hour and {1} minutes", hours, mins);
                }
            }

            return (Result);
        }

        public static string SplitCamelCase(string s)
        {
            Regex r = new Regex(@"
                (?<=[A-Z])(?=[A-Z][a-z]) |
                 (?<=[^A-Z])(?=[A-Z]) |
                 (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);
            try
            {
                return (r.Replace(s, " "));
            }
            finally
            {
                r = null;
            }
        }

        public static string DateTimeToStr(DateTime Value, CultureInfo Culture)
        {
            IFormatProvider culture = Culture;
            string Result = Value.ToString(culture);
            return (Result);
        }

        public static string DateToStr(DateTime Value, CultureInfo Culture)
        {
            string Result = Value.ToString(Culture);
            Result = Result.Remove(Result.Length - 8, 8);
            return (Result);
        }

        public static decimal VATRemove(decimal Value, double VATRate)
        {
            if (VATRate == 0.0)
                VATRate = DAL.DALHelper.DefaultVATRate;

            return ((100 / (100 + (decimal)VATRate)) * Value);
        }

        public static decimal VATCalculatePaid(decimal value, double vatRate)
        {
            return (value - ((100 / (100 + (decimal)vatRate)) * value));
        }

        public static decimal VATCalculate(decimal Value, double VATRate)
        {
            return (((decimal)VATRate / 100) * Value);
        }

        public static decimal VATCalculate(decimal value, BOL.Countries.Country country)
        {
            return (VATCalculate(value, country.VATRate));
        }

        [Obsolete("Use VATCalculate(decimal, double)")]
        public static decimal VATCalculate(decimal Value)
        {
            return (VATCalculate(Value, DAL.DALHelper.DefaultVATRate));
        }

        public static DateTime StrToDateTime(string Value, string Culture)
        {
            IFormatProvider culture = new CultureInfo(Culture, true);
            DateTime Result = DateTime.Parse(Value, culture, DateTimeStyles.AssumeLocal);
            return (Result);
        }


        public static decimal BankersRounding(decimal value, int decimalPlaces)
        {
            if (decimalPlaces < 0)
            {
                throw new ArgumentException("The decimals must be non-negative", "decimals");
            }

            decimal multiplier = (decimal)Math.Pow(10, decimalPlaces);
            decimal number = value * multiplier;

            if (decimal.Truncate(number) < number)
            {
                number += 0.5m;
            }

            return (decimal.Round(number) / multiplier);
        }

        public static string DoubleToTime(Double d)
        {
            //validation
            if (d < 0) d = 0; // less than zero then 0
            if (d > 24) d = 23.75;

            int h = (int)d;
            int m = (int)(((d - Math.Floor(d)) * 100) / 1.666666666666667);


            if (m > 0)
                m++;

            string Result = string.Format("{0}:{1}", h, m);

            if (m == 0)
                Result += "0";

            if (Result.Length == 4)
                Result = "0" + Result;

            return (Result);
        }

        public static string RemoveDblQuotes(string s)
        {
            string Result = s;

            if (Result.StartsWith("\""))
                Result = Result.Substring(1, Result.Length - 2);

            return (Result);
        }

        public static DateTime DoubleToDate(DateTime date, double Time)
        {
            DateTime Result = date;
            Result = Result.AddHours(-date.Hour);
            Result = Result.AddMinutes(-date.Minute);

            if (Time < 0) Time = 0; // less than zero then 0
            if (Time > 24) Time = 23.75;

            int h = (int)Time;
            int m = (int)(((Time - Math.Floor(Time)) * 100) / 1.666666666666667);

            if (m > 0)
                m++;

            Result = Result.AddHours(h);
            Result = Result.AddMinutes(m);


            return (Result);
        }

        public static DateTime DoubleToDate(DateTime date, double Time, int Duration)
        {
            DateTime Result = date;

            if (Time < 0) Time = 0; // less than zero then 0
            if (Time > 24) Time = 23.75;

            int h = (int)Time;
            int m = (int)(((Time - Math.Floor(Time)) * 100) / 1.666666666666667);

            if (m > 0)
                m++;

            Result = Result.AddHours(h);
            Result = Result.AddMinutes(m);

            int MinSlots15 = Duration / 15;

            for (int i = 0; i < MinSlots15; i++)
                Result = Result.AddMinutes(15);


            return (Result);
        }

        public static double DateToDouble(DateTime date)
        {
            return (TimeToDouble(date.ToString("HH:MM")));
        }

        public static double TimeToDouble(string t)
        {
            string[] parts = t.Split(':');
            string s = "";

            switch (parts[1])
            {
                case "15":
                    s = "25";
                    break;
                case "30":
                    s = "50";
                    break;
                case "45":
                    s = "75";
                    break;
            }

            s = parts[0] + "." + s;

            return (Convert.ToDouble(s));
        }


        public static bool IsValidEmail(string inputEmail)
        {
            bool Result = false;

            if (inputEmail == null)
                inputEmail = string.Empty;

            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                Result = true;

            return (Result);
        }


        public static Double ConvertKMtoMiles(Double KM)
        {
            return (KM * 0.621371192);
        }

        public static string ProperCase(string S)
        {
            string Result = S.ToLower();

            try
            {
                System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentUICulture;
                System.Globalization.TextInfo TextInfo = cultureInfo.TextInfo;
                Result = TextInfo.ToTitleCase(Result);
            }
            catch
            {
                Result = S;
            }
            return (Result);
        }

        /// <summary>
        /// determines wether the http url is valid or not
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsValidURL(string url)
        {
            Uri uriResult;
            return(Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps));
        }

        public static bool IsValidUKPostcode(string InPostCode, out string PostCode)
        {
            bool Result = false;
            PostCode = InPostCode.ToUpper();
            PostCode = PostCode.Trim();

            // remove the space
            PostCode = PostCode.Replace(" ", "");

            switch (PostCode.Length)
            {
                case 5:
                    PostCode = PostCode.Substring(0, 2) + " " + PostCode.Substring(2, 3);
                    break;
                case 6:
                    PostCode = PostCode.Substring(0, 3) + " " + PostCode.Substring(3, 3);
                    break;
                case 7:
                    PostCode = PostCode.Substring(0, 4) + " " + PostCode.Substring(4, 3);
                    break;
            }

            Regex postcode = new Regex(@"(GIR 0AA)|(((A[BL]|B[ABDHLNRSTX]?|C[ABFHMORTVW]|D[ADEGHLNTY]|E[HNX]?|F[KY]|G[LUY]?|H[ADGPRSUX]|I[GMPV]|JE|K[ATWY]|L[ADELNSU]?|M[EKL]?|N[EGNPRW]?|O[LX]|P[AEHLOR]|R[GHM]|S[AEGKLMNOPRSTY]?|T[ADFNQRSW]|UB|W[ADFNRSV]|YO|ZE)[1-9]?[0-9]|((E|N|NW|SE|SW|W)1|EC[1-4]|WC[12])[A-HJKMNPR-Y]|(SW|W)([2-9]|[1-9][0-9])|EC[1-9][0-9]) [0-9][ABD-HJLNP-UW-Z]{2})", RegexOptions.Singleline);

            Match m = postcode.Match(PostCode);

            Result = m.Success;

            return (Result);
        }


        public static string HashStringMD5(string Value)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(Value);
            data = x.ComputeHash(data);
            string ret = "";
            for (int i = 0; i < data.Length; i++)
                ret += data[i].ToString("x2").ToLower();
            return ret;
        }

        /// <summary>
        /// Format's Money for display
        /// </summary>
        /// <param name="value">Monetary value, in any currency</param>
        /// <param name="currency">Currency used to format the money</param>
        /// <param name="removeCurrencySymbol">should the currency symbol be removed</param>
        /// <returns>string, value formatted to local currency value/format</returns>
        public static string FormatMoney(decimal value, Currency currency, 
            bool removeCurrencySymbol = false, bool ignoreMultiplier = false)
        {
            decimal amount = value;

            if (!ignoreMultiplier)
            {
                if (((DAL.DALHelper.OverrideCostMultiplier) && DAL.DALHelper.OverrideCostMultiplierValue > 0.00))
                {
                    amount = amount + (amount * (decimal)DAL.DALHelper.OverrideCostMultiplierValue);
                }
                else if (currency.Multiplier != 1.0m)
                {
                    amount = (amount * currency.Multiplier);
                }
            }

            if (currency.ConversionRate != 1.0m)
            {
                amount = (amount * currency.ConversionRate);
            }

            CultureInfo newCulture;

            newCulture = CultureInfo.CreateSpecificCulture(currency.Culture);

            string Result = String.Format(newCulture, "{0:C}", amount);

            if (removeCurrencySymbol)
            {
                string ISO = String.Empty;

                Result = Result.Replace(Shared.Utilities.GetCurrencySymbol(currency.Culture, out ISO), "");
            }

            RegionInfo region = new RegionInfo(newCulture.LCID);
            string isoSymbol = region.CurrencySymbol;

            if (currency.IsCustomSybmol && currency.CurrencySymbol != isoSymbol)
            {
                Result = Result.Replace(isoSymbol, currency.CurrencySymbol);
            }

            return (Result);
        }

        public static string GetCurrencySymbol(CultureInfo culture)
        {
            string isos;
            return (GetCurrencySymbol(culture, out isos));
        }

        public static string GetCurrencySymbol(string Culture)
        {
            string isos;
            return (GetCurrencySymbol(Culture, out isos));
        }

        public static string GetCurrencySymbol(string Culture, out string ISOSymbol)
        {
            CultureInfo info = CultureInfo.CreateSpecificCulture(Culture);

            return (GetCurrencySymbol(info, out ISOSymbol));
        }

        public static string GetCurrencySymbol(CultureInfo Culture, out string ISOSymbol)
        {
            RegionInfo region = new RegionInfo(Culture.LCID);
            ISOSymbol = region.ISOCurrencySymbol;
            return (region.CurrencySymbol);
        }

        /// <summary>
        /// Prepares an individual post for showing on a board
        /// </summary>
        /// <param name="Session">User Session</param>
        /// <param name="S"></param>
        /// <param name="ShowSmilies"></param>
        /// <param name="ShowImages"></param>
        /// <param name="ShowBBCode"></param>
        /// <returns></returns>
        public static string PreProcessPost(string RootURL, string S)
        {
            // replace all line breaks with <BR>
            string Result = BBCode.MakeHtml(RootURL, S, false, true, true);
            Result = Result.Replace("\r\n", "<br />");
            Result = Result.Replace("\r", "<br />");

            return (Result);
        }

        public static int RoundUp(int Total, int DivBy)
        {
            int Result = 0;
            int rem = 0;

            Result = Math.DivRem(Total, DivBy, out rem);

            if (rem > 0)
                Result++;

            return (Result);
        }

        /// <summary>
        /// Creates a random password
        /// </summary>
        /// <param name="Length">Length of password</param>
        /// <returns></returns>
        public static string RandomPassword(int Length)
        {
            Random rnd = new Random();
            string Result = String.Empty;

            for (int i = 1; i < Length; i++)
            {
                char s = (char)(byte)rnd.Next(65, 91);
                Result += s;
            }

            return (Result);
        }

        public static string BoolToStr(bool b)
        {
            if (b)
                return "True";
            else
                return "False";
        }


        public static Double StrToDblDef(string Value, Double DefaultValue)
        {
            try
            {
                return (Convert.ToDouble(Value));
            }
            catch
            {
                return DefaultValue;
            }
        }

        public static Double StrToDbl(string Value)
        {
            return (Convert.ToDouble(Value));
        }


        public static Int64 StrToIntDef(string Value, Int64 DefaultValue)
        {
            try
            {
                if (Value == null || Value.Length == 0)
                    return (DefaultValue);

                return (Convert.ToInt64(Value));
            }
            catch
            {
                return DefaultValue;
            }
        }


        public static int StrToIntDef(string Value, int DefaultValue)
        {
            try
            {
                if (Value == null || Value.Length == 0)
                    return (DefaultValue);

                return (Convert.ToInt32(Value));
            }
            catch
            {
                return DefaultValue;
            }
        }


        /// <summary>
        /// Converts minutes into miliseconds
        /// </summary>
        /// <param name="Minutes">time in minutes to be converted</param>
        /// <param name="Default">Default time</param>
        /// <returns>Converted value in miliseconds</returns>
        public static string ConvertMinTomSecDef(string Minutes, string Default)
        {
            return (StrToDblDef(Minutes, StrToDblDef(Default, 0.0)) * 60 * 1000).ToString();
        }


        public static int ConvertMinTomSecDef(int Minutes, int Default)
        {
            return (Minutes * 60 * 1000);
        }

        public static bool TryParse(string number)
        {
            bool Result = false;

            try
            {
                Convert.ToInt32(number);
                Result = true;
            }
            catch
            {
                Result = false;
            }

            return (Result);
        }


        /// <summary>
        /// Converts miliseconds into minutes
        /// </summary>
        /// <param name="Miliseconds">time in miliseconds to be converted</param>
        /// <param name="Default">Default time</param>
        /// <returns>Converted value in minutes</returns>
        public static string ConvertmSecToMinDef(string Miliseconds, string Default)
        {
            return (StrToDblDef(Miliseconds, StrToDblDef(Default, 0.0)) / 60 / 1000).ToString();
        }

        /// <summary>
        /// Removes some HTML Elements
        /// </summary>
        /// <param name="s">string containing html elements</param>
        /// <returns>string without html elements</returns>
        public static string RemoveHTMLElements(string s)
        {
            string Result = s;
            string[] Replace = new string[7] { "  ", " ", "<", ">", "\"", "\r\n", "" };
            string[] Find = new string[7] { "&nbsp; ", " &nbsp;", "&lt;", "&gt;", "&quot;", "<p>", "</p>" };

            for (int i = 0; i < Find.Length; i++)
                Result = Result.Replace(Find[i], Replace[i]);

            return (Result);
        }

        public static string ReplaceHTMLElements(string S)
        {
            return (ReplaceHTMLElements(S, CaseType.Ignore));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public static string ReplaceHTMLElements(string S, CaseType ct)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentUICulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            string Result = BBCode.ReplaceHTMLElements(S);

            switch (ct)
            {
                case CaseType.Upper:
                    Result = textInfo.ToUpper(Result);
                    break;
                case CaseType.Lower:
                    Result = textInfo.ToLower(Result);
                    break;
                case CaseType.Proper:
                    Result = textInfo.ToTitleCase(Result);
                    break;
            }


            return (Result);
        }

        private enum LastEntry { None, Paragraph, Text, Header, ListStart, ListItem, ListEnd }

        public static string CreateBasicHTML(string data)
        {
            string Result = data ?? String.Empty;

            Result = Result.Trim();

            // assume it is html ?? dodgy but........
            //if (Result.Contains("/>") || Result.Contains("/ >") || Result.Contains("</"))
            //    return (Result);

            //LastEntry lastEntry = LastEntry.None;

            //Result = Result.Replace("\r\n", "\n");

            //while (Result.Contains("\n\n"))
            //    Result = Result.Replace("\n\n", "\n");

            //string[] lines = Result.Split('\n');
            //Result = String.Empty;

            //foreach(string line in lines)
            //{
            //    if (line.StartsWith("#"))
            //    {
            //        if (lastEntry == LastEntry.Paragraph)
            //        {
            //            Result += "</p>";
            //            lastEntry = LastEntry.None;
            //        }

            //        string start = line.Substring(0, line.IndexOf(" "));

            //        switch (start)
            //        {
            //            case "#1":
            //                Result += $"<h1>{line}</h1>";
            //                lastEntry = LastEntry.Header;
            //                break;

            //            case "#2":
            //                Result += $"<h2>{line}</h2>";
            //                lastEntry = LastEntry.Header;
            //                break;

            //            case "#3":
            //                Result += $"<h3>{line}</h3>";
            //                lastEntry = LastEntry.Header;
            //                break;

            //            case "#4":
            //                Result += $"<h4>{line}</h4>";
            //                lastEntry = LastEntry.Header;
            //                break;

            //            case "#B":
            //                switch (lastEntry)
            //                {
            //                    case LastEntry.Paragraph:
            //                    case LastEntry.Text:
            //                        Result += "</p><ul>";
            //                        break;

            //                    case LastEntry.Header:
            //                    case LastEntry.ListItem:
            //                    case LastEntry.None:
            //                        Result += "<ul>";
            //                        break;

            //                    case LastEntry.ListEnd:
            //                        Result += "<ul>";
            //                        break;

            //                    case LastEntry.ListItem:
            //                        break;
            //                }

            //                Result += $"<li>{line}</li>";
            //                break;

            //            default:
            //                Result += $"<p>{line}</p>";
            //                break;
            //        }
            //    }
            //    else if (String.IsNullOrEmpty(line)) // asume end of paragraph
            //    {
            //        if (Result.Length > 0 && !Result.EndsWith("</p>"))
            //            Result += "</p>";
            //    }
            //}

            return (Result);
        }

        /// <summary>
        /// Converts a string to a shortint (Int16)
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="DefaultValue"></param>
        /// <returns></returns>
        public static Int32 StrToInt(string Value, Int32 DefaultValue)
        {
            try
            {
                if (Value == null || Value.Length == 0)
                    return (DefaultValue);

                Int32 Result = Convert.ToInt32(Value);
                return (Result);
            }
            catch
            {
                return (DefaultValue);
            }
        }


        /// <summary>
        /// Converts a string to an Int64, provides a default value.
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="DefaultValue"></param>
        /// <returns></returns>
        public static Int64 StrToInt64Def(string Value, Int64 DefaultValue)
        {
            try
            {
                if (Value == null || Value.Length == 0)
                    return (DefaultValue);

                return (Convert.ToInt64(Value));
            }
            catch
            {
                return (DefaultValue);
            }
        }


        /// <summary>
        /// Converts a string to an integer
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static bool StrToBool(string Value)
        {
            if (Value.ToUpper().CompareTo("TRUE") == 0)
                return (true);
            else
                return (false);
        }

        /// <summary>
        /// Converts a string to a decimal
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static decimal StrToDecimal(string value, decimal defaultValue)
        {
            try
            {
                if (value == null || value.Length == 0)
                    return (defaultValue);

                return (Convert.ToDecimal(value));
            }
            catch
            {
                return (defaultValue);
            }
        }

        #endregion Public Methods

        #region Internal Methods

        internal static int GetWeek()
        {
            DateTime date = DateTime.Now;
            CultureInfo cult = CultureInfo.CurrentCulture;
            return (cult.Calendar.GetWeekOfYear(date,
                cult.DateTimeFormat.CalendarWeekRule,
                cult.DateTimeFormat.FirstDayOfWeek));
        }


        public static string Encrypt(string InStr)
        {
            Random rnd = new Random(DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond);

            if (InStr.Length == 0)
                return "";

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


        #endregion Internal Methods

        #region Static Methods

        public static string AddTrailingBackslash(string s)
        {
            string Result = s;

            if (!Result.EndsWith("\\"))
                Result += "\\";

            return (Result);
        }

        /// <summary>
        /// Validates the install for the store
        /// </summary>
        /// <param name="storeID">ID of store to validate</param>
        /// <returns>true if valid, otherwise false</returns>
        public static bool GetInstallValid(int storeID)
        {
            bool Result = true;

            WebClientEx client = new WebClientEx("Mozilla/4.0 (compatible; MSIE 7.0b; Windows NT 6.0) sdbot/POS/1.0");
            try
            {
                string isValid = client.DownloadString(String.Format("http://www.sieradelta.com/Members/Installer/POSInstallValid.aspx?StoreID={0}",
                    storeID));

                if (isValid.Contains("Page Not Found"))
                {
                    throw new Exception("The remote server returned an error: (404) Not Found.");
                }


                Result = isValid.ToLower() != "false";
            }
            catch (Exception err)
            {
                if (err.Message.Contains("Unable to connect to the remote server"))
                {
                    Result = true;
                }
                else if (err.Message.Contains("The remote server returned an error: (404) Not Found."))
                {
                    Result = true;
                }
                else if (err.Message.Contains("The operation has timed out"))
                {
                    Result = true;
                }
                else if (err.Message.Contains("remote name could not be resolved"))
                {
                    Result = true;
                }
                else if (err.Message.Contains("Too many automatic redirections were attempted"))
                {
                    Result = true;
                }
                else
                {
                    Library.ErrorHandling.LogError(MethodBase.GetCurrentMethod(), err, storeID);
                    Result = false;
                }
            }

            return (Result);
        }

        /// <summary>
        /// Resizes an image
        /// </summary>
        /// <param name="image"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string ResizeImage(string image, int size)
        {
            try
            {
                if (String.IsNullOrEmpty(image))
                    return (image);

                string Result = image;
                
                if (image.Contains("."))
                    Result = Result.Substring(0, image.Length - 8);

                string extension;

                if (image.Contains("."))
                    extension = image.Substring(image.Length - 4);
                else
                    extension = ".jpg";

                Result = String.Format("{0}_{1}{2}", Result, size, extension);

                return (Result);
            }
            catch 
            {
                return (image);
            }
        }

        /// <summary>
        /// Detects if any characters are right to left within a string
        /// </summary>
        /// <param name="s">string to check</param>
        /// <returns>true if any of the characters are right to left</returns>
        public static bool IsRightToLeftCharacter(string s)
        {
            return (Regex.IsMatch(s, @"\p{IsArabic}|\p{IsHebrew}"));
        }

        /// <summary>
        /// Shows a confirmation dialog box
        /// </summary>
        /// <param name="Title">Title</param>
        /// <param name="Message">Message / question being asked</param>
        /// <returns>true if user clicks Yes, otherwise false</returns>
        public static bool ShowHardConfirm(string Title, string Message)
        {
            return (MessageBox.Show(Message, Title, MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes);
        }

        /// <summary>
        /// Shows a question dialog box
        /// </summary>
        /// <param name="Title">Title</param>
        /// <param name="Message">Question being asked</param>
        /// <returns>True if user clicks Yes, otherwise false</returns>
        public static bool ShowQuestion(string Title, string Message)
        {
            return (MessageBox.Show(Message, Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes);
        }

        /// <summary>
        /// Shows an information dialog
        /// </summary>
        /// <param name="Title">Title for information</param>
        /// <param name="Message">Information message</param>
        public static void ShowInformation(string Title, string Message)
        {
            MessageBox.Show(Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Displays an error dialog
        /// </summary>
        /// <param name="Title">Title of error</param>
        /// <param name="Message">Error Message</param>
        public static void ShowError(string Title, string Message)
        {
            string msg = String.Format("An error has occured\r\r{0}\r\rPlease contact support", Message);
            MessageBox.Show(Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        /// <summary>
        /// Checks a value is at least Minimum
        /// </summary>
        /// <param name="Minimum">Minimum Height</param>
        /// <param name="Value">Value to be checked</param>
        /// <returns>int</returns>
        public static int MinimumValue(int Minimum, int Value)
        {
            if (Value < Minimum)
                return (Minimum);
            else
                return (Value);
        }

        public static string FormatPhoneNumber(string Telephone)
        {
            string Result = Telephone;

            if (Result.StartsWith("+"))
                Result.Replace("+", "");

            if (Result.StartsWith("44"))
                Result = "0" + Result.Substring(2);

            if (Result.StartsWith("07")) //mobile
                Result = Regex.Replace(Result, @"(\d{5})(\d{3})(\d{3})", "$1 $2$3");
            else //landline
                Result = Regex.Replace(Result, @"(\d{5})(\d{3})(\d{3})", "$1 $2 $3");

            return (Result);
        }

        /// <summary>
        /// Formats a date for a specific culture
        /// </summary>
        /// <param name="date">Date/Time to be formatted</param>
        /// <param name="culture">Culture to be used</param>
        /// <param name="dateFormat">date format to be used</param>
        /// <returns></returns>
        public static string FormatDate(DateTime date, string culture, string dateFormat = "g")
        {
            CultureInfo cultureInfo = new CultureInfo(culture);
            return (date.ToString(dateFormat, cultureInfo));
        }

        /// <summary>
        /// Determines wether the date falls within a number of days
        /// </summary>
        /// <param name="date"></param>
        /// <param name="Range"></param>
        /// <returns></returns>
        public static bool DateWithin(DateTime date, int Range)
        {
            DateTime check = new DateTime(DateTime.Now.Year, date.Month, date.Day);
            return (check >= DateTime.Now.AddDays(-Range) && check <= DateTime.Now.AddDays(Range));
        }

        public static bool DateWithin(DateTime dateStart, DateTime finishDate, DateTime checkDateStart, DateTime checkDateFinish)
        {
            bool Result = checkDateStart >= dateStart && checkDateStart <= finishDate;

            if (!Result)
                Result = checkDateFinish <= finishDate && checkDateFinish >= dateStart;

            return (Result);
        }

        public static string GetRandomPassword()
        {
            Random rnd = new Random(DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond);
            string AcceptableChars = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ.";
            string Result = "";

            for (int i = 0; i < 9; i++)
            {
                int ch = rnd.Next(AcceptableChars.Length - 1);
                Result += AcceptableChars.Substring(ch, 1);
            }

            return Result;
        }

        public static string GetRandomKey()
        {
            Random rnd = new Random(DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond);
            string Result = "";

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

        public static string GenerateRandomVoucherCode()
        {
            Random rnd = new Random(DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond);
            string Result = "HV";
            string codeFormat = "NNN-MLN-LL-DLL-NLN";

            foreach (char c in codeFormat)
            {
                switch (c)
                {
                    case 'L':
                        Result += (char)(byte)rnd.Next(65, 91);
                        break;
                    case 'N':
                        Result += Convert.ToString(rnd.Next(9));
                        break;
                    case 'S':
                        Result += DAL.DALHelper.StoreID.ToString();
                        break;
                    case '-':
                        Result += c;
                        break;
                    case 'D':
                        Result += DateTime.Now.ToString("dd");
                        break;

                    case 'Y':
                        Result += DateTime.Now.ToString("yy");
                        break;

                    case 'M':
                        Result += DateTime.Now.ToString("MM");
                        break;

                    default:
                        throw new Exception("Invalid Identifier whilst creating voucher code");
                }
            }

            return (Result);
        }

        public static string GetRandomDiscountCoupon()
        {
            Random rnd = new Random(DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond);
            string Result = "HC";
            string codeFormat = "LNN-YLN-LL-DLL-NLN-NN";
                                 
            foreach (char c in codeFormat)
            {
                switch (c)
                {
                    case 'L':
                        Result += (char)(byte)rnd.Next(65, 91);
                        break;

                    case 'N':
                        Result += Convert.ToString(rnd.Next(9));
                        break;

                    case 'D':
                        Result += DateTime.Now.ToString("dd");
                        break;

                    case 'Y':
                        Result += DateTime.Now.ToString("yy");
                        break;

                    default:
                        Result += c;
                        break;

                }
            }

            return (Result);
        }

        public static void IsStaffMember(User user)
        {
            if (user.MemberLevel < MemberLevel.StaffMember)
                throw new Exception("User does not have permission to continue.");
        }

        public static void CanUpdate(User user)
        {
            if (!user.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AllowSave))
                throw new Exception("User does not have permission to Update");
        }

        public static void CanCreate(User user)
        {
            if (!user.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AllowCreateNew))
                throw new Exception("User does not have permission to Create");
        }

        public static void CanDelete(User user)
        {
            if (!user.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AllowDelete))
                throw new Exception("User does not have permission to Delete");
        }

        #endregion Static Methods
    }
}
