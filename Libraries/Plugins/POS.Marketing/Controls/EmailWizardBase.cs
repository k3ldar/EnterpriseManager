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
 *  File: EmailWizardBase.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Drawing;

using Languages;

using Shared.Classes;
using Library;
using Library.BOL.Mail;
using Library.BOL.Campaigns;
using Library.BOL.Websites;

using POS.Base.Classes;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation

namespace POS.Marketing.Controls
{
    public class EmailWizardBase : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private bool _filesUploaded = false;

        #endregion Private Members

        #region Internal Static Methods

        internal static string CurrentPath()
        {
            string Result = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            Result = System.IO.Path.GetDirectoryName(Result);
            return (Result.Substring(6));
        }

        internal static string XMLFile(bool marketing = true)
        {
            if (marketing)
                return (Shared.Utilities.AddTrailingBackSlash(CurrentPath()) + StringConstants.FILE_MARKETING);
            else
                return (Shared.Utilities.AddTrailingBackSlash(CurrentPath()) + StringConstants.FILE_MARKETING_IMAGE_STYLE);
        }

        #endregion Internal Static Methods

        #region Overridden Methods

        #endregion Overridden Methdos

        #region Virtual Methods
        #endregion Virtual Methods

        #region Public Methods

        public string GenerateEmailForCampaign(EmailWizardSettings settings)
        {
            if (!_filesUploaded)
                UploadToServer(settings);

            return (GenerateEmail(settings));
        }


        public bool SendTestEmail(EmailWizardSettings settings)
        {
            bool Result = false;

            if (!_filesUploaded)
                UploadToServer(settings);

            EmailMessage _emailClass = new EmailMessage();
            try
            {
                string message = GenerateEmail(settings);

                // Create new Email Object

                // Set SMTP Sever Settings
                _emailClass.SMTPServerName = AppController.LocalSettings.EmailServer;
                _emailClass.SMTPServerPort = AppController.LocalSettings.EmailPort;
                _emailClass.SMTPUserName = AppController.LocalSettings.EmailUser; 
                _emailClass.SMTPUserPassword = AppController.LocalSettings.EmailPassword;
                _emailClass.SMTPSSL = AppController.LocalSettings.EmailSSL; 
                _emailClass.MaximumSendAttempts = 1;


                Result = _emailClass.Send(_emailClass.SMTPUserName, _emailClass.SMTPUserName,
                    AppController.ActiveUser.UserName, AppController.ActiveUser.Email,
                    String.Format(LanguageStrings.AppCampaignTestEmailTitle, settings.CampaignName), message);
            }
            catch (Exception err)
            {
                ShowError(LanguageStrings.AppError, err.Message);
                Result = false;
            }
            finally
            {
                _emailClass = null;
            }

            return (Result);
        }

        public string UploadToServer(EmailWizardSettings settings)
        {
            string Result = String.Empty;

            DoUploadStart();
            try
            {
                Website site = Websites.Get(settings.URL);

                if (site == null)
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppCampaignURLError);
                    return (String.Empty);
                }

