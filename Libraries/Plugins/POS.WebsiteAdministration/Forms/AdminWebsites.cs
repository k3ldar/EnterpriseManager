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
 *  File: AdminWebsites.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

using Languages;
using Library.BOL.Websites;

using POS.Base.Classes;

using POS.WebsiteAdministration.Controls.WebSettings;

#pragma warning disable IDE1006
#pragma warning disable IDE0017

namespace POS.WebsiteAdministration.Forms
{
    public partial class AdminWebsites : Base.Controls.BaseOptionsControl
    {
        #region Private Members

        private ToolStripComboBox _toolStripWebsites;

        private Library.BOL.Websites.Website WebSite;

        #endregion Private Members

        #region Constructors

        public AdminWebsites()
        {
            InitializeComponent();

            OnRefreshClicked();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

        }

        protected override void OnDeleteClicked()
        {
            if (tvOptions.SelectedNode == null || tvOptions.SelectedNode.Tag == null)
                return;

            BaseWebSetting settingPage = (BaseWebSetting)tvOptions.SelectedNode.Tag;
            settingPage.Clear();
            IsEditing = false;
            AllowEdit = true;
            AllowDelete = false;
            UpdateUI(true);
        }

        protected override void OnEditClicked()
        {
            Library.BOL.Websites.Website website = (Library.BOL.Websites.Website)_toolStripWebsites.Items[_toolStripWebsites.SelectedIndex];
            Classes.CreateEditWebsiteWizard.EditWebsite(website);
        }

        protected override void OnCreateClicked()
        {
            Library.BOL.Websites.Website website = null;

            if (Classes.CreateEditWebsiteWizard.CreateWebsite(ref website))
            {
                if (website != null)
                {
                    _toolStripWebsites.Items.Add(website);

                    if (_toolStripWebsites.SelectedIndex == -1)
                        _toolStripWebsites.SelectedIndex = 0;

                    WebsiteAdministrationPluginModule.WebsiteCount = _toolStripWebsites.Items.Count;
                }
            }
        }

        protected override void OnSaveClicked()
        {
            if (tvOptions.SelectedNode == null || tvOptions.SelectedNode.Tag == null)
                return;

            BaseWebSetting settingPage = (BaseWebSetting)tvOptions.SelectedNode.Tag;
            settingPage.Save();
            IsEditing = false;
            AllowEdit = true;
            AllowDelete = false;
            UpdateUI(true);
        }

