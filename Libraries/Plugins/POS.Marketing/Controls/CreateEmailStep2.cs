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
 *  Copyright (c) 2010 - 2019 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: CreateEmailStep2.cs
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

using SharedBase;
using SharedBase.Utils;

using Languages;
using POS.Base.Classes;

namespace POS.Marketing.Controls
{
    public partial class CreateEmailStep2 : EmailWizardBase
    {
        #region Private Members

        private EmailWizardSettings _settings;
        private int _strapLineLineCount;

        #endregion Private Members

        #region Constructors

        public CreateEmailStep2()
        {
            InitializeComponent();
        }

        public CreateEmailStep2(EmailWizardSettings settings)
        {
            InitializeComponent();
            _settings = settings;

            LoadSettings();
        }

        #endregion Constructors

        #region Overridden Methdos

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblHeader.Text = LanguageStrings.AppCampaignHeaderAndStrapLine;
            lblStrapLine.Text = LanguageStrings.AppCampaignStrapLine;
            lblTitle.Text = LanguageStrings.AppTitle;
        }

        public override bool SkipPage()
        {
            if (!XML.GetXMLValue(XMLFile(), _settings.Template, StringConstants.SETTINGS_ALLOW_SET_TITLE, true) &&
                !XML.GetXMLValue(XMLFile(), _settings.Template, StringConstants.SETTINGS_ALLOW_STRAP_LINE, true))
                return (true);

            return (base.SkipPage());
        }

        public override void LoadFromFile(string fileName)
        {
            txtStrapLine.Text = XML.GetXMLValue(fileName, StringConstants.SETTINGS_STEP_2, StringConstants.SETTINGS_STRAP_LINE);
            txtTitle.Text = XML.GetXMLValue(fileName, StringConstants.SETTINGS_STEP_2, StringConstants.SETTINGS_TITLE);
        }

        public override void SaveToFile(string fileName)
        {
            XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_2, StringConstants.SETTINGS_STRAP_LINE, txtStrapLine.Text);
            XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_2, StringConstants.SETTINGS_TITLE, txtTitle.Text);
        }

        public override bool NextClicked()
        {
            _settings.Title = txtTitle.Text;
            _settings.StrapLine = txtStrapLine.Text;

            if (txtTitle.Enabled && String.IsNullOrEmpty(txtTitle.Text))
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppCampaignEmailTitleError);
                return (false);
            }

            if (txtStrapLine.Enabled && String.IsNullOrEmpty(txtStrapLine.Text))
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppCampaignStrapLineError);
                return (false);
            }

            return base.NextClicked();
        }

        public override void PageShown()
        {
            LoadSettings();

            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.MarketingStep3;
        }

        public override bool PreviousClicked()
        {
            if (!String.IsNullOrEmpty(txtTitle.Text) || !String.IsNullOrEmpty(txtStrapLine.Text))
            {
                bool goBack = ShowHardConfirm(LanguageStrings.AppCampaignPreviousStep, LanguageStrings.AppCampaignPreviousStepPrompt);

                if (goBack)
                {
                    _settings.Title = String.Empty;
                    _settings.StrapLine = String.Empty;
                }

                return (goBack);
            }
            else
                return (true);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadSettings()
        {
            _strapLineLineCount = XML.GetXMLValue(XMLFile(), _settings.Template, StringConstants.SETTINGS_STRAP_LINE_COUNT, 5);

            txtTitle.Enabled = XML.GetXMLValue(XMLFile(), _settings.Template, StringConstants.SETTINGS_ALLOW_SET_TITLE, true);
            txtTitle.MaxLength = XML.GetXMLValue(XMLFile(), _settings.Template, StringConstants.SETTINGS_TITLE_LENGTH, 20);
            txtStrapLine.Enabled = XML.GetXMLValue(XMLFile(), _settings.Template, StringConstants.SETTINGS_ALLOW_STRAP_LINE, true);
            txtStrapLine.MaxLength = XML.GetXMLValue(XMLFile(), _settings.Template, StringConstants.SETTINGS_STRAP_LINE_LENGTH, 40);
            lblStrapLine.Visible = txtStrapLine.Enabled;
            txtStrapLine.Visible = txtStrapLine.Enabled;

            if (!String.IsNullOrEmpty(_settings.Title))
                txtTitle.Text = _settings.Title;

            if (!String.IsNullOrEmpty(_settings.StrapLine))
                txtStrapLine.Text = _settings.StrapLine;
        }

        #endregion Private Methods

        private void txtStrapLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                string[] lines = txtStrapLine.Text.Split(StringConstants.SYMBOL_RETURN_CHAR);

                if (lines.Length >= _strapLineLineCount)
                    e.SuppressKeyPress = true;
            }
        }
    }
}
