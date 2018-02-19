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
 *  File: CreateEmailStep11.cs
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
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Languages;

using Library;
using Library.Utils;

using POS.Base.Classes;

namespace POS.Marketing.Controls
{
    public partial class CreateEmailStep11 :  EmailWizardBase
    {
        #region Private Members

        private EmailWizardSettings _settings;

        #endregion Private Members

        #region Constructors

        public CreateEmailStep11()
        {
            InitializeComponent();
        }

        public CreateEmailStep11(EmailWizardSettings settings)
        {
            InitializeComponent();
            _settings = settings;

            LoadSettings();
        }

        #endregion Constructors

        #region Overridden Methdos

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblHeader.Text = LanguageStrings.AppSocialMediaLinks;
            gbFaceBook.Text = LanguageStrings.AppSocailMediaFacebook;
            gbGPlus.Text = LanguageStrings.AppSocailMediaGPlus;
            gbRSSFeed.Text = LanguageStrings.AppSocailMediaRSSFeed;
            gbTwitter.Text = LanguageStrings.AppSocailMediaTwitter;
        }

        public override void LoadFromFile(string fileName)
        {
            txtFacebook.Text = XML.GetXMLValue(fileName, StringConstants.SETTINGS_STEP_6, StringConstants.SETTINGS_FACEBOOK);
            txtGPlus.Text = XML.GetXMLValue(fileName, StringConstants.SETTINGS_STEP_6, StringConstants.SETTINGS_GPLUS);
            txtRSS.Text = XML.GetXMLValue(fileName, StringConstants.SETTINGS_STEP_6, StringConstants.SETTINGS_RSS);
            txtTwitter.Text = XML.GetXMLValue(fileName, StringConstants.SETTINGS_STEP_6, StringConstants.SETTINGS_TWITTER);
        }

        public override void SaveToFile(string fileName)
        {
            XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_6, StringConstants.SETTINGS_FACEBOOK, txtFacebook.Text);
            XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_6, StringConstants.SETTINGS_GPLUS, txtGPlus.Text);
            XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_6, StringConstants.SETTINGS_RSS, txtRSS.Text);
            XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_6, StringConstants.SETTINGS_TWITTER, txtTwitter.Text);
        }

        public override bool SkipPage()
        {
            return (base.SkipPage());
        }

        public override bool NextClicked()
        {
            _settings.Facebook = txtFacebook.Text;
            _settings.Twitter = txtTwitter.Text;
            _settings.GPlus = txtGPlus.Text;
            _settings.RSSFeed = txtRSS.Text;

            return (true);
        }

        public override void PageShown()
        {
            txtFacebook.Text = _settings.Facebook;
            txtTwitter.Text = _settings.Twitter;
            txtGPlus.Text = _settings.GPlus;
            txtRSS.Text = _settings.RSSFeed;
            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.MarketingStep12;
        }

        public override bool PreviousClicked()
        {
                return (true);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadSettings()
        {
            
        }

        #endregion Private Methods
    }
}