                ftp ftpServer = new ftp(site.FtpHost, site.FtpUserName, site.FtpPassword, 2048, true, true, true, site.FtpPort);
                try
                {
                    int totalAdditionalImages = XML.GetXMLValue(XMLFile(), settings.Template, StringConstants.SETTINGS_ADDITIONAL_PRODUCTS, 0);

                    string location = site.RootPath + GetRemoteLocation(settings);
                    int currentFile = 1;

                    ftpServer.CreateDirectory(location);

                    DoUploadFile(GetRemoteImageName(settings), totalAdditionalImages + 2, currentFile);
                    ftpServer.Upload(location + GetRemoteImageName(settings), settings.ImageFile);
                    currentFile++;

                    // secondary images
                    if (!String.IsNullOrEmpty(settings.SecondaryImageFile))
                    {
                        DoUploadFile(GetRemoteSecondaryImageName(settings), totalAdditionalImages + 2, currentFile);
                        ftpServer.Upload(location + GetRemoteSecondaryImageName(settings), settings.SecondaryImageFile);
                    }

                    // additional products
                    for (int i = 1; i <= totalAdditionalImages; i++)
                    {
                        DoUploadFile(GetRemoteImageName(settings), totalAdditionalImages + 2, i + 1);
                        ftpServer.Upload(location + GetRemoteImageName(settings, i), settings[i].Image);
                    }

                    string fileLocation = Shared.Utilities.AddTrailingBackSlash(CurrentPath()) + 
                        StringConstants.FOLDER_MARKETING_PREVIEW;

                    if (!System.IO.Directory.Exists(fileLocation))
                        System.IO.Directory.CreateDirectory(fileLocation);

                    string htmlFile = GenerateWebPage(settings, fileLocation);
                    DoUploadFile(System.IO.Path.GetFileName(fileLocation), totalAdditionalImages + 2, totalAdditionalImages + 2);
                    ftpServer.Upload(String.Format(StringConstants.FILE_UPLOAD_HTML, location, settings.CampaignName), htmlFile);
                    System.IO.File.Delete(htmlFile);

                    Result = String.Format(StringConstants.FILE_UPLOAD_HTML, GetOnlineImageLocation(settings), settings.CampaignName);

                    _filesUploaded = true;
                }
                catch (Exception err)
                {
                    ShowError(LanguageStrings.AppError, err.Message);
                }
                finally
                {
                    ftpServer = null;
                }
            }
            finally
            {
                DoUploadFinish();
            }

            return (Result);
        }

        #endregion Public Methods

        #region Properties

        public bool FilesUploaded
        {
            get
            {
                return (_filesUploaded);
            }
        }

        #endregion Properties

        #region Private Methods

        /// <summary>
        /// Generates a web page from a template file
        /// </summary>
        /// <param name="fileLocation"></param>
        /// <param name="showInBrowser"></param>
        /// <returns></returns>
        private string GenerateWebPage(EmailWizardSettings settings, string fileLocation)
        {
            string Result = String.Format(StringConstants.SETTINGS_CAMPAIGN_ONLINE_PREVIEW, fileLocation,
                DateTime.Now.ToString(StringConstants.SYMBOL_DATE_FORMAT_G).Replace(StringConstants.SYMBOL_FORWARD_SLASH, 
                StringConstants.SYMBOL_HYPHEN).Replace(StringConstants.SYMBOL_COLON, StringConstants.SYMBOL_HYPHEN));

            string templateText = System.IO.File.ReadAllText(settings.TemplateFile);


            //replace all replaceable elements
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_BASE_URL, settings.URL);
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_BASE_URL_SHORT, 
                settings.URL.Replace(StringConstants.BASE_WEB_HTTP, String.Empty));
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_HEADER, settings.Title);
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_STRAPLINE, 
                settings.StrapLine.Replace(StringConstants.SYMBOL_CRLF, StringConstants.SETTINGS_CAMPAIGN_HTML_BR));
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_CAMPAIGN, settings.CampaignName);
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_HEADER_COLOR, 
                String.Format(StringConstants.SETTINGS_CAMPAIGN_HTML_RGB,
                settings.TextColor.R.ToString(), settings.TextColor.G.ToString(), settings.TextColor.B.ToString()));

            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_COMPANY_NAME,
                AppController.LocalSettings.BusinessName);
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_CAMPAIGN_EMAIL,
                settings.CampaignEmail);

            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_MENU_URL_1, AppController.LocalSettings.Menu1URL);
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_MENU_NAME_1, AppController.LocalSettings.Menu1Name);

            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_MENU_URL_2, AppController.LocalSettings.Menu2URL);
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_MENU_NAME_2, AppController.LocalSettings.Menu2Name);

            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_MENU_URL_3, AppController.LocalSettings.Menu3URL);
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_MENU_NAME_3, AppController.LocalSettings.Menu3Name);

            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_MENU_URL_4, AppController.LocalSettings.Menu4URL);
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_MENU_NAME_4, AppController.LocalSettings.Menu4Name);

            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_MENU_URL_5, AppController.LocalSettings.Menu5URL);
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_MENU_NAME_5, AppController.LocalSettings.Menu5Name);

            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_MAIN_IMAGE, String.Format(StringConstants.PREFIX_AND_SUFFIX_SLASH, GetOnlineImageLocation(settings), GetRemoteImageName(settings)));
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_MAIN_IMAGE_LINK, settings.ImageFileLink);

            if (settings.ImageFileLink.ToLower().StartsWith(StringConstants.BASE_WEB_HTTP) ||
                settings.ImageFileLink.ToLower().StartsWith(StringConstants.BASE_WEB_HTTPS))
            {
                ReplaceText(ref templateText, settings.URL + settings.ImageFileLink, settings.ImageFileLink);
            }

        

            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_SECONDARY_IMAGE, String.Format(StringConstants.PREFIX_AND_SUFFIX_SLASH, GetOnlineImageLocation(settings), GetRemoteSecondaryImageName(settings)));
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_SECONDARY_IMAGE_LINK, settings.SecondaryImageFileLink);

            // additional products
            int totalAdditionalImages = XML.GetXMLValue(XMLFile(), settings.Template, StringConstants.SETTINGS_ADDITIONAL_PRODUCTS, 0);

            for (int i = 1; i <= totalAdditionalImages; i++)
            {
                ReplaceText(ref templateText, String.Format(StringConstants.SETTINGS_CAMPAIGN_PRODUCT_IMAGE, i), String.Format(StringConstants.PREFIX_AND_SUFFIX_SLASH, GetOnlineImageLocation(settings), GetRemoteImageName(settings, i)));
                ReplaceText(ref templateText, String.Format(StringConstants.SETTINGS_CAMPAIGN_PRODUCT_URL, i), settings[i].URL);
                ReplaceText(ref templateText, String.Format(StringConstants.SETTINGS_CAMPAIGN_PRODUCT_NAME, i), settings[i].Title);
                ReplaceText(ref templateText, String.Format(StringConstants.SETTINGS_CAMPAIGN_PRODUCT_DESCRIPTION, i), settings[i].Description.Replace(StringConstants.SYMBOL_CRLF, StringConstants.SETTINGS_CAMPAIGN_HTML_BR));
            }

            //sub text
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_SUBTEXT_COLOR, String.Format(StringConstants.SETTINGS_CAMPAIGN_HTML_RGB,
                settings.SubTextColor.R.ToString(), settings.SubTextColor.G.ToString(), settings.SubTextColor.B.ToString()));
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_SUBTEXT, settings.SubText.Replace(StringConstants.SYMBOL_CRLF, StringConstants.SETTINGS_CAMPAIGN_HTML_BR));

            //social feeds
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_SOCIAL_RSS, 
                String.IsNullOrEmpty(settings.RSSFeed) ? String.Empty : settings.RSSFeed);
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_SOCIAL_G_PLUS,
                String.IsNullOrEmpty(settings.GPlus) ? String.Empty : settings.GPlus);
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_SOCIAL_TWITTER,
                String.IsNullOrEmpty(settings.Twitter) ? String.Empty : settings.Twitter);
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_SOCIAL_FACEBOOK,
                String.IsNullOrEmpty(settings.Facebook) ? String.Empty : settings.Facebook);
            
            
            templateText = templateText.Replace(StringConstants.SETTINGS_CAMPAIGN_TEMPLATE_STYLE_DEFAULT,
                String.Format(StringConstants.SETTINGS_CAMPAIGN_TEMPLATE_STYLE_SELECTED,
                settings.ImageTemplate));

            string newColor = XML.GetXMLValue(XMLFile(false),
                Shared.Utilities.ProperCase(settings.ImageTemplate), StringConstants.XML_MARKETING_COLOR);
            string newBackColor = XML.GetXMLValue(XMLFile(false),
                Shared.Utilities.ProperCase(settings.ImageTemplate), StringConstants.XML_MARKETING_BACK_COLOR);

            templateText = templateText.Replace(StringConstants.SETTINGS_CAMPAIGN_TEMPLATE_TEXT_COLOR,
                String.Format(StringConstants.SETTINGS_CAMPAIGN_TEMPLATE_TEXT_COLOR_SET, newColor));
            templateText = templateText.Replace(StringConstants.SETTINGS_CAMPAIGN_TEMPLATE_BACK_COLOR,
                newBackColor);

            System.IO.File.AppendAllText(Result, templateText);

            return (Result);
        }

        private string GenerateEmail(EmailWizardSettings settings)
        {
            string Result = String.Empty;

            string templateText = System.IO.File.ReadAllText(settings.TemplateFile.Replace(
                StringConstants.FILE_EXTENSION_HTML, StringConstants.FILE_EXTENSION_EMAIL));


            //replace all replaceable elements
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_VIEW_ONLINE, String.Format(
                StringConstants.FILE_UPLOAD_HTML, GetOnlineImageLocation(settings), settings.CampaignName));
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_BASE_URL, settings.URL);
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_BASE_URL_SHORT,
                settings.URL.Replace(StringConstants.BASE_WEB_HTTP, String.Empty));
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_HEADER, settings.Title);
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_STRAPLINE, 
                settings.StrapLine.Replace(StringConstants.SYMBOL_CRLF, 
                StringConstants.SETTINGS_CAMPAIGN_HTML_BR));
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_CAMPAIGN, settings.CampaignName);
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_HEADER_COLOR, 
                String.Format(StringConstants.SETTINGS_CAMPAIGN_HTML_RGB,
                settings.TextColor.R.ToString(), settings.TextColor.G.ToString(), 
                settings.TextColor.B.ToString()));

            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_COMPANY_NAME,
                AppController.LocalSettings.BusinessName);
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_CAMPAIGN_EMAIL,
                settings.CampaignEmail);

            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_MENU_URL_1, AppController.LocalSettings.Menu1URL);
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_MENU_NAME_1, AppController.LocalSettings.Menu1Name);

            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_MENU_URL_2, AppController.LocalSettings.Menu2URL);
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_MENU_NAME_2, AppController.LocalSettings.Menu2Name);

            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_MENU_URL_3, AppController.LocalSettings.Menu3URL);
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_MENU_NAME_3, AppController.LocalSettings.Menu3Name);

            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_MENU_URL_4, AppController.LocalSettings.Menu4URL);
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_MENU_NAME_4, AppController.LocalSettings.Menu4Name);

            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_MENU_URL_5, AppController.LocalSettings.Menu5URL);
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_MENU_NAME_5, AppController.LocalSettings.Menu5Name);

            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_MAIN_IMAGE, 
                String.Format(StringConstants.PREFIX_AND_SUFFIX_SLASH, 
                GetOnlineImageLocation(settings), GetRemoteImageName(settings)));

            if (settings.CustomImageLink)
            {
                ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_MAIN_IMAGE_LINK, settings.ImageFileLink);


                if (settings.ImageFileLink.ToLower().StartsWith(StringConstants.BASE_WEB_HTTP) ||
                    settings.ImageFileLink.ToLower().StartsWith(StringConstants.BASE_WEB_HTTPS))
                {
                    ReplaceText(ref templateText, settings.URL + settings.ImageFileLink, settings.ImageFileLink);
                }

            }
            else
            {
                ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_MAIN_IMAGE_LINK,
                    StringConstants.SETTINGS_CAMPAIGN_ONLINE_TRACKING_LINK + settings.CampaignName);
            }

            // secondary image
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_SECONDARY_IMAGE, String.Format(StringConstants.PREFIX_AND_SUFFIX_SLASH, GetOnlineImageLocation(settings), GetRemoteSecondaryImageName(settings)));
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_SECONDARY_IMAGE_LINK, settings.SecondaryImageFileLink);

            // additional products
            int totalAdditionalImages = XML.GetXMLValue(XMLFile(), settings.Template, 
                StringConstants.SETTINGS_ADDITIONAL_PRODUCTS, 0);

            for (int i = 1; i <= totalAdditionalImages; i++)
            {
                ReplaceText(ref templateText, String.Format(StringConstants.SETTINGS_CAMPAIGN_PRODUCT_IMAGE, i), 
                    String.Format(StringConstants.PREFIX_AND_SUFFIX_SLASH, GetOnlineImageLocation(settings), 
                    GetRemoteImageName(settings, i)));
                ReplaceText(ref templateText, String.Format(StringConstants.SETTINGS_CAMPAIGN_PRODUCT_URL, i), settings[i].URL);
                ReplaceText(ref templateText, String.Format(StringConstants.SETTINGS_CAMPAIGN_PRODUCT_NAME, i), settings[i].Title);
                ReplaceText(ref templateText, String.Format(StringConstants.SETTINGS_CAMPAIGN_PRODUCT_DESCRIPTION, i), 
                    settings[i].Description.Replace(StringConstants.SYMBOL_CRLF, StringConstants.SETTINGS_CAMPAIGN_HTML_BR));
            }

            //sub text
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_SUBTEXT_COLOR, 
                String.Format(StringConstants.SETTINGS_CAMPAIGN_HTML_RGB,
                settings.SubTextColor.R.ToString(), settings.SubTextColor.G.ToString(), 
                settings.SubTextColor.B.ToString()));
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_SUBTEXT, 
                settings.SubText.Replace(StringConstants.SYMBOL_CRLF, 
                StringConstants.SETTINGS_CAMPAIGN_HTML_BR));

            //social feeds
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_SOCIAL_RSS,
                String.IsNullOrEmpty(settings.RSSFeed) ? String.Empty : settings.RSSFeed);
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_SOCIAL_G_PLUS,
                String.IsNullOrEmpty(settings.GPlus) ? String.Empty : settings.GPlus);
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_SOCIAL_TWITTER,
                String.IsNullOrEmpty(settings.Twitter) ? String.Empty : settings.Twitter);
            ReplaceText(ref templateText, StringConstants.SETTINGS_CAMPAIGN_SOCIAL_FACEBOOK,
                String.IsNullOrEmpty(settings.Facebook) ? String.Empty : settings.Facebook);

            templateText = templateText.Replace(StringConstants.SETTINGS_CAMPAIGN_TEMPLATE_STYLE_DEFAULT,
                String.Format(StringConstants.SETTINGS_CAMPAIGN_TEMPLATE_STYLE_SELECTED,
                settings.ImageTemplate));



            string newColor = XML.GetXMLValue(XMLFile(false),
                Shared.Utilities.ProperCase(settings.ImageTemplate), StringConstants.XML_MARKETING_COLOR);
            string newBackColor = XML.GetXMLValue(XMLFile(false),
                Shared.Utilities.ProperCase(settings.ImageTemplate), StringConstants.XML_MARKETING_BACK_COLOR);

            templateText = templateText.Replace(StringConstants.SETTINGS_CAMPAIGN_TEMPLATE_TEXT_COLOR,
                String.Format(StringConstants.SETTINGS_CAMPAIGN_TEMPLATE_TEXT_COLOR_SET, newColor));
            Result = templateText.Replace(StringConstants.SETTINGS_CAMPAIGN_TEMPLATE_BACK_COLOR,
                newBackColor);

            return (Result);
        }

        private string GetOnlineImageLocation(EmailWizardSettings settings)
        {
            return (String.Format(StringConstants.SETTINGS_CAMPAIGN_ONLINE_IMAGE_LOCATION, 
                settings.URL, 
                settings.CampaignName,
                Library.DAL.DALHelper.StoreID));
        }

        private string GetRemoteLocation(EmailWizardSettings settings)
        {
            return (String.Format(StringConstants.SETTINGS_CAMPAIGN_ONLINE_IMAGE_LOCATION,
                settings.URL.Replace(StringConstants.BASE_WEB_HTTP, String.Empty).Replace(StringConstants.BASE_WEB_WWW, String.Empty), 
                settings.CampaignName,
                Library.DAL.DALHelper.StoreID));
        }

        private string GetRemoteImageName(EmailWizardSettings settings)
        {
            string Result = Shared.Validation.Validate(System.IO.Path.GetFileName(settings.ImageFile), 
                Shared.ValidationTypes.FileName);

            return (Result);
        }

        private string GetRemoteSecondaryImageName(EmailWizardSettings settings)
        {
            if (String.IsNullOrEmpty(settings.SecondaryImageFile))
                return (String.Empty);

            string Result = Shared.Validation.Validate(System.IO.Path.GetFileName(settings.SecondaryImageFile),
                Shared.ValidationTypes.FileName);

            return (Result);
        }

        private string GetRemoteImageName(EmailWizardSettings settings, int additionalProduct)
        {
            string Result = Shared.Validation.Validate(System.IO.Path.GetFileName(
                settings[additionalProduct].Image), Shared.ValidationTypes.FileName);

            return (Result);
        }

        private void ReplaceText(ref string text, string findText, string replaceWith)
        {
            text = text.Replace(findText, replaceWith);
        }

        #region Event Wrappers

        private void DoUploadFile(string fileName, int totalFiles, int currentFile)
        {
            if (OnUploadFile != null)
                OnUploadFile(this, new UploadFileArgs(fileName, totalFiles, currentFile));
        }

        private void DoUploadStart()
        {
            if (OnUploadStart != null)
                OnUploadStart(this, EventArgs.Empty);
        }

        private void DoUploadFinish()
        {
            if (OnUploadFinish != null)
                OnUploadFinish(this, EventArgs.Empty);
        }

        #endregion Event Wrappers

        #endregion Private Methods

        #region Event Handlers

        public event UploadFileHandler OnUploadFile;

        public event EventHandler OnUploadStart;

        public event EventHandler OnUploadFinish;

        #endregion Event Handlers
    }

    public class AdditionalProduct
    {
        public string Title { get; set; }


        public string Description { get; set; }


        public string Image { get; set; }


        public string URL { get; set; }
    }

    public class UploadFileArgs
    {
        public UploadFileArgs(string fileName, int totalFiles, int currentFile) { FileName = fileName; TotalFiles = totalFiles; CurrentFile = currentFile; }

        public string FileName { get; private set; }

        public int TotalFiles { get; private set; }

        public int CurrentFile { get; private set; }
    }

    public delegate void UploadFileHandler(object sender, UploadFileArgs e);

    internal class EmailTemplateClass
    {
        internal EmailTemplateClass(string fileName, string templateName, int index)
        {
            FileName = fileName;
            TemplateName = templateName;
            Index = index;
        }

        internal string FileName { get; set; }

        internal string TemplateName { get; set; }

        internal int Index { get; set; }
    }

    public class EmailWizardSettings
    {
        #region Private Members

        private Dictionary<int, AdditionalProduct> _additionalProducts = new Dictionary<int, AdditionalProduct>();

        #endregion Private Members

        #region Constructor

        public EmailWizardSettings()
        {
            ProductCost1 = -1;
            ProductCost2 = -1;
            ProductCost3 = -1;

            Title = String.Empty;
            SubText = String.Empty;
            StrapLine = String.Empty;
            TextColor = Color.White;
            ImageFile = String.Empty;
            CampaignName = StringConstants.SETTINGS_CAMPAIGN_CAMPAIGN;
            URL = AppController.LocalSettings.MarketingURL;

            Facebook = AppController.LocalSettings.Facebook;
            Twitter = AppController.LocalSettings.Twitter;
            GPlus = AppController.LocalSettings.GPlus;
            RSSFeed = AppController.LocalSettings.RSSFeed;

            // max of 9 additional products
            for (int i = 1; i < 10; i++)
                _additionalProducts.Add(i, new AdditionalProduct());

            //ImageTemplate = StringConstants.SETTINGS_TEMPLATE.ToLower() + StringConstants.SYMBOL_ONE;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Name of the campaign
        /// </summary>
        public string CampaignName { get; set; }

        /// <summary>
        /// Tracking Code
        /// </summary>
        public string TrackingCode { get; set; }

        /// <summary>
        /// Base URL for email links
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// Reply email address for campaign
        /// </summary>
        public string CampaignEmail { get; set; }

        /// <summary>
        /// Return an additional product
        /// </summary>
        /// <param name="Index">Index of product, must be a value between 1 and 9 (</param>
        /// <returns>AdditionalProduct object</returns>
        public AdditionalProduct this[int Index]
        {
            get
            {
                return (_additionalProducts[Index]);
            }
        }

        /// <summary>
        /// Name of template file
        /// </summary>
        public string Template { get; set; }

        /// <summary>
        /// Template File
        /// </summary>
        public string TemplateFile { get; set; }

        /// <summary>
        /// Email Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Strap line for email
        /// </summary>
        public string StrapLine { get; set; }

        /// <summary>
        /// Color of text within the email
        /// </summary>
        public Color TextColor { get; set; }

        /// <summary>
        /// Main image file for use within the email
        /// </summary>
        public string ImageFile { get; set; }

        /// <summary>
        /// Link for the image File
        /// </summary>
        public string ImageFileLink { get; set; }

        /// <summary>
        /// Main image file for use within the email
        /// </summary>
        public string SecondaryImageFile { get; set; }

        /// <summary>
        /// Link for the image File
        /// </summary>
        public string SecondaryImageFileLink { get; set; }

        /// <summary>
        /// Image to be displayed on home page
        /// </summary>
        public string HomeImageFile { get; set; }

        /// <summary>
        /// Link for home page image
        /// </summary>
        public string HomeImageLink { get; set; }

        /// <summary>
        /// Image to be displayed on left of each page
        /// </summary>
        public string PageImageFile { get; set; }

        /// <summary>
        /// Link for image to be displayed on left of each page
        /// </summary>
        public string PageImageLink { get; set; }

        /// <summary>
        /// Determines wether a custom link is used, or the standard campaign manager
        /// </summary>
        public bool CustomImageLink { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Facebook { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Twitter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string GPlus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RSSFeed { get; set; }

        /// <summary>
        /// Campaign associated with this wizard
        /// </summary>
        public Campaign Campaign { get; set; }

        /// <summary>
        /// Sub text used to go below image
        /// </summary>
        public string SubText { get; set; }

        /// <summary>
        /// Color of subtext
        /// </summary>
        public Color SubTextColor { get; set; }


        public Int64 ProductCost1 { get; set; }


        public Int64 ProductCost2 { get; set; }


        public Int64 ProductCost3 { get; set; }


        public Int64 ProductCost4 { get; set; }


        public Int64 ProductCost5 { get; set; }


        public Int64 ProductCost6 { get; set; }

        /// <summary>
        /// Image template set to be used
        /// </summary>
        public string ImageTemplate { get; set; }

        /// <summary>
        /// Text color for template
        /// </summary>
        public string ImageTemplateColor { get; set; }

        #endregion Properties

    }
}
