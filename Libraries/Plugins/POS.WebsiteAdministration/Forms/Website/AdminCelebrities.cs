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
 *  File: AdminCelebrities.cs
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
using SharedBase.BOL.Celebrities;

using Shared;
using POS.Base.Classes;

namespace POS.WebsiteAdministration.Forms.Website
{
    public partial class AdminCelebrities : POS.Base.Controls.BaseOptionsControl
    {
        #region Private Members

        private Celebrity _currentCeleb = null;

        #endregion Private Members

        public AdminCelebrities()
        {
            InitializeComponent();

            if (!AppController.ApplicationRunning)
                return;

            LoadImages();
            LoadCelebrities();
        }

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            base.LanguageChanged(culture);

            columnHeaderDescription.Text = LanguageStrings.AppDescription;

            lblDescription.Text = LanguageStrings.AppDescription;
            lblName.Text = LanguageStrings.AppName;
        }

        /// <summary>
        /// Updates the UI
        /// </summary>
        protected override void UpdateUI(bool itemSelected)
        {

            if (lvItems.SelectedItems.Count > 0)
            {
                cmbImages.Enabled = true;
                txtName.Enabled = true;
                txtDescription.Enabled = true;
            }
            else
            {
                txtName.Enabled = false;
                txtDescription.Enabled = false;
                txtDescription.Text = String.Empty;
                txtName.Text = String.Empty;
                cmbImages.Enabled = false;
                cmbImages.SelectedIndex = -1;
                IsEditing = false;
            }

            AllowAddNew = !IsEditing;

            base.UpdateUI(itemSelected);
        }

        /// <summary>
        /// Validates changes and prompts to save changes
        /// </summary>
        /// <returns>If validation failed then returns false, otherwise returns true</returns>
        protected override bool PromptSave()
        {
            bool Result = false;

            if (IsEditing && ShowQuestion(LanguageStrings.AppCelebritySave,
                LanguageStrings.AppCelebritySaveDescription))
            {
                try
                {
                    Validation.Validate(txtName.Text, 2, 80, LanguageStrings.AppName);
                    Validation.Validate(txtDescription.Text, 10, 2000, LanguageStrings.AppDescription);
                }
                catch (Exception err)
                {
                    ShowError(LanguageStrings.AppError, err.Message);
                    return (false);
                }

                _currentCeleb.Description = txtDescription.Text;
                _currentCeleb.Name = txtName.Text;

                if (cmbImages.SelectedIndex == -1)
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppCelebritySelectImage);
                    cmbImages.DroppedDown = true;
                    return (false);
                }


                _currentCeleb.Image = (string)cmbImages.Items[cmbImages.SelectedIndex];
                _currentCeleb.Save();
                IsEditing = false;
                Result = true;
            }

            return (Result);
        }

        protected override void OnCreateClicked()
        {
            _currentCeleb = new Celebrity(-1, LanguageStrings.AppCelebrityNew, String.Empty, String.Empty);

            ListViewItem item = new ListViewItem(_currentCeleb.Name);
            item.SubItems.Add(_currentCeleb.ID.ToString());

            lvItems.Items.Add(item);
            item.Selected = true;

            IsEditing = true;
            UpdateUI(lvItems.SelectedItems.Count > 0);
        }

        protected override void OnDeleteClicked()
        {
            if (ShowQuestion(LanguageStrings.AppCelebrityDelete,
                LanguageStrings.AppCelebrityDeleteDescription))
            {
                _currentCeleb.Delete();
                _currentCeleb = null;
                LoadCelebrities();
                IsEditing = false;
                UpdateUI(false);
            }
        }

        protected override void OnSaveClicked()
        {
            try
            {
                Validation.Validate(txtName.Text, 2, 80, LanguageStrings.AppName);
                Validation.Validate(txtDescription.Text, 10, 2000, LanguageStrings.AppDescription);

                _currentCeleb.Description = txtDescription.Text;
                _currentCeleb.Name = txtName.Text;

                if (cmbImages.SelectedIndex == -1)
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppCelebritySelectImage);
                    cmbImages.DroppedDown = true;
                    return;
                }

                _currentCeleb.Image = (string)cmbImages.Items[cmbImages.SelectedIndex];

                _currentCeleb.Save();
                IsEditing = false;
                lvItems.SelectedItems[0].SubItems[1].Text = _currentCeleb.ID.ToString();
            }
            catch (Exception err)
            {
                ShowError(LanguageStrings.AppError, err.Message);
            }

            UpdateUI(lvItems.SelectedItems.Count > 0);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadCelebrities()
        {
            Celebrities celebs = Celebrities.Get();

            lvItems.Items.Clear();

            foreach (Celebrity celeb in celebs)
            {
                ListViewItem item = new ListViewItem(celeb.Name);
                item.SubItems.Add(celeb.ID.ToString());

                lvItems.Items.Add(item);
            }

            UpdateUI(lvItems.SelectedItems.Count > 0);
        }

        private void LoadImages()
        {
            cmbImages.Items.Clear();

            string imageRoot = AppController.POSFolder(ImageTypes.Celebrities);

            string[] files = Directory.GetFiles(imageRoot, StringConstants.IMAGE_SEARCH_CELEBRITIES);

            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                int idx = cmbImages.Items.Add(fileName);

                if (_currentCeleb != null && file.EndsWith(_currentCeleb.Image))
                {
                    cmbImages.SelectedIndex = idx;
                }
            }
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
                if ((_currentCeleb != null && _currentCeleb.ID != -1) | (_currentCeleb == null))
                    _currentCeleb = Celebrities.Get(Shared.Utilities.StrToInt(
                        lvItems.SelectedItems[0].SubItems[1].Text, -1));

                if (_currentCeleb != null)
                {
                    txtDescription.Text = _currentCeleb.Description;
                    txtName.Text = _currentCeleb.Name;
                    cmbImages.SelectedIndex = cmbImages.Items.IndexOf(_currentCeleb.Image);
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

        private void cmbImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            imagePicture.ImageLocation = AppController.POSFolder(ImageTypes.Celebrities) + cmbImages.SelectedItem;
            IsEditing = true;
            UpdateUI(lvItems.SelectedItems.Count > 0);
        }

        #endregion Private Methods
    }
}
