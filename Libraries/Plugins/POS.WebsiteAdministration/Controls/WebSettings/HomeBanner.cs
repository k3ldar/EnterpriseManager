using System;
using System.IO;
using System.Windows.Forms;

using Languages;

using POS.Base.Classes;
using System.Globalization;

namespace POS.WebsiteAdministration.Controls.WebSettings
{
    public partial class HomeBanner : BaseWebSetting
    {
        public HomeBanner()
        {
            InitializeComponent();
        }

        #region Overridden Methods

        public override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            lblLink.Text = LanguageStrings.AppWebisteLink;
            lblImage.Text = LanguageStrings.Picture;
        }

        public override string HelpString()
        {
            return (POS.Base.Classes.HelpTopics.WebsiteSettingBanner);
        }

        public override void Reload()
        {
            picBanner.Image = null;
            LoadImages();
        }

        public override void Save()
        {
            string setting = String.Format(StringConstants.WEB_SETTING_HOME_BANNER_LINK, WebSite.ID, SettingIndex);
            Library.LibraryHelperClass.SettingsSet(setting, txtLink.Text);
            setting = String.Format(StringConstants.WEB_SETTING_HOME_BANNER, WebSite.ID, SettingIndex);
            Library.LibraryHelperClass.SettingsSet(setting,
                cmbImage.SelectedIndex == -1 ? String.Empty : Path.GetFileName((string)cmbImage.Items[cmbImage.SelectedIndex]));
        }

        public override void Clear()
        {
            if (ShowQuestion(LanguageStrings.Delete, LanguageStrings.AppWebsiteDeleteBanner))
            {
                txtLink.Text = String.Empty;
                cmbImage.SelectedIndex = -1;
                Save();
            }
        }

        public override bool AllowDelete()
        {
            return (true);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadImages()
        {
            string imageRoot = AppController.POSFolder(ImageTypes.HomePageBanners);


            if (!Directory.Exists(imageRoot))
                Directory.CreateDirectory(imageRoot);

            string setting = String.Format(StringConstants.WEB_SETTING_HOME_BANNER_LINK, WebSite.ID, SettingIndex);
            txtLink.Text = Library.LibraryHelperClass.SettingsGet(setting, String.Empty);

            setting = Library.LibraryHelperClass.SettingsGet(
                String.Format(base.SettingName, WebSite.ID, SettingIndex));
            cmbImage.Items.Clear();
            string[] files = Directory.GetFiles(imageRoot, StringConstants.IMAGE_SEARCH_HOME_IMAGES);

            foreach (string file in files)
            {
                int idx = cmbImage.Items.Add(file);

                if (!String.IsNullOrEmpty(setting) && file.EndsWith(setting))
                {
                    cmbImage.SelectedIndex = idx;
                }
            }
        }

        private void cmbImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbImage.SelectedIndex == -1)
                picBanner.Image = null;
            else
                picBanner.ImageLocation = (string)cmbImage.Items[cmbImage.SelectedIndex];

            RaiseOnChanged();
        }

        private void cmbImage_Format(object sender, ListControlConvertEventArgs e)
        {
            string fileName = (string)e.ListItem;
            e.Value = Path.GetFileName(fileName);
        }

        private void txtLink_TextChanged(object sender, EventArgs e)
        {
            RaiseOnChanged();
        }

        #endregion Private Methods
    }
}
