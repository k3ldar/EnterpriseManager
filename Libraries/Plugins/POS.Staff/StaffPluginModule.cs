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
 *  File: StaffPluginModule.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

using SharedControls.Forms;
using Languages;

using POS.Staff.Forms;

using Library;
using Library.BOL.Therapists;
using Library.BOL.Users;

using POS.Base.Classes;
using POS.Base.Plugins;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation
#pragma warning disable IDE0028 // collection initialization can be simplified

namespace POS.Staff
{
    class StaffPluginModule : BasePlugin
    {
        #region Private Members

        private StaffCard _staffTab;
        private StaffExpensesCard _staffExpenses;
        private StaffLeaveCard _staffLeave;

        private ClientCommissionCard _clientCommissionData;
        private StaffCommissionCard _staffCommissionData;

        private ToolStripMenuItem menuAdministrationStaff;
        private ToolStripMenuItem menuAdminStaffManage;
        private ToolStripSeparator menuAdminStaffManageSeperator;

        private ToolStripMenuItem menuAdminStaffRequestLeave;
        private ToolStripMenuItem menuAdminStaffApproveLeave;
        private ToolStripMenuItem menuAdminStaffAuthoriseLeave;
        private ToolStripSeparator menuAdminStaffLeaveSeperator;
        private ToolStripMenuItem menuAdminStaffViewLeaveRequests;

        private ToolStripSeparator menuAdminStaffSickSeperator;
        private ToolStripMenuItem menuAdminStaffSickAddSickRecord;

        private ToolStripSeparator menuAdminStaffCommissionSeperator;
        private ToolStripMenuItem menuAdminStaffCommission;

        private ToolStripMenuItem menuAdminStaffCommissionPools;
        private ToolStripMenuItem menuAdminStaffCommissionPoolRegenerate;
        private ToolStripMenuItem menuAdminStaffCommissionPoolData;
        private ToolStripMenuItem menuAdminStaffCommissionPoolPay;

        private ToolStripMenuItem menuAdminStaffCommissionClient;
        private ToolStripMenuItem menuAdminStaffCommissionClientRegenerate;
        private ToolStripMenuItem menuAdminStaffCommissionClientData;

        private ToolStripMenuItem menuAdminStaffCommissionBonus;

        private ToolStripMenuItem menuAdminStaffExpenses;

        #endregion Private Members

        #region Constructors

        public StaffPluginModule(Form parent)
            : base(parent)
        {

        }

        #endregion Constructors

        #region Overridden Methods

        public override PluginVersion Version()
        {
            return (PluginVersion.Version1);
        }

        public override string PluginName()
        {
            return (LanguageStrings.AppPluginStaff);
        }

        public override bool CanUnload()
        {
            return (true);
        }

        public override void Unload()
        {

        }

        public override bool BeforeLoad()
        {
            return (true);
        }

        public override void AfterLoad()
        {

        }

        public override void UpdateLanguage(CultureInfo culture)
        {
            menuAdministrationStaff.Text = LanguageStrings.AppMenuStaff;
            menuAdminStaffManage.Text = LanguageStrings.AppMenuStaffManage;
            menuAdminStaffRequestLeave.Text = LanguageStrings.AppMenuRequestLeave;
            menuAdminStaffApproveLeave.Text = LanguageStrings.AppMenuApproveLeave;
            menuAdminStaffAuthoriseLeave.Text = LanguageStrings.AppMenuAuthoriseLeave;
            menuAdminStaffViewLeaveRequests.Text = LanguageStrings.AppMenuViewLeaveRequests;

            menuAdminStaffCommission.Text = LanguageStrings.AppMenuCommissionPools;
            menuAdminStaffCommissionPools.Text = LanguageStrings.AppMenuPools;
            menuAdminStaffCommissionPoolData.Text = LanguageStrings.AppMenuCommissionPoolData;
            menuAdminStaffCommissionPoolRegenerate.Text = LanguageStrings.AppMenuCommissionPoolGenerate;
            menuAdminStaffCommissionPoolPay.Text = LanguageStrings.AppMenuCommissionPoolPay;

            menuAdminStaffCommissionClient.Text = LanguageStrings.AppMenuCommissionClients;
            menuAdminStaffCommissionClientRegenerate.Text = LanguageStrings.AppMenuCommissionClientGenerate;
            menuAdminStaffCommissionClientData.Text = LanguageStrings.AppMenuCommissionClientData;

            menuAdminStaffCommissionBonus.Text = LanguageStrings.AppMenuBonusPayments;

            menuAdminStaffExpenses.Text = LanguageStrings.AppMenuStaffExpenses;
        }

