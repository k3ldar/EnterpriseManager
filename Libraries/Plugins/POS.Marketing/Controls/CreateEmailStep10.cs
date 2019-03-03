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
 *  File: CreateEmailStep10.cs
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
    public partial class CreateEmailStep10 :  EmailWizardBase
    {
        #region Private Members

        private EmailWizardSettings _settings;
        private int _additionalProductNumber;

        #endregion Private Members

        #region Constructors

        public CreateEmailStep10()
        {
            InitializeComponent();
        }

        public CreateEmailStep10(EmailWizardSettings settings, int additionalProduct)
        {
            InitializeComponent();
            _settings = settings;
            _additionalProductNumber = additionalProduct;
            lblHeader.Text = String.Format(LanguageStrings.AppCampaignAdditionalProduct, additionalProduct);
            LoadSettings();
        }

        #endregion Constructors

        #region Overridden Methdos

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblDescription.Text = LanguageStrings.Description;
            lblURL.Text = LanguageStrings.AppURL;
            lblTitle.Text = LanguageStrings.AppTitle;

            gbImage.Text = LanguageStrings.AppPicture;
        }

        public override void LoadFromFile(string fileName)
        {
            txtDescription.Text = XML.GetXMLValue(fileName, String.Format(StringConstants.SETTINGS_STEP_5,
                _additionalProductNumber), StringConstants.SETTINGS_DESCRIPTION);
            txtTitle.Text = XML.GetXMLValue(fileName, String.Format(StringConstants.SETTINGS_STEP_5, 
                _additionalProductNumber), StringConstants.SETTINGS_TITLE);
            txtURL.Text = XML.GetXMLValue(fileName, String.Format(StringConstants.SETTINGS_STEP_5,
                _additionalProductNumber), StringConstants.SETTINGS_URL);
            _settings[_additionalProductNumber].Image = XML.GetXMLValue(fileName, 
                String.Format(StringConstants.SETTINGS_STEP_5, _additionalProductNumber),
                 StringConstants.SETTINGS_IMAGE);

            if (System.IO.File.Exists(_settings[_additionalProductNumber].Image))
                LoadImage();
        }

        public override void SaveToFile(string fileName)
        {
            XML.SetXMLValue(fileName, String.Format(StringConstants.SETTINGS_STEP_5,
                _additionalProductNumber), StringConstants.SETTINGS_DESCRIPTION, txtDescription.Text);
            XML.SetXMLValue(fileName, String.Format(StringConstants.SETTINGS_STEP_5,
                _additionalProductNumber), StringConstants.SETTINGS_TITLE, txtTitle.Text);
            XML.SetXMLValue(fileName, String.Format(StringConstants.SETTINGS_STEP_5,
                _additionalProductNumber), StringConstants.SETTINGS_URL, txtURL.Text);
            XML.SetXMLValue(fileName, String.Format(StringConstants.SETTINGS_STEP_5, 
                _additionalProductNumber), StringConstants.SETTINGS_IMAGE, _settings[_additionalProductNumber].Image);
        }

        public override bool SkipPage()
        {
            int totalAdditionalImages = XML.GetXMLValue(XMLFile(), _settings.Template, StringConstants.SETTINGS_ADDITIONAL_PRODUCTS, 0);

            return (_additionalProductNumber > totalAdditionalImages);
        }

        public override bool NextClicked()
        {
            if (String.IsNullOrEmpty(txtTitle.Text))
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppCampaignTitleError);
                return (false);
            }

            if (String.IsNullOrEmpty(txtDescription.Text))
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppCampaignDescriptionError);
                return (false);
            }

            if (String.IsNullOrEmpty(txtURL.Text))
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppCampaignURLError);
                return (false);
            }

            if (txtURL.Text.StartsWith(StringConstants.BASE_WEB_HTTP) || 
                txtURL.Text.StartsWith(StringConstants.BASE_WEB_HTTPS) ||
                txtURL.Text.StartsWith(StringConstants.BASE_WEB_WWW))
            {
                ShowError(LanguageStrings.AppError, String.Format(LanguageStrings.AppCampaignInvalidURL, StringConstants.SETTINGS_URL));
                return (false);
            }

            if (String.IsNullOrEmpty(_settings[_additionalProductNumber].Image))
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppCampaignImageError);
                return (false);
            }
            
            _settings[_additionalProductNumber].Title = txtTitle.Text;
            _settings[_additionalProductNumber].Description = txtDescription.Text;
            _settings[_additionalProductNumber].URL = txtURL.Text;

            picPreview.Image = null;
            picPreview.ImageLocation = String.Empty;
            picPreview.Invalidate();

            return (true);
        }

        public override void PageShown()
        {
            txtTitle.MaxLength = XML.GetXMLValue(XMLFile(), _settings.Template, 
                StringConstants.SETTINGS_ADDITIONAL_PRODUCT_TITLE_LENGTH, 40);
            txtDescription.MaxLength = XML.GetXMLValue(XMLFile(), _settings.Template, 
                StringConstants.SETTINGS_ADDITIONAL_PRODUCT_DESCRIPTION_LEGTH, 80);

            int width = XML.GetXMLValue(XMLFile(), _settings.Template, 
                StringConstants.SETTINGS_ADDITIONAL_PRODUCT_WIDTH, 170);
            lblImageWidth.Text = String.Format(LanguageStrings.AppCampaignImageWidthError, width);

            if (!String.IsNullOrEmpty(_settings[_additionalProductNumber].Image))
                LoadImage();

            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.MarketingStep11;
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

        private void LoadImage()
        {
            System.IO.FileStream fs = new System.IO.FileStream(_settings[_additionalProductNumber].Image, 
                System.IO.FileMode.Open, System.IO.FileAccess.Read);
            try
            {
                picPreview.Image = System.Drawing.Image.FromStream(fs);
            }
            finally
            {
                fs.Close();
                fs = null;
            }
        }

        private void btnImageSelect_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //is the image the correct width?

                string xml = Shared.Utilities.AddTrailingBackSlash(CurrentPath()) + StringConstants.FILE_MARKETING;
                int width = XML.GetXMLValue(xml, _settings.Template, StringConstants.SETTINGS_ADDITIONAL_PRODUCT_WIDTH, 170);

                System.Drawing.Image img = System.Drawing.Image.FromFile(openFileDialog1.FileName);

                if (img.Width != width)
                {
                    ShowError(LanguageStrings.AppError, String.Format(LanguageStrings.AppCampaignImageWidthAdditionalError, width));
                    return;
                }

                _settings[_additionalProductNumber].Image = openFileDialog1.FileName;
                LoadImage();
            }
        }

        #endregion Private Methods
    }
}
