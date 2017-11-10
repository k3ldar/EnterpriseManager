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
 *  File: CreateEmailStep4.cs
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
    public partial class CreateEmailStep4 :  EmailWizardBase
    {
        #region Private Members

        private EmailWizardSettings _settings;

        #endregion Private Members

        #region Constructors

        public CreateEmailStep4()
        {
            InitializeComponent();
        }

        public CreateEmailStep4(EmailWizardSettings settings)
        {
            InitializeComponent();
            _settings = settings;

            LoadSettings();
        }

        #endregion Constructors

        #region Overridden Methdos

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblHeader.Text = LanguageStrings.AppCampaignPrimaryImage;
        }

        /// <summary>
        /// When prompted, load the existing image from saved file
        /// </summary>
        /// <param name="fileName"></param>
        public override void LoadFromFile(string fileName)
        {
            _settings.ImageFile = XML.GetXMLValue(fileName, StringConstants.SETTINGS_STEP_4, 
                StringConstants.SETTINGS_IMAGE_FILE);
            _settings.ImageFileLink = XML.GetXMLValue(fileName, StringConstants.SETTINGS_STEP_4, 
                StringConstants.SETTINGS_IMAGE_LINK);
            if (System.IO.File.Exists(_settings.ImageFile))
                LoadImage();
        }

        public override void SaveToFile(string fileName)
        {
            XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_4, 
                StringConstants.SETTINGS_IMAGE_FILE, _settings.ImageFile);
        }

        public override bool SkipPage()
        {
            return base.SkipPage();
        }

        /// <summary>
        /// The user can not continue if they have not selected an image
        /// </summary>
        /// <returns></returns>
        public override bool NextClicked()
        {
            if (String.IsNullOrEmpty(_settings.ImageFile)
                || cmbImages.SelectedIndex == -1)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppCampaignMainImageError);
                return (false);
            }
            else
            {
                picMainImage.Image = null;
                picMainImage.ImageLocation = String.Empty;
                picMainImage.Invalidate();
                return (true);
            }
        }

        /// <summary>
        /// When the page is shown, if an image is already selected then show it.
        /// </summary>
        public override void PageShown()
        {
            if (lblHeaderDescription.Text.Contains(StringConstants.PREFIX_NO_SPACE))
            {
                lblHeaderDescription.Text = String.Format(LanguageStrings.AppCampaignPrimaryImageDescription, XML.GetXMLValue(XMLFile(), 
                    _settings.Template, StringConstants.SETTINGS_MAIN_IMAGE_WIDTH, 650));
            }

            if (!String.IsNullOrEmpty(_settings.ImageFile) && System.IO.File.Exists(_settings.ImageFile))
                LoadImage();

            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.MarketingStep5;

            loadAllImages();
        }

        public override bool PreviousClicked()
        {
            if (!String.IsNullOrEmpty(_settings.ImageFile))
            {
                bool goBack = ShowHardConfirm(LanguageStrings.AppCampaignPreviousStep, 
                    LanguageStrings.AppCampaignPreviousStepPrompt);

                if (goBack)
                {
                    _settings.ImageFile = String.Empty;
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
            System.IO.FileStream fs = new System.IO.FileStream(_settings.ImageFile, FileMode.Open, FileAccess.Read);
            try
            {
                picMainImage.Image = System.Drawing.Image.FromStream(fs);
            }
            finally
            {
                fs.Close();
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

                _settings.ImageFile = openFileDialog1.FileName;
                LoadImage();
            }
        }

        private void loadAllImages()
        {
            string imageRoot = AppController.POSFolder(ImageTypes.OfferImages);


            if (!Directory.Exists(imageRoot))
                Directory.CreateDirectory(imageRoot);

            cmbImages.Items.Clear();
            string[] files = Directory.GetFiles(imageRoot, StringConstants.IMAGE_SEARCH_OFFER_IMAGES);
            string imgFile = Path.GetFileName(_settings.ImageFile);

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
                _settings.ImageFile = picMainImage.ImageLocation;
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