        protected override void OnRefreshClicked()
        {
            this.Cursor = Cursors.WaitCursor;
            tvOptions.BeginUpdate();
            try
            {
                LoadWebsites(true);
                AllowDelete = false;
                AllowEdit = _toolStripWebsites.SelectedIndex > -1;
                IsEditing = false;
                AllowRefresh = true;

                UpdateUI(_toolStripWebsites.SelectedIndex > -1);
            }
            finally
            {
                tvOptions.EndUpdate();
                this.Cursor = Cursors.Arrow;
            }
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadWebsites(bool forceRefresh)
        {
            if (_toolStripWebsites == null)
            {
                AddToolbarSeperator();
                _toolStripWebsites = new ToolStripComboBox();

                _toolStripWebsites.DropDownStyle = ComboBoxStyle.DropDownList;
                _toolStripWebsites.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;
                _toolStripWebsites.ComboBox.DrawItem += toolStripWebsites_DrawItem;
                _toolStripWebsites.AutoSize = false;
                _toolStripWebsites.Width = 250;
                _toolStripWebsites.SelectedIndexChanged += toolStripWebsites_SelectedIndexChanged;

                AddToolbarCombo(_toolStripWebsites);
            }

            _toolStripWebsites.Items.Clear();

            foreach (Library.BOL.Websites.Website website in Websites.All())
            {
                _toolStripWebsites.Items.Add(website);
            }

            if (_toolStripWebsites.Items.Count > 0)
                _toolStripWebsites.SelectedIndex = 0;

            if (forceRefresh || tvOptions.Nodes.Count == 0)
                LoadAllNodes();
        }

        private void LoadAllNodes()
        {
            this.Cursor = Cursors.WaitCursor;
            tvOptions.BeginUpdate();
            try
            {
                tvOptions.Nodes.Clear();

                TreeNode root = tvOptions.Nodes.Add(LanguageStrings.AppHomePageBanners);
                HomeBanners banners = new HomeBanners();
                banners.Website = WebSite;
                root.Tag = banners;

                for (int i = 1; i < 6; i++)
                {
                    HomeBanner banner = new HomeBanner();
                    banner.UpdateSetting(StringConstants.WEB_SETTING_HOME_BANNER, false, i);
                    TreeNode node = new TreeNode(String.Format(LanguageStrings.AppWebSettingHomeBanner, i));
                    root.Nodes.Add(node);
                    node.Tag = banner;
                }

                root.Expand();

                root = tvOptions.Nodes.Add(LanguageStrings.AppHomeFixedBanners);
                HomeFixedBanners fixedBanners = new HomeFixedBanners();
                fixedBanners.Website = WebSite;
                root.Tag = fixedBanners;

                for (int i = 0; i < 4; i++)
                {
                    HomeFixedBanner homeFixedBanner = new HomeFixedBanner();
                    homeFixedBanner.UpdateSetting(StringConstants.WEB_SETTING_HOME_FIXED_BANNER, false, i);
                    TreeNode node = new TreeNode(String.Format(LanguageStrings.AppHomeFixedBanner, 1));
                    root.Nodes.Add(node);
                    node.Tag = homeFixedBanner;
                }

                root.Expand();


                root = tvOptions.Nodes.Add(LanguageStrings.AppPageBanners);
                PageBanners pageBanners = new PageBanners();
                pageBanners.Website = WebSite;
                root.Tag = pageBanners;

                for (int i = 1; i < 4; i++)
                {
                    PageBanner pageBanner = new PageBanner();
                    pageBanner.UpdateSetting(StringConstants.WEB_SETTING_PAGE_BANNER, false, i);
                    TreeNode node = new TreeNode(String.Format(LanguageStrings.AppWebSettingPageBanner, i));
                    root.Nodes.Add(node);
                    node.Tag = pageBanner;
                }

                root.Expand();

                // load all settings
                Settings settings = new Settings();
                List<string> baseSettings = settings.WebSiteOptionHeaders();

                foreach (string option in baseSettings)
                {
                    SettingPage settingsPage = new SettingPage();
                    settingsPage.SetPage(option);
                    root = tvOptions.Nodes.Add(option);
                    root.Tag = settingsPage;

                    GetWebsiteSubOptions(settings, root, option);

                    root.Expand();
                }

                tvOptions.Sort();

                // finally select first node in the list and make sure shown
                tvOptions.SelectedNode = tvOptions.Nodes[0];
                tvOptions.SelectedNode.EnsureVisible();
            }
            finally
            {
                tvOptions.EndUpdate();
                this.Cursor = Cursors.Arrow;
            }
        }

        private string GetWebsiteSubOptions(Settings settings, TreeNode node,
            string currentOption)
        {
            string Result = String.Empty;

            List<string> subOptions = settings.WebSiteSubOptions(currentOption);

            if (subOptions.Count > 0)
            {
                foreach (string subOption in subOptions)
                {
                    SettingPage settingsPage = new SettingPage();
                    settingsPage.SetPage(subOption);
                    TreeNode settingNode = new TreeNode(subOption);
                    settingNode.Tag = settingsPage;
                    node.Nodes.Add(settingNode);

                    Result += GetWebsiteSubOptions(settings, settingNode, subOption);
                    settingNode.Expand();
                }
            }

            return (Result);
        }

        //private string GetWebsiteOptions(Settings settings, string currentOption)
        //{
        //    string Result = String.Empty;

        //    List<string> options = settings.WebSiteOptionHeaders();

        //    foreach (string option in options)
        //    {
        //        Result += String.Format("<li><a href=\"/Staff/Admin/Options.aspx?Option={0}\">{0}</a></li>",
        //            option, option == currentOption ? "class=\"current\"" : "");

        //        Result += GetWebsiteSubOptions(settings, currentOption, option, 15);
        //    }

        //    return (Result);
        //}

        private void toolStripWebsites_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.State.HasFlag(DrawItemState.Selected))
            {
                e.DrawFocusRectangle();
            }

            if (e.Index == -1)
                return;

            Library.BOL.Websites.Website website = (Library.BOL.Websites.Website)_toolStripWebsites.Items[e.Index];

            e.Graphics.DrawString(
                website.Domain,
                _toolStripWebsites.Font,
                Brushes.Black,
                new PointF(e.Bounds.X, e.Bounds.Y));
        }

        private void toolStripWebsites_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                tvOptions.Focus();
                tvOptions_AfterSelect(sender, new TreeViewEventArgs(tvOptions.SelectedNode));
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void tvOptions_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null || e.Node.Tag == null)
                return;

            BaseWebSetting settingPage = (BaseWebSetting)e.Node.Tag;
            settingPage.Left = tvOptions.Left + tvOptions.Width + 10;
            settingPage.Top = tvOptions.Top;
            settingPage.Height = tvOptions.Height;
            settingPage.Width = this.Width - (settingPage.Left + 10);
            settingPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            settingPage.Visible = true;
            settingPage.Changed += settingChangedEvent;
            settingPage.Enabled = _toolStripWebsites.SelectedIndex > -1;
            settingPage.AfterLoad();

            this.Controls.Add(settingPage);

            if (_toolStripWebsites.SelectedIndex > -1)
            {
                WebSite = (Library.BOL.Websites.Website)_toolStripWebsites.Items[_toolStripWebsites.SelectedIndex];
                settingPage.WebsiteChanged(WebSite);
            }

            IsEditing = false;
            AllowDelete = settingPage.AllowDelete();
            AllowEdit = true;
            UpdateUI(true);
        }

        private void tvOptions_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (tvOptions.SelectedNode == null || tvOptions.SelectedNode.Tag == null)
                return;

            BaseWebSetting settingPage = (BaseWebSetting)tvOptions.SelectedNode.Tag;

            if (IsEditing)
            {
                if (ShowQuestion(LanguageStrings.AppWebsiteSettings, LanguageStrings.AppWebsiteSettingsSave))
                    settingPage.Save();
            }

            settingPage.Changed -= settingChangedEvent;
            settingPage.Visible = false;
            this.Controls.Remove(settingPage);
        }

        private void settingChangedEvent(object sender, EventArgs e)
        {
            IsEditing = true;
            AllowEdit = false;
            UpdateUI(true);
        }

        #endregion Private Methods
    }
}
