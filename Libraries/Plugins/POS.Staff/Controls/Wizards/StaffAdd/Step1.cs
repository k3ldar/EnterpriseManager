using System;

using Languages;
using Library.BOL.Staff;
using Library.BOL.Users;
using POS.Base.Forms;

namespace POS.Staff.Controls.Wizards.StaffAdd
{
    public partial class Step1 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private User _newStaffMember = null;
        private StaffMember _staffMember;

        #endregion Private Members

        #region Constructors

        public Step1(StaffMember staff)
        {
            InitializeComponent();

            _staffMember = staff;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblSelectNewStaffMember.Text = LanguageStrings.AppStaffSelectNewStaffMember;
            btnSelect.Text = LanguageStrings.AppMenuButtonSelect;
            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.StaffCreateStep1;
        }

        public override void PageShown()
        {
            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.StaffCreateStep1;
        }

        public override bool NextClicked()
        {
            if (_newStaffMember == null)
            {
                ShowError(LanguageStrings.AppStaffCreateNew, LanguageStrings.AppStaffSelectNewStaffMember);
                return (false);
            }

            if (_newStaffMember.MemberLevel >= Library.MemberLevel.StaffMember)
            {
                ShowError(LanguageStrings.AppStaffCreateNew, LanguageStrings.AppStaffCreateNewAlreadyStaff);
                return (false);
            }

            _staffMember.UserID = _newStaffMember.ID;

            return (true);
        }

        public override bool CanGoNext()
        {
            return (_newStaffMember != null);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectUser selUser = new SelectUser(false);
            try
            {
                selUser.ShowDialog(this);
                _newStaffMember = selUser.SelectedUser;

                if (_newStaffMember != null)
                    txtStaffMemberName.Text = _newStaffMember.UserName;
                else
                    txtStaffMemberName.Text = String.Empty;

                MainWizardForm.UpdateUI();
            }
            finally
            {
                selUser.Dispose();
                selUser = null;
            }
        }

        #endregion Private Methods
    }
}