        public override void LoadAdministrationSettings(FormSettings settingsForm)
        {
            TreeNode parent = null;

            Controls.Settings.StaffSettingsHoliday holiday = new Controls.Settings.StaffSettingsHoliday();

            parent = settingsForm.LoadControlOption(Languages.LanguageStrings.AppStaff,
                LanguageStrings.AppStaffLeaveSettings,
                null, holiday);
            settingsForm.LoadControlOption(Languages.LanguageStrings.AppStaffLeave,
                LanguageStrings.AppStaffLeaveSettings,
                parent, holiday);
            settingsForm.LoadControlOption(Languages.LanguageStrings.AppExpenseSettings,
                LanguageStrings.AppExpenses,
                parent, new Controls.Settings.StaffSettingsExpenses());

            if (AppController.ActiveUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.ManageCommissionPools) ||
                AppController.ActiveUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.ManageClientCommission))
            {
                parent = settingsForm.LoadControlOption(Languages.LanguageStrings.AppCommission,
                    LanguageStrings.AppCommission,
                    null, new Controls.Settings.CommissionSettings());
            }

            if (AppController.ActiveUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.ManageCommissionPools))
            {
                settingsForm.LoadControlOption(Languages.LanguageStrings.AppCommissionPools,
                    LanguageStrings.AppCommissionPools,
                    parent, new Controls.Settings.CommissionPoolSettings());
            }

            if (AppController.ActiveUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.ManageClientCommission))
            {
                settingsForm.LoadControlOption(LanguageStrings.AppCommissionClients,
                    LanguageStrings.AppCommissionClients,
                    parent, new Controls.Settings.ClientCommissionSettings());
            }
        }

        public override void LoadUserSettings(FormSettings settingsForm)
        {

        }

        public override bool CanClose()
        {
            return (true);
        }

        public override void MenuAdd(PluginMenuType menuType, ToolStripMenuItem parentMenu)
        {
        }

        public override void MenuAdd(PluginMenuType menuType, MenuStrip mainMenu)
        {
            CreateStaffMenu(mainMenu);
        }

        public override void MenuDropDown(PluginMenuType menuType)
        {

        }

        public override HomeCards HomeCards()
        {
            HomeCards Result = new HomeCards();

            if (_staffTab == null)
                _staffTab = new StaffCard(this);

            if (_clientCommissionData == null)
                _clientCommissionData = new ClientCommissionCard(this);

            if (_staffCommissionData == null)
                _staffCommissionData = new StaffCommissionCard(this);

            if (_staffExpenses == null)
                _staffExpenses = new StaffExpensesCard(this);

            if (_staffLeave == null)
                _staffLeave = new StaffLeaveCard(this);

            Result.Add(_staffTab);
            Result.Add(_staffLeave);
            Result.Add(_staffExpenses);
            Result.Add(_staffCommissionData);
            Result.Add(_clientCommissionData);

            return (Result);
        }

        #region Notification Items

        /// <summary>
        /// Retrieves Tray Notification Items
        /// </summary>
        /// <returns></returns>
        public override TrayNotificationCollection TrayNotifications()
        {
            TrayNotificationCollection Result = new TrayNotificationCollection();

            Result.Add(new LeaveApprovalRequestsTrayNotification(this));
            Result.Add(new LeaveAuthorisationRequestsTrayNotification(this));

            return (Result);
        }

        #endregion Notification Items

        #region Notification Events

        public override void Notification(NotificationEventArgs e)
        {
            base.Notification(e);

            switch (e.EventName)
            {
                case StringConstants.PLUGIN_EVENT_EDIT_STAFF_MEMBER:
                    EditStaffMember((User)e.EventValue);
                    break;

                case StringConstants.PLUGIN_EVENT_EDIT_STAFF_WORKING_HOURS:
                    EditStaffWorkingHours((Therapist)e.EventValue, (DateTime)e.Param1, (Form)e.Param2);
                    break;
                default:
                    foreach (HomeCard card in HomeCards())
                    {
                        card.EventRaised(e);
                    }

                    break;
            }
        }

        public override void NotificationsGet(ref List<string> names)
        {
            base.NotificationsGet(ref names);
            names.Add(StringConstants.PLUGIN_EVENT_EDIT_STAFF_MEMBER);
            names.Add(StringConstants.PLUGIN_EVENT_EDIT_STAFF_WORKING_HOURS);
            names.Add(StringConstants.PLUGIN_EVENT_LEAVE_ADD);
        }

        #endregion Notification Events

        #endregion Overridden Methods

        #region Private Methods

        private void EditStaffWorkingHours(Therapist therapist, DateTime date, Form parent)
        {
            AdminStaffEditWorkingHours hours = new AdminStaffEditWorkingHours(therapist, date);
            try
            {
                hours.ShowDialog(parent);
            }
            finally
            {
                hours.Dispose();
                hours = null;
            }
        }

        private void EditStaffMember(User user)
        {
        }

        private void CreateStaffMenu(MenuStrip parent)
        {
            menuAdministrationStaff = new ToolStripMenuItem(LanguageStrings.AppMenuStaff);
            menuAdministrationStaff.DropDownOpening += menuAdministrationStaff_DropDownOpening;
            parent.Items.Insert(parent.Items.Count - 2, menuAdministrationStaff);

            menuAdminStaffManage = new ToolStripMenuItem(LanguageStrings.AppMenuStaffManage);
            menuAdminStaffManage.Click += menuAdminStaffManage_Click;
            menuAdminStaffManage.ShortcutKeys = Keys.Alt | Keys.S;
            menuAdministrationStaff.DropDownItems.Add(menuAdminStaffManage);

            menuAdminStaffExpenses = new ToolStripMenuItem(LanguageStrings.AppMenuStaffExpenses);
            menuAdminStaffExpenses.Click += MenuAdminStaffExpenses_Click;
            menuAdminStaffExpenses.ShortcutKeys = Keys.Alt | Keys.X;
            menuAdministrationStaff.DropDownItems.Add(menuAdminStaffExpenses);

            menuAdminStaffManageSeperator = new ToolStripSeparator();
            menuAdministrationStaff.DropDownItems.Add(menuAdminStaffManageSeperator);

            menuAdminStaffRequestLeave = new ToolStripMenuItem(LanguageStrings.AppMenuRequestLeave);
            menuAdminStaffRequestLeave.Click += menuAdminStaffRequestLeave_Click;
            menuAdminStaffRequestLeave.ShortcutKeys = Keys.Alt | Keys.L;
            menuAdministrationStaff.DropDownItems.Add(menuAdminStaffRequestLeave);

            menuAdminStaffApproveLeave = new ToolStripMenuItem(LanguageStrings.AppMenuApproveLeave);
            menuAdminStaffApproveLeave.Click += menuAdminStaffApproveLeave_Click;
            menuAdministrationStaff.DropDownItems.Add(menuAdminStaffApproveLeave);

            menuAdminStaffAuthoriseLeave = new ToolStripMenuItem(LanguageStrings.AppMenuAuthoriseLeave);
            menuAdminStaffAuthoriseLeave.Click += menuAdminStaffAuthoriseLeave_Click;
            menuAdministrationStaff.DropDownItems.Add(menuAdminStaffAuthoriseLeave);

            menuAdminStaffLeaveSeperator = new ToolStripSeparator();
            menuAdministrationStaff.DropDownItems.Add(menuAdminStaffLeaveSeperator);

            menuAdminStaffViewLeaveRequests = new ToolStripMenuItem(LanguageStrings.AppMenuViewLeaveRequests);
            menuAdminStaffViewLeaveRequests.Click += menuAdminStaffViewLeaveRequests_Click;
            menuAdministrationStaff.DropDownItems.Add(menuAdminStaffViewLeaveRequests);

            menuAdminStaffSickSeperator = new ToolStripSeparator();
            menuAdministrationStaff.DropDownItems.Add(menuAdminStaffSickSeperator);

            menuAdminStaffSickAddSickRecord = new ToolStripMenuItem(LanguageStrings.AppMenuStaffBookSick);
            menuAdminStaffSickAddSickRecord.Click += menuAdminStaffSickAddSickRecord_Click;
            menuAdministrationStaff.DropDownItems.Add(menuAdminStaffSickAddSickRecord);

            menuAdminStaffCommissionSeperator = new ToolStripSeparator();
            menuAdministrationStaff.DropDownItems.Add(menuAdminStaffCommissionSeperator);

            menuAdminStaffCommission = new ToolStripMenuItem(LanguageStrings.AppMenuCommissionPools);
            menuAdministrationStaff.DropDownItems.Add(menuAdminStaffCommission);

            menuAdminStaffCommissionPools = new ToolStripMenuItem(LanguageStrings.AppMenuPools);
            menuAdminStaffCommissionPools.Click += menuAdminStaffCommissionPools_Click;
            menuAdminStaffCommission.DropDownItems.Add(menuAdminStaffCommissionPools);

            menuAdminStaffCommissionPoolRegenerate = new ToolStripMenuItem(LanguageStrings.AppMenuCommissionPoolGenerate);
            menuAdminStaffCommissionPoolRegenerate.Click += menuAdminStaffCommissionPoolRegenerate_Click;
            menuAdminStaffCommission.DropDownItems.Add(menuAdminStaffCommissionPoolRegenerate);

            menuAdminStaffCommissionPoolData = new ToolStripMenuItem(LanguageStrings.AppMenuCommissionPoolData);
            menuAdminStaffCommissionPoolData.Click += menuAdminStaffCommissionPoolData_Click;
            menuAdminStaffCommission.DropDownItems.Add(menuAdminStaffCommissionPoolData);

            menuAdminStaffCommissionPoolPay = new ToolStripMenuItem(LanguageStrings.AppMenuCommissionPoolPay);
            menuAdminStaffCommissionPoolPay.Click += menuAdminStaffCommissionPoolPay_Click;
            menuAdminStaffCommission.DropDownItems.Add(menuAdminStaffCommissionPoolPay);


            menuAdminStaffCommissionClient = new ToolStripMenuItem(LanguageStrings.AppMenuCommissionClients);
            menuAdministrationStaff.DropDownItems.Add(menuAdminStaffCommissionClient);

            menuAdminStaffCommissionClientRegenerate = new ToolStripMenuItem(LanguageStrings.AppMenuCommissionClientGenerate);
            menuAdminStaffCommissionClientRegenerate.Click += menuAdminStaffCommissionClientRegenerate_Click;
            menuAdminStaffCommissionClient.DropDownItems.Add(menuAdminStaffCommissionClientRegenerate);

            menuAdminStaffCommissionClientData = new ToolStripMenuItem(LanguageStrings.AppMenuCommissionClientData);
            menuAdminStaffCommissionClientData.Click += menuAdminStaffCommissionClientData_Click;
            menuAdminStaffCommissionClient.DropDownItems.Add(menuAdminStaffCommissionClientData);


            menuAdminStaffCommissionBonus = new ToolStripMenuItem(LanguageStrings.AppMenuBonusPayments);
            menuAdminStaffCommissionBonus.Click += menuAdminStaffCommissionBonus_Click;
            menuAdministrationStaff.DropDownItems.Add(menuAdminStaffCommissionBonus);
        }

        #region Staff Menu

        private void menuAdministrationStaff_DropDownOpening(object sender, EventArgs e)
        {
            menuAdminStaffCommission.Enabled = POS.Base.Classes.AppController.ActiveUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.ManageCommissionPools);
            menuAdminStaffCommissionBonus.Enabled = POS.Base.Classes.AppController.ActiveUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.BonusPayments);
            menuAdminStaffCommissionClient.Enabled = POS.Base.Classes.AppController.ActiveUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.ManageClientCommission);
        }


        private void MenuAdminStaffExpenses_Click(object sender, EventArgs e)
        {
            _staffExpenses.HomeTabButton.ForceClick();
        }

        #endregion Staff Menu

        #region Client Commission

        private void menuAdminStaffCommissionClientRegenerate_Click(object sender, EventArgs e)
        {
            Classes.ClientCommission.GenerateClientCommissionData();
        }

        private void menuAdminStaffCommissionClientData_Click(object sender, EventArgs e)
        {
            _clientCommissionData.HomeTabButton.ForceClick();
        }

        #endregion Client Commission

        #region Bonus Payments

        private void menuAdminStaffCommissionBonus_Click(object sender, EventArgs e)
        {
            Classes.BonusPaymentWizard.GenerateBonusPayment();
        }

        #endregion Bonus Payments

        #region Commission Pools

        private void menuAdminStaffCommissionPoolPay_Click(object sender, EventArgs e)
        {
            Classes.CommissionPoolsWizards.CommissionPoolPay();
        }

        private void menuAdminStaffCommissionPoolRegenerate_Click(object sender, EventArgs e)
        {
            Classes.CommissionPoolsWizards.GenerateCommissionPoolData();
        }

        private void menuAdminStaffCommissionPoolData_Click(object sender, EventArgs e)
        {
            _staffCommissionData.HomeTabButton.ForceClick();
        }

        private void menuAdminStaffCommissionPools_Click(object sender, EventArgs e)
        {
            EditCommissionPools frm = new EditCommissionPools();
            try
            {
                frm.ShowDialog(ParentForm);
            }
            finally
            {
                frm.Dispose();
                frm = null;
            }
        }

        #endregion Commission Pools

        #region Leave

        private void menuAdminStaffAuthoriseLeave_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.AuthoriseLeave) ||
                AppController.ActiveUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.AuthoriseAllLeave))
            {
                AuthoriseLeave authorise = new AuthoriseLeave();
                try
                {
                    authorise.ShowDialog(ParentForm);
                }
                finally
                {
                    authorise.Dispose();
                    authorise = null;
                }
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissions,
                    LanguageStrings.AppPermissionAuthoriseLeave), LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void menuAdminStaffApproveLeave_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.ApproveLeave) ||
                AppController.ActiveUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.ApproveAllLeave))
            {
                ApproveLeave approve = new ApproveLeave();
                try
                {
                    approve.ShowDialog(ParentForm);
                }
                finally
                {
                    approve.Dispose();
                    approve = null;
                }
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissions,
                    LanguageStrings.AppPermissionApproveLeave), LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void menuAdminStaffRequestLeave_Click(object sender, EventArgs e)
        {
            // staff can always request leave for themselves
            StaffRequestLeave frm = new StaffRequestLeave();
            try
            {
                frm.ShowDialog(ParentForm);
            }
            finally
            {
                frm.Dispose();
                frm = null;
            }
        }

        private void menuAdminStaffViewLeaveRequests_Click(object sender, EventArgs e)
        {
            _staffLeave.HomeTabButton.ForceClick();
        }

        #endregion Leave

        #region Staff

        private void menuAdminStaffManage_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AdministerStaffMembers))
            {
                _staffTab.HomeTabButton.ForceClick();
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissions,
                    LanguageStrings.AppPermissionStaffMembers), LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion Staff

        #region Sick Menu Items

        void menuAdminStaffSickAddSickRecord_Click(object sender, EventArgs e)
        {
            if (POS.Base.Classes.AppController.ActiveUser.HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff.BookStaffOffSick))
            {
                Classes.SickLeaveWizard.SickLeaveAdd(null, false, null);
            }
            else
            {
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissions,
                    LanguageStrings.AppPermissionBookStaffSick), LanguageStrings.AppErrorPermisions,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Sick Menu Items

        #endregion Private Methods
    }
}
