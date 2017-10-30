﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;
using Library;
using Library.BOL.Staff;
using Library.BOL.Users;

namespace POS.Staff.Controls.Wizards.StaffAdd
{
    public partial class Step5 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private StaffMember _staffMember;

        #endregion Private Members

        #region Constructors

        public Step5(StaffMember staff)
        {
            InitializeComponent();

            _staffMember = staff;

            LoadStaff();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblMemberLevel.Text = LanguageStrings.AppMemberLevel;
            lblCopyPermissions.Text = LanguageStrings.AppStaffMemberCopyPermissions;
            lblManager.Text = LanguageStrings.AppStaffMemberReportingTo;
        }

        public override bool BeforeFinish()
        {
            User newStaff = User.UserGet(_staffMember.UserID);

            newStaff.MemberLevel = (MemberLevel)Convert.ToInt32(cmbMemberLevel.Items[cmbMemberLevel.SelectedIndex]);

            newStaff.Save();
            _staffMember.Save();

            Library.BOL.Staff.Staff.ManagerSet(newStaff, (User)cmbManager.SelectedItem);

            if (cmbPermissions.SelectedIndex > -1)
            {
                newStaff.Permissions = ((User)cmbPermissions.SelectedItem).Permissions;
                newStaff.PermissionsAccounts = ((User)cmbPermissions.SelectedItem).PermissionsAccounts;
                newStaff.PermissionsCalendar = ((User)cmbPermissions.SelectedItem).PermissionsCalendar;
                newStaff.PermissionsReports = ((User)cmbPermissions.SelectedItem).PermissionsReports;
                newStaff.PermissionsStaff = ((User)cmbPermissions.SelectedItem).PermissionsStaff;
                newStaff.PermissionsStock = ((User)cmbPermissions.SelectedItem).PermissionsStock;
                newStaff.PermissionsWebsite = ((User)cmbPermissions.SelectedItem).PermissionsWebsite;
            }

            return (true);
        }

        public override bool CanGoFinish()
        {
            return (cmbMemberLevel.SelectedIndex > -1 && cmbManager.SelectedIndex > -1);
        }

        public override void PageShown()
        {
            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.StaffCreateStep5;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadStaff()
        {
            cmbManager.Items.Clear();
            cmbPermissions.Items.Clear();

            Users staffMembers = User.StaffMembers(false);

            foreach (User staff in staffMembers)
            {
                cmbManager.Items.Add(staff);
                cmbPermissions.Items.Add(staff);
            }
        }

        private void cmbMemberLevel_Format(object sender, ListControlConvertEventArgs e)
        {
            MemberLevel memberlevel = (MemberLevel)Convert.ToInt32(e.ListItem);
            e.Value = memberlevel.ToString();
        }

        private void cmbMemberLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainWizardForm.UpdateUI();
        }

        private void cmbManager_Format(object sender, ListControlConvertEventArgs e)
        {
            User user = (User)e.ListItem;
            e.Value = user.UserName;
        }

        #endregion Private Methods
    }
}