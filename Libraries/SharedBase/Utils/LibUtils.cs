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
 *  File: LibUtils.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Globalization;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Reflection;

using SharedBase.BOL.Users;


using Shared.Classes;

#pragma warning disable IDE0018 // Variable declaration can be inlined

namespace SharedBase.Utils
{
    /// <summary>
    /// Summary description for Utils.
    /// </summary>
    public static class LibUtils
    {
        #region Public Methods

        public static string HTMLEncode(string s)
        {
            return (System.Web.HttpUtility.HtmlEncode(s));
        }

        public static string RemovePence(string s, CultureInfo culture)
        {
            string Result = s;
            string seperator = culture.NumberFormat.CurrencyDecimalSeparator;

            if (s.Contains(seperator))
                Result = s.Substring(0, s.IndexOf(seperator));

            return (Result);
        }

        /// <summary>
        /// Prepares an individual post for showing 
        /// </summary>
        /// <param name="S">Text to be processed</param>
        /// <returns>Processed Text</returns>
        public static string PreProcessPost(string S)
        {
            return (PreProcessPost("", S));
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

        public static string ReplaceHTMLElements(string S)
        {
            return (ReplaceHTMLElements(S, Shared.CaseType.Ignore));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public static string ReplaceHTMLElements(string S, Shared.CaseType ct)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentUICulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            string Result = BBCode.ReplaceHTMLElements(S);

            switch (ct)
            {
                case Shared.CaseType.Upper:
                    Result = textInfo.ToUpper(Result);
                    break;
                case Shared.CaseType.Lower:
                    Result = textInfo.ToLower(Result);
                    break;
                case Shared.CaseType.Proper:
                    Result = textInfo.ToTitleCase(Result);
                    break;
            }


            return (Result);
        }

        #endregion Public Methods

        #region Internal Methods


        #endregion Internal Methods

        #region Static Methods

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
                client.Timeout = 10000;
                string isValid = client.DownloadString(String.Format("http://www.sieradelta.com/Members/Installer/POSInstallValid.aspx?StoreID={0}",
                    storeID));

                Result = isValid.ToLower() != "false";
            }
            catch (Exception err)
            {
                if (err.Message.Contains("Request timed out"))
                {
                    Result = true;
                }
                else if (err.Message.Contains("Unable to connect to the remote server"))
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
                else if (err.Message.Contains("The underlying connection was closed"))
                {
                    Result = true;
                }
                else if (err.Message.Contains("The remote server returned an error"))
                {
                    Result = true;
                }
                else
                {
                    ErrorHandling.LogError(MethodBase.GetCurrentMethod(), err, storeID);
                    Result = false;
                }
            }

            return (Result);
        }


        public static Bitmap ResizeImage(Image image, int width, int height, bool stretch)
        {
            if (height == 0)
            {
                // resize but keep aspect ration based on width
                height = ResizeKeepAspect(new Size(image.Width, image.Height), width).Height;
            }

            Rectangle destRect;

            if (stretch)
                destRect = new Rectangle(0, 0, width, height);
            else
                destRect = new Rectangle(new Point(0, 0), ResizeKeepAspect(new Size(image.Width, image.Height), height));

            Bitmap destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (ImageAttributes wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);

                    if (stretch)
                    {
                        graphics.DrawImage(image, destRect, 0, 0, image.Width,
                          image.Height, GraphicsUnit.Pixel, wrapMode);
                    }
                    else
                    {
                        Bitmap currentImage = new Bitmap(image);
                        Color backGround = currentImage.GetPixel(currentImage.Width - 1,
                            currentImage.Height - 1);

                        using (SolidBrush brush = new SolidBrush(backGround))
                        {
                            graphics.FillRectangle(brush, new Rectangle(0, 0, width, height));
                            graphics.DrawImage(image, destRect, 0, 0, image.Width,
                              image.Height, GraphicsUnit.Pixel, wrapMode);
                        }
                    }
                }
            }

            return (destImage);
        }

        public static Size ResizeKeepAspect(Size src, int maxWidth)
        {
            double ratioW = (double)maxWidth / (double)src.Width;

            Size Result = new Size(Convert.ToInt32(src.Width * ratioW),
                Convert.ToInt32(src.Height * ratioW));

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

        public static string GenerateRandomVoucherCode(string prefix = "HV", string format = "NNN-MLN-LL-DLL-NLN", int randomAddition = 20)
        {
            Random rnd = new Random(DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + randomAddition);
            string Result = prefix;
            string codeFormat = format;

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
