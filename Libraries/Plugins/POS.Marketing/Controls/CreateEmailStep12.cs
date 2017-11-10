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
 *  File: CreateEmailStep12.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;

using Library;
using Library.Utils;

using POS.Base.Classes;

namespace POS.Marketing.Controls
{
    public partial class CreateEmailStep12 :  EmailWizardBase
    {
        #region Private Members

        private EmailWizardSettings _settings;

        #endregion Private Members

        #region Constructors

        public CreateEmailStep12()
        {
            InitializeComponent();
        }

        public CreateEmailStep12(EmailWizardSettings settings)
        {
            InitializeComponent();
            _settings = settings;

            LoadSettings();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblMenuItems.Text = LanguageStrings.AppMenuItems;
            lblMenuName1.Text = LanguageStrings.Name;
            lblMenuName2.Text = LanguageStrings.Name;
            lblMenuName3.Text = LanguageStrings.Name;
            lblMenuName4.Text = LanguageStrings.Name;
            lblMenuName5.Text = LanguageStrings.Name;
            lblMenuURL1.Text = LanguageStrings.AppURL;
            lblMenuURL2.Text = LanguageStrings.AppURL;
            lblMenuURL3.Text = LanguageStrings.AppURL;
            lblMenuURL4.Text = LanguageStrings.AppURL;
            lblMenuURL5.Text = LanguageStrings.AppURL;
        }

        public override bool SkipPage()
        {
            return (base.SkipPage());
        }

        public override bool NextClicked()
        {
            try
            {
                AppController.LocalSettings.Menu1Name = SaveSettings(txtMenu1Name.Text, StringConstants.SETTINGS_MENU_NAME_1);
                AppController.LocalSettings.Menu1URL = SaveSettings(txtMenu1URL.Text, StringConstants.SETTINGS_MENU_URL_1);

                AppController.LocalSettings.Menu2Name = SaveSettings(txtMenu2Name.Text, StringConstants.SETTINGS_MENU_NAME_2);
                AppController.LocalSettings.Menu2URL = SaveSettings(txtMenu2URL.Text, StringConstants.SETTINGS_MENU_URL_2);

                AppController.LocalSettings.Menu3Name = SaveSettings(txtMenu3Name.Text, StringConstants.SETTINGS_MENU_NAME_3);
                AppController.LocalSettings.Menu3URL = SaveSettings(txtMenu3URL.Text, StringConstants.SETTINGS_MENU_URL_3);

                AppController.LocalSettings.Menu4Name = SaveSettings(txtMenu4Name.Text, StringConstants.SETTINGS_MENU_NAME_4);
                AppController.LocalSettings.Menu4URL = SaveSettings(txtMenu4URL.Text, StringConstants.SETTINGS_MENU_URL_4);

                AppController.LocalSettings.Menu5Name = SaveSettings(txtMenu5Name.Text, StringConstants.SETTINGS_MENU_NAME_5);
                AppController.LocalSettings.Menu5URL = SaveSettings(txtMenu5URL.Text, StringConstants.SETTINGS_MENU_URL_5);
            }
            catch
            {
                return (false);
            }

            return (true);
        }

        public override void PageShown()
        {
            LoadSettings();

            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.MarketingStep13;
        }

        public override bool PreviousClicked()
        {
                return (true);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadSettings()
        {
            txtMenu1Name.Text = AppController.LocalSettings.Menu1Name;
            txtMenu1URL.Text = AppController.LocalSettings.Menu1URL;

            txtMenu2Name.Text = AppController.LocalSettings.Menu2Name;
            txtMenu2URL.Text = AppController.LocalSettings.Menu2URL;

            txtMenu3Name.Text = AppController.LocalSettings.Menu3Name;
            txtMenu3URL.Text = AppController.LocalSettings.Menu3URL;

            txtMenu4Name.Text = AppController.LocalSettings.Menu4Name;
            txtMenu4URL.Text = AppController.LocalSettings.Menu4URL;

            txtMenu5Name.Text = AppController.LocalSettings.Menu5Name;
            txtMenu5URL.Text = AppController.LocalSettings.Menu5URL;
        }

        private string SaveSettings(string value, string name)
        {
            if (String.IsNullOrEmpty(value))
            {
                ShowError(name, String.Format(LanguageStrings.AppCampaignSaveValueEmpty, name));
                throw new Exception();
            }

            if (value.StartsWith(StringConstants.BASE_WEB_HTTP) || 
                value.StartsWith(StringConstants.BASE_WEB_HTTPS) || 
                value.StartsWith(StringConstants.BASE_WEB_WWW))
            {
                ShowError(name, String.Format(LanguageStrings.AppCampaignInvalidURL, name));
                throw new Exception(); ;
            }

            return (value);
        }

        #endregion Private Methods
    }
}
