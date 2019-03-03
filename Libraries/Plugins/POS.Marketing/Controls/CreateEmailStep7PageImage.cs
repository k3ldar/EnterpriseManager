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
 *  File: CreateEmailStep7PageImage.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.IO;

using SharedBase;

using Languages;
using POS.Base.Classes;

namespace POS.Marketing.Controls
{
    public partial class CreateEmailStep7PageImage : EmailWizardBase
    {
        #region Private Members

        private EmailWizardSettings _settings;

        #endregion Private Members

        #region Constructors

        public CreateEmailStep7PageImage()
        {
            InitializeComponent();
        }


        public CreateEmailStep7PageImage(EmailWizardSettings settings)
        {
            InitializeComponent();
            _settings = settings;

            LoadSettings();
        }

        #endregion Constructors

        #region Overridden Methdos

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblHeader.Text = LanguageStrings.AppCampaignPageImage;

            lblWebLink.Text = LanguageStrings.AppURL;

            btnTestLink.Text = LanguageStrings.AppMenuButtonTestURL;
        }

        public override void LoadFromFile(string fileName)
        {
            _settings.PageImageFile = XML.GetXMLValue(fileName, StringConstants.SETTINGS_STEP_4,
                StringConstants.SETTINGS_PAGE_IMAGE);
            _settings.PageImageLink = XML.GetXMLValue(fileName, StringConstants.SETTINGS_STEP_4,
                StringConstants.SETTINGS_PAGE_IMAGE_LINK);

            if (System.IO.File.Exists(_settings.PageImageFile))
                LoadImage();
        }

        public override void SaveToFile(string fileName)
        {
            XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_4,
                StringConstants.SETTINGS_PAGE_IMAGE, _settings.PageImageFile);
            XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_4,
                StringConstants.SETTINGS_PAGE_IMAGE_LINK, _settings.PageImageLink);
        }

        public override bool NextClicked()
        {
            _settings.PageImageLink = txtWebLink.Text;
            picMainImage.Image = null;
            picMainImage.ImageLocation = String.Empty;
            picMainImage.Invalidate();
            return (true);
        }

        public override void PageShown()
        {
            if (lblHeaderDescription.Text.Contains(StringConstants.PREFIX_NO_SPACE))
            {
                lblHeaderDescription.Text = LanguageStrings.AppCampaignPageImageDescription;
            }

            txtWebLink.Text = _settings.PageImageLink;

            if (!String.IsNullOrEmpty(_settings.PageImageFile))
                LoadImage();

            AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.MarketingStep9;

            LoadAllImages();
        }

        public override bool PreviousClicked()
        {
            if (!String.IsNullOrEmpty(_settings.PageImageFile))
            {
                bool goBack = ShowHardConfirm(LanguageStrings.AppCampaignPreviousStep,
                    LanguageStrings.AppCampaignPreviousStepPrompt);

                if (goBack)
                {
                    _settings.PageImageFile = String.Empty;
                    _settings.PageImageLink = String.Empty;

                    picMainImage.Image = null;
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

        }

        private void LoadImage()
        {
            string imageFile = AppController.POSFolder(ImageTypes.PageBanners) + _settings.PageImageFile;

            if (!File.Exists(imageFile))
                return;

            picMainImage.ImageLocation = imageFile;
        }

        private void btnTestLink_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txtWebLink.Text);
            _settings.PageImageLink = txtWebLink.Text;
        }

        private void LoadAllImages()
        {
            string imageRoot = AppController.POSFolder(ImageTypes.PageBanners);

            cmbImages.Items.Clear();
            string[] files = Directory.GetFiles(imageRoot, StringConstants.IMAGE_SEARCH_PAGE_IMAGES);
            string imgFile = Path.GetFileName(_settings.PageImageFile);

            foreach (string file in files)
            {
                int idx = cmbImages.Items.Add(Path.GetFileName(file));

                if (!String.IsNullOrEmpty(imgFile) && file.EndsWith(imgFile))
                {
                    cmbImages.SelectedIndex = idx;
                }
            }

        }

        private void cmbImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbImages.SelectedIndex == -1)
            {
                picMainImage.Image = null;
            }
            else
            {
                picMainImage.ImageLocation = AppController.POSFolder(ImageTypes.PageBanners) +
                    (string)cmbImages.Items[cmbImages.SelectedIndex];
                _settings.PageImageFile = Path.GetFileName(picMainImage.ImageLocation);
            }
        }

        #endregion Private Methods
    }
}
