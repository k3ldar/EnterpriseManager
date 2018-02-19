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
 *  File: MarketingPluginModule.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

using SharedControls.Forms;
using Languages;
using Library;
using POS.Base.Classes;
using POS.Base.Plugins;

namespace POS.Marketing
{
    public class MarketingPluginModule : BasePlugin
    {
        #region Private Members

        private CampaignsCard _campaignCard;

        private ToolStripSeparator _menuSeperator1;
        private ToolStripMenuItem _menuMarketing;
        private ToolStripMenuItem _menuCreateMarketingEmail;
        private ToolStripSeparator _menuSeperator2;
        private ToolStripMenuItem _menuRefreshMarketingFiles;

        #endregion Private Members

        #region Constructors

        public MarketingPluginModule(Form parent)
            : base(parent)
        {

        }

        #endregion Constructors

        #region Overridden Methods

        public override PluginVersion Version()
        {
            return (PluginVersion.Version1);
        }

        public override string PluginName()
        {
            return (LanguageStrings.AppPluginMarketing);
        }

        public override bool CanClose()
        {
            return (true);
        }

        public override bool CanUnload()
        {
            return (true);
        }

        public override void Unload()
        {
            // do nothing
        }

        public override bool BeforeLoad()
        {
            return (true);
        }


        public override void AfterLoad()
        {
            if (AppController.LocalSettings.UpdateMarketingFilesAtStart)
            {
                AppController.UpdateSplashScreen(LanguageStrings.AppDownloadMarketingFiles);
                DownloadMarketingFiles(false);
            }
        }

        public override void UpdateLanguage(CultureInfo culture)
        {
            _menuMarketing.Text = LanguageStrings.AppMenuMarketing;
            _menuCreateMarketingEmail.Text = LanguageStrings.AppMenuMarketingCreate;
            _menuRefreshMarketingFiles.Text = LanguageStrings.AppMenuMarketingUpdate;
        }

        public override void LoadAdministrationSettings(FormSettings settingsForm)
        {
            settingsForm.LoadControlOption(Languages.LanguageStrings.AppMarketing,
                Languages.LanguageStrings.AppMarketingSettings,
                null, new Controls.GeneralSettings());

            TreeNode parent = settingsForm.LoadControlOption(Languages.LanguageStrings.AppMassEmail,
                Languages.LanguageStrings.AppMassEmailSettings,
                null, new Controls.MassEmailSettings()); // marketing plugin

            settingsForm.LoadControlOption(Languages.LanguageStrings.AppMailChimp,
                Languages.LanguageStrings.AppMailChimpSettings,
                parent, new Controls.MailChimpSettings()); // marketing plugin
        }

        public override void LoadUserSettings(FormSettings settingsForm)
        {

        }

        public override void MenuAdd(PluginMenuType menuType, ToolStripMenuItem parentMenu)
        {
            switch (menuType)
            {
                case PluginMenuType.Tools:
                    CreateToolMenuItems(parentMenu);
                    break;
            }
        }

        public override void MenuAdd(PluginMenuType menuType, MenuStrip mainMenu)
        {

        }

        public override void MenuDropDown(PluginMenuType menuType)
        {

        }

        public override HomeCards HomeCards()
        {
            HomeCards Result = new HomeCards();

            if (_campaignCard == null)
                _campaignCard = new CampaignsCard(this);

            Result.Add(_campaignCard);

            return (Result);
        }

        #region Notification Items

        /// <summary>
        /// Retrieves Tray Notification Items
        /// </summary>
        /// <returns></returns>
        public override TrayNotificationCollection TrayNotifications()
        {
            return (null);
        }

        #endregion Notification Items

        #region Notification Events

        public override void Notification(NotificationEventArgs e)
        {
            base.Notification(e);

            switch (e.EventName)
            {
                default:
                    foreach (HomeCard card in HomeCards())
                    {
                        card.EventRaised(e);
                    }

                    break;
            }
        }

        public override void NotificationsGet(ref List<string> names)
        {
            base.NotificationsGet(ref names);

        }

        #endregion Notification Events

        #endregion Overridden Methods

        #region Private Methods

