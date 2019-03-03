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
 *  File: CreateEmailStep9.cs
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
    public partial class CreateEmailStep9 : EmailWizardBase
    {
        #region Private Members

        private EmailWizardSettings _settings;

        #endregion Private Members

        #region Constructors

        public CreateEmailStep9()
        {
            InitializeComponent();
        }

        public CreateEmailStep9(EmailWizardSettings settings)
        {
            InitializeComponent();
            _settings = settings;

            LoadSettings();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblHeader.Text = LanguageStrings.AppCampaignSubTextHeader;

            btnSelectColor.Text = LanguageStrings.AppMenuButtonSelectColor;
        }

        public override void LoadFromFile(string fileName)
        {
            _settings.SubTextColor = Color.FromArgb(
                XML.GetXMLValue(fileName, StringConstants.SETTINGS_STEP_3A, StringConstants.SETTINGS_COLOR_R, 128),
                XML.GetXMLValue(fileName, StringConstants.SETTINGS_STEP_3A, StringConstants.SETTINGS_COLOR_G, 128),
                XML.GetXMLValue(fileName, StringConstants.SETTINGS_STEP_3A, StringConstants.SETTINGS_COLOR_B, 128));

            _settings.SubText = XML.GetXMLValue(fileName, StringConstants.SETTINGS_STEP_3A, StringConstants.SETTINGS_SUB_TEXT);
            txtSubText.Text = _settings.SubText;
        }

public override void SaveToFile(string fileName)
{
    XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_3A, StringConstants.SETTINGS_COLOR_R, _settings.SubTextColor.R.ToString());
    XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_3A, StringConstants.SETTINGS_COLOR_G, _settings.SubTextColor.G.ToString());
    XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_3A, StringConstants.SETTINGS_COLOR_B, _settings.SubTextColor.B.ToString());
    XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_3A, StringConstants.SETTINGS_SUB_TEXT, txtSubText.Text);
}

        public override bool SkipPage()
        {
            bool allowSubText = XML.GetXMLValue(XMLFile(), _settings.Template, StringConstants.SETTINGS_SUB_TEXT_ALLOW, false);

            return (!allowSubText);
        }

        public override bool NextClicked()
        {
            _settings.SubText = txtSubText.Text;
            _settings.SubTextColor = colorDialog1.Color;
            return base.NextClicked();
        }

        public override void PageShown()
        {
            colorDialog1.CustomColors = AppController.LocalSettings.CustomColors;
            txtSubText.Text = _settings.SubText;
            txtSubText.ForeColor = _settings.SubTextColor;
            colorDialog1.Color = _settings.SubTextColor;

            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.MarketingStep10;
        }

        public override bool PreviousClicked()
        {
            return (true);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadSettings()
        {
            colorDialog1.Color = _settings.TextColor;
        }

        private void btnSelectColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                AppController.LocalSettings.CustomColors = colorDialog1.CustomColors;
                _settings.TextColor = colorDialog1.Color;
            }

            txtSubText.ForeColor = _settings.TextColor;
        }

        #endregion Private Methods
    }
}
