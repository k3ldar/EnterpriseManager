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
 *  File: CreateEmailStep5.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.IO;

using Library;

using Languages;
using POS.Base.Classes;

namespace POS.Marketing.Controls
{
    public partial class CreateEmailStep5 : EmailWizardBase
    {
        #region Private Members

        private EmailWizardSettings _settings;

        #endregion Private Members

        #region Constructors

        public CreateEmailStep5()
        {
            InitializeComponent();
        }

        
        public CreateEmailStep5(EmailWizardSettings settings)
        {
            InitializeComponent();
            _settings = settings;

            LoadSettings();
        }

        #endregion Constructors

        #region Overridden Methdos

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblHeader.Text = LanguageStrings.AppCampaignSecondaryImage;
            
            lblWebLink.Text = LanguageStrings.AppURL;

            btnTestLink.Text = LanguageStrings.AppMenuButtonTestURL;
        }

        public override void LoadFromFile(string fileName)
        {
            _settings.SecondaryImageFile = XML.GetXMLValue(fileName, StringConstants.SETTINGS_STEP_4,
                StringConstants.SETTINGS_SECONDARY_IMAGE);
            _settings.SecondaryImageFileLink = XML.GetXMLValue(fileName, StringConstants.SETTINGS_STEP_4,
                StringConstants.SETTINGS_SECONDARY_LINK);

            if (System.IO.File.Exists(_settings.SecondaryImageFile))
                LoadImage();
        }

        public override void SaveToFile(string fileName)
        {
            XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_4,
                StringConstants.SETTINGS_SECONDARY_IMAGE, _settings.SecondaryImageFile);
            XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_4,
                StringConstants.SETTINGS_SECONDARY_LINK, _settings.SecondaryImageFileLink);
        }

        public override bool SkipPage()
        {
            return (!XML.GetXMLValue(XMLFile(),
                    _settings.Template, StringConstants.SETTINGS_SECONDARY_IMAGE, false));
        }

        public override bool NextClicked()
        {
            if (String.IsNullOrEmpty(_settings.SecondaryImageFile) ||
                cmbImages.SelectedIndex == -1)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppCampaignSecondaryImageError);
                return (false);
            }
            else
            {
                _settings.SecondaryImageFileLink = txtWebLink.Text;
                picMainImage.Image = null;
                picMainImage.ImageLocation = String.Empty;
                picMainImage.Invalidate();
                return (true);
            }
        }

        public override void PageShown()
        {
            if (lblHeaderDescription.Text.Contains(StringConstants.PREFIX_NO_SPACE))
            {
                lblHeaderDescription.Text = String.Format(LanguageStrings.AppCampaignSecondaryImageDescription, XML.GetXMLValue(XMLFile(), 
                    _settings.Template, StringConstants.SETTINGS_MAIN_IMAGE_WIDTH, 650));
            }

            txtWebLink.Text = _settings.SecondaryImageFileLink;

            if (!String.IsNullOrEmpty(_settings.SecondaryImageFile))
                LoadImage();

            AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.MarketingStep7;

            loadAllImages();
        }

        public override bool PreviousClicked()
        {
            if (!String.IsNullOrEmpty(_settings.SecondaryImageFile))
            {
                bool goBack = ShowHardConfirm(LanguageStrings.AppCampaignPreviousStep, 
                    LanguageStrings.AppCampaignPreviousStepPrompt);

                if (goBack)
                {
                    _settings.SecondaryImageFile = String.Empty;
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
            if (!File.Exists(_settings.SecondaryImageFile))
                return;
            
            FileStream fs = new FileStream(_settings.SecondaryImageFile, FileMode.Open, FileAccess.Read);
            try
            {
                picMainImage.Image = System.Drawing.Image.FromStream(fs);
            }
            finally
            {
                fs.Close();
                fs.Dispose();
                fs = null;
            }
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //is the image the correct width?

                string xml = Shared.Utilities.AddTrailingBackSlash(CurrentPath()) + StringConstants.FILE_MARKETING;
                int width = XML.GetXMLValue(xml, _settings.Template, StringConstants.SETTINGS_MAIN_IMAGE_WIDTH, 650);

                System.Drawing.Image img = System.Drawing.Image.FromFile(openFileDialog1.FileName);

                if (img.Width != width)
                {
                    ShowError(LanguageStrings.AppError, String.Format(LanguageStrings.AppCampaignMainImageWidthError, width));
                    return;
                }

                _settings.SecondaryImageFile = openFileDialog1.FileName;
                LoadImage();
            }
        }

        private void btnTestLink_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txtWebLink.Text);
            _settings.SecondaryImageFileLink = txtWebLink.Text;
        }

        private void loadAllImages()
        {
            string imageRoot = AppController.POSFolder(ImageTypes.OfferImages);

            cmbImages.Items.Clear();
            string[] files = Directory.GetFiles(imageRoot, StringConstants.IMAGE_SEARCH_OFFER_IMAGES);
            string imgFile = Path.GetFileName(_settings.SecondaryImageFile);

            foreach (string file in files)
            {
                int idx = cmbImages.Items.Add(file);

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
                picMainImage.ImageLocation = (string)cmbImages.Items[cmbImages.SelectedIndex];
                _settings.SecondaryImageFile = picMainImage.ImageLocation;
            }
        }

        private void cmbImages_Format(object sender, System.Windows.Forms.ListControlConvertEventArgs e)
        {
            string fileName = (string)e.ListItem;
            e.Value = Path.GetFileName(fileName);
        }

        #endregion Private Methods
    }
}
