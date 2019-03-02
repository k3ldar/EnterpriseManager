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
 *  File: PageBanner.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.IO;
using System.Windows.Forms;

using Languages;

using POS.Base.Classes;
using System.Globalization;

#pragma warning disable IDE1006

namespace POS.WebsiteAdministration.Controls.WebSettings
{
    public partial class PageBanner : BaseWebSetting
    {
        #region Constructors

        public PageBanner()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            lblLink.Text = LanguageStrings.AppWebisteLink;
            lblImage.Text = LanguageStrings.Picture;
        }

        public override string HelpString()
        {
            return (HelpTopics.WebsiteSettingPageBanner);
        }

        public override void Reload()
        {
            picBanner.Image = null;
            LoadImages();

            string setting = String.Format(StringConstants.WEB_SETTING_PAGE_BANNER_LINK, Website.ID, SettingIndex);
            txtLink.Text = SharedBase.LibraryHelperClass.SettingsGet(setting, txtLink.Text);
        }

        public override void Save()
        {
            string setting = String.Format(StringConstants.WEB_SETTING_PAGE_BANNER_LINK, Website.ID, SettingIndex);
            SharedBase.LibraryHelperClass.SettingsSet(setting, txtLink.Text);
            setting = String.Format(StringConstants.WEB_SETTING_PAGE_BANNER, Website.ID, SettingIndex);
            SharedBase.LibraryHelperClass.SettingsSet(setting,
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
            string imageRoot = AppController.POSFolder(ImageTypes.PageBanners);


            if (!Directory.Exists(imageRoot))
                Directory.CreateDirectory(imageRoot);

            string setting = SharedBase.LibraryHelperClass.SettingsGet(
                String.Format(StringConstants.WEB_SETTING_PAGE_BANNER, Website.ID, SettingIndex));
            cmbImage.Items.Clear();
            string[] files = Directory.GetFiles(imageRoot, StringConstants.IMAGE_SEARCH_PAGE_IMAGES);

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