        private void CreateToolMenuItems(ToolStripMenuItem parent)
        {
            if (parent.HasDropDownItems)
            {
                _menuSeperator1 = new ToolStripSeparator();
                parent.DropDownItems.Add(_menuSeperator1);
            }

            _menuMarketing = new ToolStripMenuItem(LanguageStrings.AppMenuMarketing);
            parent.DropDownItems.Add(_menuMarketing);

            _menuCreateMarketingEmail = new ToolStripMenuItem(LanguageStrings.AppMenuMarketingCreate);
            _menuCreateMarketingEmail.Click += menuCreateMarketingEmail_Click;
            _menuMarketing.DropDownItems.Add(_menuCreateMarketingEmail);

            _menuSeperator2 = new ToolStripSeparator();
            _menuMarketing.DropDownItems.Add(_menuSeperator2);

            _menuRefreshMarketingFiles = new ToolStripMenuItem(LanguageStrings.AppMenuMarketingUpdate);
            _menuRefreshMarketingFiles.Click += menuRefreshMarketingFiles_Click;
            _menuMarketing.DropDownItems.Add(_menuRefreshMarketingFiles);
        }

        private void menuRefreshMarketingFiles_Click(object sender, EventArgs e)
        {
            DownloadMarketingFiles(true);
        }

        private void menuCreateMarketingEmail_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.SaveCampaigns))
            {
                Classes.MarketingEmail.Run();
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissionView,
                    LanguageStrings.AppPermissionCreateMarketingEmails),
                    LanguageStrings.AppErrorPermisions, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DownloadMarketingFiles(bool showComplete)
        {
            if (showComplete)
                ParentForm.Cursor = Cursors.WaitCursor;

            try
            {
                string path = AppController.POSFolder(FolderType.Marketing, true);

                Shared.FileDownload.Download(ConfigurationSettings.Value(ConfigurationSettings.SYSTEM_CONFIG_URL_MARKETING),
                    path + StringConstants.FILE_SETTINGS);

                Shared.FileDownload.Download(ConfigurationSettings.Value(ConfigurationSettings.SYSTEM_CONFIG_URL_MARKETING_TEMPLATES),
                    path + StringConstants.FILE_MARKETING_IMAGE_TEMPLATE);

                Shared.FileDownload.Download(ConfigurationSettings.Value(ConfigurationSettings.SYSTEM_CONFIG_URL_MARKETING_TEXT_COLOR),
                    path + StringConstants.FILE_MARKETING_IMAGE_COLOR);

                string xml = Shared.Utilities.CurrentPath(true) + StringConstants.FILE_MARKETING;

                int templateCount = Library.XML.GetXMLValue(
                    xml, StringConstants.XML_MARKETING, StringConstants.XML_MARKETING_TEMPLATES, 1);

                for (int i = 1; i <= templateCount; i++)
                {
                    string template = String.Format(StringConstants.XML_MARKETING_TEMPLATE, i);
                    string file = XML.GetXMLValue(xml, template, StringConstants.XML_MARKETING_FILENAME);
                    Shared.FileDownload.Download(XML.GetXMLValue(xml, template, StringConstants.XML_MARKETING_FILE),
                        path + Path.GetFileName(file));
                    Shared.FileDownload.Download(XML.GetXMLValue(xml, template, StringConstants.XML_MARKETING_THUMBNAIL).Replace(
                        StringConstants.FILE_EXTENSION_JPG, StringConstants.FILE_EXTENSION_EMAIL_HTM),
                        path + Path.GetFileName(Path.ChangeExtension(file, StringConstants.FILE_EXTENSION_EMAIL)));
                    Shared.FileDownload.Download(XML.GetXMLValue(xml, template, StringConstants.XML_MARKETING_THUMBNAIL),
                        path + Path.GetFileName(Path.ChangeExtension(file, StringConstants.FILE_EXTENSION_JPG)));
                }

                if (showComplete)
                {
                    ParentForm.Cursor = Cursors.Arrow;
                    MessageBox.Show(LanguageStrings.AppMarketingFilesUpdated,
                        LanguageStrings.AppMarketingFiles, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception err)
            {
                Library.ErrorHandling.LogError(MethodBase.GetCurrentMethod(), err);
            }
        }


        private void stockButton_POSBringToFront(object sender, EventArgs e)
        {
            base.OnRaiseBringToFront(EventArgs.Empty);
        }

        private void stockButton_PluginUsage(object sender, PluginUsageEventArgs e)
        {
            base.OnRaisePluginUsage(e);
        }

        #endregion Private Methods
    }
}
