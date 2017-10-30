using System;
using System.Windows.Forms;

using Languages;

using Library;
using Library.BOL.Websites;
using POS.Base.Classes;

namespace POS.Marketing.Controls
{
    public partial class CreateEmailIntro : EmailWizardBase
    {        
        #region Private Members

        private EmailWizardSettings _settings;

        #endregion Private Members

        #region Constructors

        public CreateEmailIntro()
        {
            InitializeComponent();

            txtTrackingCode.AllowedCharacters = StringConstants.SETTINGS_CAMPAIGN_TRACKING_CODE_ALLOWED;
        }

        public CreateEmailIntro(EmailWizardSettings settings)
            : this()
        {
            _settings = settings;
            LoadWebsites();
            LoadSettings();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            btnLoadSavedCampaign.Text = LanguageStrings.AppCampaignLoadSaved;

            lblCampaignName.Text = LanguageStrings.AppCampaignName;
            lblHeader.Text = LanguageStrings.AppCampaignCreateMarketingEmail;
            lblHeaderDescription.Text = LanguageStrings.AppCampaignCreateDescription;
            lblWebsiteURL.Text = LanguageStrings.AppCampaignWebsiteURL;
            lblTrackingCode.Text = LanguageStrings.AppCampaignTrackingCode;
            lblEmailAddress.Text = LanguageStrings.AppCampaignEmailAddress;

            AppController.ActiveHelpTopic = HelpTopics.MarketingStep1;
        }

        public override void LoadFromFile(string fileName)
        {
            txtCampaignName.Text = XML.GetXMLValue(fileName, StringConstants.SETTINGS_INTRO, 
                StringConstants.SETTINGS_CAMPAIGN_NAME);
            txtTrackingCode.Text = XML.GetXMLValue(fileName, StringConstants.SETTINGS_INTRO, 
                StringConstants.SETTINGS_CAMPAIGN_TRACKING_CODE);
            txtEmailAddress.Text = XML.GetXMLValue(fileName, StringConstants.SETTINGS_INTRO,
                StringConstants.SETTINGS_CAMPAIGN_EMAIL);
        }

        public override void SaveToFile(string fileName)
        {
            XML.SetXMLValue(fileName, StringConstants.SETTINGS_INTRO, 
                StringConstants.SETTINGS_CAMPAIGN_NAME, txtCampaignName.Text);
            XML.SetXMLValue(fileName, StringConstants.SETTINGS_INTRO, 
                StringConstants.SETTINGS_CAMPAIGN_TRACKING_CODE, txtTrackingCode.Text);
            XML.SetXMLValue(fileName, StringConstants.SETTINGS_INTRO,
                StringConstants.SETTINGS_CAMPAIGN_EMAIL, txtEmailAddress.Text);
        }

        public override bool NextClicked()
        {
            if (txtCampaignName.Text.Trim() == String.Empty)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppCampaignTrackingCodeDesc);
                return (false);
            }

            if (txtEmailAddress.Text.Trim() == String.Empty ||
                !Shared.Utilities.IsValidEmail(txtEmailAddress.Text))
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppCampaignEmailAddressMissing);
                return (false);
            }

            if (cmbWebsites.SelectedIndex == -1)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppCampaignURL);
                return (false);
            }

            if (String.IsNullOrEmpty(txtTrackingCode.Text))
                txtTrackingCode.Text = txtCampaignName.Text;

            _settings.CampaignName = txtCampaignName.Text.Trim();
            _settings.TrackingCode = txtTrackingCode.Text.Trim();
            _settings.CampaignEmail = txtEmailAddress.Text;
            _settings.URL = (string)cmbWebsites.SelectedItem;
            AppController.LocalSettings.MarketingURL = _settings.URL;

            return (true);
        }

        #endregion Overrridden Methods

        #region Private Methods

        private void LoadWebsites()
        {
            Websites allWebsites = Websites.All();
            cmbWebsites.Items.Clear();

            foreach (Website site in allWebsites)
            {
                int idx = cmbWebsites.Items.Add(site.URL);

                if (site.URL == _settings.URL)
                {
                    cmbWebsites.SelectedIndex = idx;
                }
            }
        }

        private void LoadSettings()
        {
            cmbWebsites.SelectedItem = cmbWebsites.Items.IndexOf(_settings.URL);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    MainWizardForm.LoadAllSavedPageData(openFileDialog1.FileName);
                }
                finally
                {
                    Cursor = Cursors.Arrow;
                }
            }
        }

        #endregion Private Methods
    }
}
