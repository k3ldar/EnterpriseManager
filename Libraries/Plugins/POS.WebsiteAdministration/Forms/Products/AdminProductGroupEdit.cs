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
 *  File: AdminProductGroupEdit.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  07/06/2017  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using Languages;

using Library;
using Library.BOL.Users;
using Library.BOL.Products;
using Library.BOL.Treatments;

using POS.Base.Classes;

namespace POS.WebsiteAdministration.Forms.Products
{
    public partial class AdminProductGroupEdit : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private ProductGroup _Group;
        private TreatmentGroup _TreatGroup;

        #endregion Private Members

        #region Constructors

        public AdminProductGroupEdit(ProductGroup Group)
        {
            _Group = Group;
            _TreatGroup = null;

            InitializeComponent();

            txtGroupName.Text = _Group.Description;
            spnSortOrder.Value = Shared.Utilities.ValueWithin((int)spnSortOrder.Minimum, (int)spnSortOrder.Maximum, _Group.SortOrder);
            txtTagLine.Text = _Group.TagLine;
            cbShowOnWebsite.Checked = _Group.ShowOnWebsite;
            txtURL.Text = _Group.URL;
            lblMemberLevel.Visible = true;
            lblGroupType.Visible = true;
            cmbGroupType.Visible = true;
            cmbMemberLevel.Visible = true;
            txtPrimaryHeader.Text = _Group.MainHeader;
            txtSubHeader.Text = _Group.SubHeader;
            cbShowOnMobilePage.Checked = _Group.MobileWebsite;
            LoadImages();

            cmbMobileImage.SelectedIndex = cmbMobileImage.Items.IndexOf(_Group.MobileImage);

            this.Text = LanguageStrings.AppProductGroupEditAdministration;

            LoadGroupTypes();
            LoadMemberLevels();

            cmbMemberLevel.SelectedIndex = (int)_Group.MemberLevel;
        }

        public AdminProductGroupEdit(TreatmentGroup Group)
        {
            _Group = null;
            _TreatGroup = Group;

            InitializeComponent();

            txtGroupName.Text = _TreatGroup.Description;
            spnSortOrder.Value = _TreatGroup.SortOrder;
            txtTagLine.Text = _TreatGroup.TagLine;
            lblSubHeader.Enabled = false;
            lblPrimaryHeader.Enabled = false;
            txtSubHeader.Enabled = false;
            txtPrimaryHeader.Enabled = false;
            LoadGroupTypes();
            lblGroupType.Visible = true;
            lblGroupType.Enabled = false;
            cmbGroupType.Visible = true;
            cmbGroupType.Enabled = false;
            cmbGroupType.SelectedIndex = 0;

            if (_Group != null)
            {
                cbShowOnWebsite.Checked = _Group.ShowOnWebsite;
                txtURL.Text = _Group.URL;
            }

            this.Text = LanguageStrings.AppProductGroupTreatmentEdit;
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.WebProductGroupEdit;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnDelete.Text = LanguageStrings.AppMenuButtonDelete;
            btnSave.Text = LanguageStrings.AppMenuButtonSave;

            cbShowOnWebsite.Text = LanguageStrings.AppShowOnWebsite;

            lblGroupName.Text = LanguageStrings.AppProductGroupName;
            lblMemberLevel.Text = LanguageStrings.AppMemberLevel;
            lblGroupType.Text = LanguageStrings.AppPrimaryGroup;
            lblSortOrder.Text = LanguageStrings.AppSortOrder;
            lblTagLine.Text = LanguageStrings.AppProductGroupTagLine;
            lblURL.Text = LanguageStrings.AppURL;
            lblSubHeader.Text = LanguageStrings.AppSubHeader;
            lblPrimaryHeader.Text = LanguageStrings.AppHeader;
        }

