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
 *  File: AdminTreatmentEdit.cs
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

using SharedBase;
using SharedBase.BOL.Treatments;
using SharedBase.BOL.ValidationChecks;
using POS.Base.Classes;

#pragma warning disable IDE1006

namespace POS.WebsiteAdministration.Forms.Treatments
{
    public partial class AdminTreatmentEdit : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private Treatment _Treat;

        private bool _spellCheckComplete = false;

        #endregion Private Members

        #region Constructors

        public AdminTreatmentEdit(Treatment Treat)
        {
            _Treat = Treat;

            InitializeComponent();
            LoadDurations();
            LoadImages();
            LoadTreatmentGroups();
            LoadTreatment();
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.WebTreatmentEdit;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppTreatmentsEditAdmin;

            lblAssignedTreatmentGroups.Text = LanguageStrings.AppTreatmentsAssignedGroups;
            lblDuration.Text = LanguageStrings.AppTreatmentsDuration;
            lblImage.Text = LanguageStrings.AppPicture;
            lblName.Text = LanguageStrings.AppName;
            lblPrice.Text = LanguageStrings.AppPrice;
            lblSortOrder.Text = LanguageStrings.AppSortOrder;
            lblTreatmentLength.Text = LanguageStrings.AppTreatmentsTreatmentLength;
            lblWebsiteLink.Text = LanguageStrings.AppWebisteLink;

            tabPageDescription.Text = LanguageStrings.AppDescription;
            tabPageTreatmentGroups.Text = LanguageStrings.AppTreatmentGroups;

            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnDelete.Text = LanguageStrings.AppMenuButtonDelete;
            btnSave.Text = LanguageStrings.AppMenuButtonSave;
            btnSpellCheck.Text = LanguageStrings.AppSpellCheck;
        }

        protected override void SetPermissions()
        {
            btnSave.Enabled = AppController.ActiveUser.HasPermissionPOS(
                SecurityEnums.SecurityPermissionsPOS.AllowSave);
            btnDelete.Enabled = AppController.ActiveUser.HasPermissionPOS(
                SecurityEnums.SecurityPermissionsPOS.AllowDelete);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadDurations()
        {
            cmbDuration.Items.Clear();

            for (int i = 1; i <= 15; i++ )
                cmbDuration.Items.Add(String.Format(LanguageStrings.AppMinutes, i * 15));
        }
        
        private void LoadTreatmentGroups()
        {
            lstTreatmentGroups.Items.Clear();

            TreatmentGroups groups = TreatmentGroups.Get();

            foreach (TreatmentGroup group in groups)
            {
                lstTreatmentGroups.Items.Add(group);
            }
        }

        private void LoadTreatment()
        {
            if (!_Treat.Description.Contains(POS.Base.Classes.StringConstants.SYMBOL_CRLF))
                txtDescription.Text = _Treat.Description.Replace(POS.Base.Classes.StringConstants.SYMBOL_RETURN,
                    POS.Base.Classes.StringConstants.SYMBOL_CRLF);
            else
                txtDescription.Text = _Treat.Description;

            txtName.Text = _Treat.Name;
            txtPrice.Text = _Treat.Price;
            txtTreatmentLength.Text = _Treat.TreatmentLength;
            txtWebsiteLink.Text = _Treat.URL;
            spnSortOrder.Value = _Treat.SortOrder;
            cmbDuration.SelectedIndex = cmbDuration.Items.IndexOf(
                String.Format(LanguageStrings.AppMinutes, _Treat.Duration == 0 ? 15 : _Treat.Duration));
            cmbImage.SelectedIndex = cmbImage.Items.IndexOf(_Treat.Image);

            foreach (TreatmentGroup group in _Treat.Groups)
            {
                foreach (object obj in lstTreatmentGroups.Items)
                {
                    TreatmentGroup grp = (TreatmentGroup)obj;

                    if (grp.ID == group.ID)
                    {
                        lstTreatmentGroups.SetItemChecked(lstTreatmentGroups.Items.IndexOf(obj), true);
                        break;
                    }
                }
            }
        }

        private bool SaveTreatment()
        {
            bool Result = false;

            if (cmbImage.SelectedIndex == -1)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppTreatmentSelectImage);
                return (Result);
            }

            _Treat.Description = txtDescription.Text.Replace(
                POS.Base.Classes.StringConstants.SYMBOL_CRLF, POS.Base.Classes.StringConstants.SYMBOL_RETURN);
            _Treat.Name = txtName.Text;
            _Treat.Price = txtPrice.Text;
            _Treat.TreatmentLength = txtTreatmentLength.Text;
            _Treat.URL = txtWebsiteLink.Text;
            _Treat.SortOrder = (int)spnSortOrder.Value;

            string duration = (string)cmbDuration.Items[cmbDuration.SelectedIndex];
            duration = duration.Replace(String.Format(LanguageStrings.AppMinutes, String.Empty), String.Empty);
            _Treat.Duration = Convert.ToInt32(duration);
            _Treat.Image = (string)cmbImage.Items[cmbImage.SelectedIndex];
            cmbImage.SelectedIndex = cmbImage.Items.IndexOf(_Treat.Image);
            _Treat.Save(AppController.ActiveUser);

            Result = true;

            return (Result);
        }

        private void cmbImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string imageRoot = AppController.POSFolder(ImageTypes.WebsiteTreatments);
            imgTreatment.ImageLocation = imageRoot + cmbImage.SelectedItem;
        }

        private void LoadImages()
        {
            cmbImage.Items.Clear();

            string imageRoot = AppController.POSFolder(ImageTypes.WebsiteTreatments);

            string[] files = Directory.GetFiles(imageRoot, StringConstants.IMAGE_SEARCH_WEB_TREATMENTS);

            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                int idx = cmbImage.Items.Add(fileName);

                if (_Treat.Image.EndsWith(fileName, StringComparison.InvariantCultureIgnoreCase))
                {
                    cmbImage.SelectedIndex = idx;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_spellCheckComplete && (txtName.Text != _Treat.Name || 
                txtDescription.Text != _Treat.Description))
            {
                if (ShowQuestion(LanguageStrings.AppSpellCheck, LanguageStrings.AppSpellCheckPrompt))
                {
                    btnSpellCheck_Click(sender, e);
                    return;
                }
                else
                    POSValidation.Add(AppController.ActiveUser, ValidationReasons.IgnoreSpellCheckTreatment,
                        String.Format(LanguageStrings.AppTreatmentValidate, _Treat.ID, 
                        Shared.Utilities.MaximumLength(_Treat.Name, 150)));
            }

            if (SaveTreatment())
                DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AllowDelete))
            {
                if (ShowHardConfirm(LanguageStrings.AppTreatmentsDelete, 
                    LanguageStrings.AppTreatmentsDeletePrompt))
                {
                    _Treat.Delete(AppController.ActiveUser);
                    DialogResult = System.Windows.Forms.DialogResult.Abort;
                }
            }
            else
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppPermissionDeleteTreatments);
            }
        }

        private void lstTreatmentGroups_Format(object sender, ListControlConvertEventArgs e)
        {
            TreatmentGroup group = (TreatmentGroup)e.ListItem;
            e.Value = group.Description;
        }

        private void btnSpellCheck_Click(object sender, EventArgs e)
        {
            SharedControls.SpellChecker.SpellChecker.ShowSpellChecker(this, 
                AppController.LocalSettings.CustomDictionary, 
                AppController.POSFolder(FolderType.Dictionary, true), 
                txtName, txtDescription);
            _spellCheckComplete = true;
        }

        #endregion Private Members
    }
}
