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
 *  File: AdminTreatmentGroupEdit.cs
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
using SharedBase.BOL.Products;
using SharedBase.BOL.Treatments;

using POS.Base.Classes;

#pragma warning disable IDE1006

namespace POS.WebsiteAdministration.Forms.Treatments
{
    public partial class AdminTreatmentGroupEdit : Base.Forms.BaseForm
    {
        #region Private Members

        private TreatmentGroup _treatGroup;

        #endregion Private Members

        #region Constructors

        public AdminTreatmentGroupEdit()
        {
            InitializeComponent();

        }

        public AdminTreatmentGroupEdit(TreatmentGroup Group)
            : this()
        {
            _treatGroup = Group;

            txtGroupName.Text = _treatGroup.Description;
            spnSortOrder.Value = _treatGroup.SortOrder;
            txtTagLine.Text = _treatGroup.TagLine;

            this.Text = LanguageStrings.AppProductGroupTreatmentEdit;
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            tabControl1_SelectedIndexChanged(this, e);
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnDelete.Text = LanguageStrings.AppMenuButtonDelete;
            btnSave.Text = LanguageStrings.AppMenuButtonSave;

            lblGroupName.Text = LanguageStrings.AppProductGroupName;
            lblSortOrder.Text = LanguageStrings.AppSortOrder;
            lblTagLine.Text = LanguageStrings.AppProductGroupTagLine;
        }

        protected override void SetPermissions()
        {
            btnSave.Enabled = AppController.ActiveUser.MemberLevel > SharedBase.MemberLevel.AdminReadOnly;
            btnDelete.Enabled = AppController.ActiveUser.MemberLevel >= SharedBase.MemberLevel.AdminUpdateDelete;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _treatGroup.Description = txtGroupName.Text;
                _treatGroup.SortOrder = (int)spnSortOrder.Value;
                _treatGroup.TagLine = txtTagLine.Text;
                //_Group.ShowOnWebsite = cbShowOnWebsite.Checked;
                //_Group.URL = txtURL.Text;
                _treatGroup.Save(AppController.ActiveUser);

                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception error)
            {
                string msg = LanguageStrings.AppErrorUnexpectedDescription;

                if (error.Message.Contains(POS.Base.Classes.StringConstants.ERROR_LOCK_CONFLICT))
                    msg = LanguageStrings.AppErrorProductGroupConflict;

                ShowError(LanguageStrings.AppProductGroupSave, msg);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ShowHardConfirm(LanguageStrings.AppTreatmentGroupDelete,
                LanguageStrings.AppTreatmentGroupDeletePrompt))
            {
                if (_treatGroup.Treatments.Count > 0)
                    ShowInformation(LanguageStrings.AppTreatmentGroupDelete, 
                        LanguageStrings.AppTreatmentGroupDeleteContainsTreatments);
                else
                {
                    _treatGroup.Delete(AppController.ActiveUser);
                    DialogResult = System.Windows.Forms.DialogResult.Abort;
                }
            }
        }

        private void cmbGroupType_Format(object sender, ListControlConvertEventArgs e)
        {
            ProductGroupType item = (ProductGroupType)e.ListItem;
            e.Value = item.Description;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == tabPageGeneral)
                HelpTopic = POS.Base.Classes.HelpTopics.OnlineTreatmetGroupEditGeneral;
        }

        #endregion Private Methods
    }
}