        protected override void SetPermissions()
        {
            btnSave.Enabled = AppController.ActiveUser.MemberLevel > Library.MemberLevel.AdminReadOnly;
            btnDelete.Enabled = AppController.ActiveUser.MemberLevel == Library.MemberLevel.Admin;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadImages()
        {
            cmbMobileImage.Items.Clear();
            cmbMobileImage.Items.Add(String.Empty);

            XmlTextReader reader = new XmlTextReader(Shared.Utilities.CurrentPath(true) +
                StringConstants.FILE_PRODUCT_IMAGES);

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Text: //Display the text in each element.
                        cmbMobileImage.Items.Add(reader.Value);

                        break;
                }
            }

        }

        private void LoadGroupTypes()
        {
            cmbGroupType.Items.Clear();

            foreach (ProductGroupType groupType in ProductGroupTypes.Get())
            {
                int idx = cmbGroupType.Items.Add(groupType);

                if (_Group != null && groupType.ID == _Group.GroupType.ID)
                    cmbGroupType.SelectedIndex = idx;
            }
        }

        private void LoadMemberLevels()
        {
            cmbMemberLevel.Items.Clear();

            foreach (MemberLevel member in (MemberLevel[])Enum.GetValues(typeof(MemberLevel)))
            {
                cmbMemberLevel.Items.Add(member);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Group != null)
                {
                    _Group.Description = txtGroupName.Text;
                    _Group.SortOrder = (int)spnSortOrder.Value;
                    _Group.TagLine = txtTagLine.Text;
                    _Group.ShowOnWebsite = cbShowOnWebsite.Checked;
                    _Group.URL = txtURL.Text;
                    //_Group.ProductType = PrimaryProductType.Professional; // outdated now
                    _Group.MemberLevel = (MemberLevel)cmbMemberLevel.Items[cmbMemberLevel.SelectedIndex];
                    _Group.MainHeader = txtPrimaryHeader.Text;
                    _Group.SubHeader = txtSubHeader.Text;
                    _Group.GroupType = (ProductGroupType)cmbGroupType.Items[cmbGroupType.SelectedIndex];
                    _Group.MobileWebsite = cbShowOnMobilePage.Checked;
                    _Group.MobileImage = (string)cmbMobileImage.Items[cmbMobileImage.SelectedIndex];

                    _Group.Save(AppController.ActiveUser);
                }
                else
                {
                    _TreatGroup.Description = txtGroupName.Text;
                    _TreatGroup.SortOrder = (int)spnSortOrder.Value;
                    _TreatGroup.TagLine = txtTagLine.Text;
                    //_Group.ShowOnWebsite = cbShowOnWebsite.Checked;
                    //_Group.URL = txtURL.Text;
                    _TreatGroup.Save(AppController.ActiveUser);
                }

                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception error)
            {
                string msg = LanguageStrings.AppErrorUnexpectedDescription;

                if (error.Message.Contains(StringConstants.ERROR_LOCK_CONFLICT))
                    msg = LanguageStrings.AppErrorProductGroupConflict;

                ShowError(LanguageStrings.AppProductGroupSave, msg);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_Group != null)
            {
                if (ShowHardConfirm(LanguageStrings.AppProductGroupDelete, 
                    LanguageStrings.AppProductGroupDeletePrompt))
                {
                    if (_Group.GroupType.GetProducts().Count > 1)
                        ShowInformation(LanguageStrings.AppProductGroupDelete, 
                            LanguageStrings.AppProductGroupDeleteContainsProducts);
                    else
                    {
                        _Group.Delete(AppController.ActiveUser);
                        DialogResult = System.Windows.Forms.DialogResult.Abort;
                    }
                }
            }
            else
            {
                if (ShowHardConfirm(LanguageStrings.AppTreatmentGroupDelete,
                    LanguageStrings.AppTreatmentGroupDeletePrompt))
                {
                    if (_TreatGroup.Treatments.Count > 0)
                        ShowInformation(LanguageStrings.AppTreatmentGroupDelete, 
                            LanguageStrings.AppTreatmentGroupDeleteContainsTreatments);
                    else
                    {
                        _TreatGroup.Delete(AppController.ActiveUser);
                        DialogResult = System.Windows.Forms.DialogResult.Abort;
                    }
                }
            }
        }

        private void cmbGroupType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblGroupName.Enabled = cmbGroupType.SelectedIndex == 0;
            txtGroupName.Enabled = cmbGroupType.SelectedIndex == 0;

            lblPrimaryHeader.Enabled = cmbGroupType.SelectedIndex > 0;
            txtPrimaryHeader.Enabled = cmbGroupType.SelectedIndex > 0;
            lblSubHeader.Enabled = cmbGroupType.SelectedIndex > 0;
            txtSubHeader.Enabled = cmbGroupType.SelectedIndex > 0;
        }

        private void cmbGroupType_Format(object sender, ListControlConvertEventArgs e)
        {
            ProductGroupType item = (ProductGroupType)e.ListItem;
            e.Value = item.Description;
        }

        private void cmbMobileImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            pbMobileImage.ImageLocation = String.Format(ConfigurationSettings.Value(ConfigurationSettings.SYSTEM_CONFIG_BASE_WEB_IMAGES_PRODUCT), cmbMobileImage.SelectedItem);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageGeneral)
                HelpTopic = POS.Base.Classes.HelpTopics.WebProductGroupEdit;
            else
                HelpTopic = POS.Base.Classes.HelpTopics.WebProductGroupEditMobile;
        }

        #endregion Private Methods
    }
}
