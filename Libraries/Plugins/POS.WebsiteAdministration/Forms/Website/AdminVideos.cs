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
 *  File: AdminVideos.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Windows.Forms;

using Languages;
using SharedBase.BOL.Video;

using POS.Base.Classes;

using Shared;

namespace POS.WebsiteAdministration.Forms.Website
{
    public partial class AdminVideos : POS.Base.Controls.BaseOptionsControl
    {
        #region Private Members

        private Video _currentVideo = null;

        #endregion Private Members

        #region Constructors

        public AdminVideos()
        {
            InitializeComponent();

            LoadVideos();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            base.LanguageChanged(culture);

            columnHeaderDescription.Text = LanguageStrings.AppDescription;

            lblDescription.Text = LanguageStrings.AppDescription;
            lblVideoReference.Text = LanguageStrings.AppVideoReference;
        }

        /// <summary>
        /// Updates the UI
        /// </summary>
        protected override void UpdateUI(bool itemSelected)
        {
            if (lvItems.SelectedItems.Count > 0)
            {
                txtDescription.Enabled = true;
                txtVideoReference.Enabled = true;
            }
            else
            {
                txtDescription.Enabled = false;
                txtVideoReference.Enabled = false;
                txtDescription.Text = String.Empty;
                txtVideoReference.Text = String.Empty;
                IsEditing = false;
            }

            AllowAddNew = !IsEditing;

            base.UpdateUI(lvItems.SelectedItems.Count > 0);
        }

        /// <summary>
        /// Validates changes and prompts to save changes
        /// </summary>
        /// <returns>If validation failed then returns false, otherwise returns true</returns>
        protected override bool PromptSave()
        {
            bool Result = false;

            if (IsEditing && ShowQuestion(LanguageStrings.AppVideoSave, LanguageStrings.AppVideoSaveDescription))
            {
                try
                {
                    Validation.Validate(txtDescription.Text, 10, 100, LanguageStrings.AppDescription);
                    Validation.Validate(txtVideoReference.Text, 5, 40, LanguageStrings.AppVideoReference);
                }
                catch (Exception err)
                {
                    ShowError(LanguageStrings.AppError, err.Message);
                    return (false);
                }

                _currentVideo.Description = txtDescription.Text;
                _currentVideo.VideoReference = txtVideoReference.Text;
                _currentVideo.Save();
                IsEditing = false;
                Result = true;
            }

            return (Result);
        }

        protected override void OnCreateClicked()
        {
            _currentVideo = new Video(-1, String.Empty, LanguageStrings.AppVideoNew);

            ListViewItem item = new ListViewItem(_currentVideo.Description);
            item.SubItems.Add(_currentVideo.VideoReference);
            item.SubItems.Add(_currentVideo.ID.ToString());

            lvItems.Items.Add(item);
            item.Selected = true;

            IsEditing = true;
            UpdateUI(true);
        }

        protected override void OnDeleteClicked()
        {
            if (ShowQuestion(LanguageStrings.AppVideoDelete, LanguageStrings.AppVideoDeleteDescription))
            {
                _currentVideo.Delete();
                _currentVideo = null;
                LoadVideos();
                IsEditing = false;
                UpdateUI(true);
            }
        }

        protected override void OnSaveClicked()
        {
            try
            {
                Validation.Validate(txtDescription.Text, 10, 100, LanguageStrings.Description);
                Validation.Validate(txtVideoReference.Text, 5, 40, LanguageStrings.AppVideoReference);
                _currentVideo.Description = txtDescription.Text;
                _currentVideo.VideoReference = txtVideoReference.Text;
                _currentVideo.Save();
                IsEditing = false;
                lvItems.SelectedItems[0].SubItems[2].Text = _currentVideo.ID.ToString();
            }
            catch (Exception err)
            {
                ShowError(LanguageStrings.AppError, err.Message);
            }

            UpdateUI(true);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadVideos()
        {
            Videos videos = Videos.Get();

            lvItems.Items.Clear();

            foreach (Video vid in videos)
            {
                ListViewItem item = new ListViewItem(vid.Description);
                item.SubItems.Add(vid.VideoReference);
                item.SubItems.Add(vid.ID.ToString());

                lvItems.Items.Add(item);
            }

            UpdateUI(lvItems.SelectedItems.Count > 0);
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            IsEditing = true;
            UpdateUI(lvItems.SelectedItems.Count > 0);
        }

        private void lvItems_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lvItems.SelectedItems.Count > 0)
            {
                if ((_currentVideo != null && _currentVideo.ID != -1) | (_currentVideo == null))
                    _currentVideo = Videos.Get(Shared.Utilities.StrToInt(lvItems.SelectedItems[0].SubItems[2].Text, -1));

                if (_currentVideo != null)
                {
                    txtDescription.Text = _currentVideo.Description;
                    txtVideoReference.Text = _currentVideo.VideoReference;
                    IsEditing = false;
                    txtDescription.Focus();
                }
            }
            else if (lvItems.SelectedItems.Count == 0 && IsEditing)
            {
                PromptSave();
            }

            UpdateUI(lvItems.SelectedItems.Count > 0);
        }

        private void txtVideoReference_OnPaste(object sender, SharedControls.PasteEventArgs e)
        {
            if (e.Text.ToLower().Contains(StringConstants.VIDEO_YOUTUBE))
            {
                e.Text = e.Text.Substring(e.Text.ToLower().IndexOf(StringConstants.VIDEO_YOUTUBE_SEPERATOR) + 2);

                while (e.Text.Contains(StringConstants.SYMBOL_AMPERSAND))
                    e.Text = e.Text.Substring(0, e.Text.Length - 1);
            }
        }

        #endregion Private Methods
    }
}
