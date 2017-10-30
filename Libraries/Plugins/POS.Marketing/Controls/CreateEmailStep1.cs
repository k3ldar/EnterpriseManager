using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using Library;

using Languages;
using POS.Base.Classes;

namespace POS.Marketing.Controls
{
    public partial class CreateEmailStep1 : EmailWizardBase
    {
        #region Private Members

        private EmailWizardSettings _settings;
        private Dictionary<string, EmailTemplateClass> _templates = new Dictionary<string, EmailTemplateClass>();

        #endregion Private Members

        #region Constructors

        public CreateEmailStep1()
        {
            InitializeComponent();
        }

        public CreateEmailStep1(EmailWizardSettings settings)
            : this()
        {
            _settings = settings;
            LoadTemplates();
        }

        #endregion Constructors

        #region Private Methods

        private void LoadTemplates()
        {
            _templates.Clear();
            cmbTemplate.Items.Clear();
            string path = AppController.POSFolder(FolderType.Marketing, true);

            string[] templateFiles = System.IO.Directory.GetFiles(path, StringConstants.FILE_SEARCH_HTML);

            string xml = Shared.Utilities.AddTrailingBackSlash(CurrentPath()) + StringConstants.FILE_MARKETING;

            int templateCount = Library.XML.GetXMLValue(xml, StringConstants.SETTINGS_MARKETING, 
                StringConstants.SETTINGS_TEMPLATES, 1);

            for (int i = 1; i <= templateCount; i++)
            {
                string template = String.Format(StringConstants.PREFIX_AND_SUFFIX, StringConstants.SETTINGS_TEMPLATE, i);
                string file = path + System.IO.Path.GetFileName(Library.XML.GetXMLValue(xml, 
                    template, StringConstants.SETTINGS_FILENAME));
                string name = Library.XML.GetXMLValue(xml, template, StringConstants.SETTINGS_NAME);
                _templates.Add(file, new EmailTemplateClass(file, name, i));
                cmbTemplate.Items.Add(file);
            }

            if (cmbTemplate.Items.Count >= 7)
                cmbTemplate.SelectedIndex = 7;
            else if (cmbTemplate.Items.Count > 0)
                cmbTemplate.SelectedIndex = 0;
        }

        #endregion Private Methods

        private void cmbTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTemplate.SelectedItem != null)
            {
                string file = cmbTemplate.SelectedItem.ToString();

                lblDescription.Text = XML.GetXMLValue(Shared.Utilities.AddTrailingBackSlash(
                    CurrentPath()) + StringConstants.FILE_MARKETING,
                    String.Format(StringConstants.PREFIX_AND_SUFFIX, StringConstants.SETTINGS_TEMPLATE, _templates[file].Index),
                    StringConstants.SETTINGS_DESCRIPTION).Replace(StringConstants.SYMBOL_CRLF_SAVED, StringConstants.SYMBOL_LINE_FEED);

                _settings.Template = Path.GetFileNameWithoutExtension(file);
                _settings.TemplateFile = file;

                if (!String.IsNullOrEmpty(file))
                {
                    file = Path.ChangeExtension(file, StringConstants.FILE_EXTENSION_JPG);
                    picPreview.ImageLocation = file;
                }
            }
        }

        private void cmbTemplate_Format(object sender, ListControlConvertEventArgs e)
        {
            string file = e.ListItem.ToString();

            e.Value = _templates[file].TemplateName;
        }

        #region Overridden Mthods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblHeader.Text = LanguageStrings.AppCampaignSelectTemplate;
        }

        public override void LoadFromFile(string fileName)
        {
            cmbTemplate.SelectedIndex = XML.GetXMLValue(fileName, StringConstants.SETTINGS_STEP_1, 
                StringConstants.SETTINGS_TEMPLATE, 0);
        }

        public override void SaveToFile(string fileName)
        {
            XML.SetXMLValue(fileName, StringConstants.SETTINGS_STEP_1, StringConstants.SETTINGS_TEMPLATE, 
                cmbTemplate.SelectedIndex.ToString());
        }

        public override void PageShown()
        {
            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.MarketingStep2;
        }

        #endregion Overridden Methods

    }
}
