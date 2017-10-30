using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;
using Library.BOL.Staff;

using POS.Staff.Classes;

namespace POS.Staff.Controls.Wizards.StaffSick.CreateSickness
{
    public partial class Step1 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private SicknessWizardSettings _returnToWork;

        #endregion Private Members

        #region Constructors

        public Step1()
        {
            InitializeComponent();
        }

        public Step1(SicknessWizardSettings returnToWork)
            : this()
        {
            _returnToWork = returnToWork;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblStaffMember.Text = LanguageStrings.AppStaffMemberSelect;
        }

        public override bool SkipPage()
        {
            return (_returnToWork.Staff != null);
        }

        public override void PageShown()
        {
            if (!_returnToWork.AllowSelectStaff)
                MainWizardForm.SelectNextPage();

            LoadStaff();

            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.StaffSickStep1;
        }

        public override bool NextClicked()
        {
            if (!_returnToWork.AllowSelectStaff)
                return (true);

            if (cmbStaffMember.SelectedIndex == -1)
            {
                ShowError(LanguageStrings.AppStaffMember, LanguageStrings.AppStaffSelect);
                return (false);
            }

            _returnToWork.Staff = (StaffMember)cmbStaffMember.SelectedItem;
            return (true);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadStaff()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                cmbStaffMember.Items.Clear();

                Library.BOL.Staff.StaffMembers allStaff = Library.BOL.Staff.StaffMembers.All();

                foreach (StaffMember member in allStaff)
                {
                    cmbStaffMember.Items.Add(member);
                }
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void cmbStaffMember_Format(object sender, ListControlConvertEventArgs e)
        {
            StaffMember staff = (StaffMember)e.ListItem;
            e.Value = staff.UserRecord.UserName;
        }

        #endregion Private Methods
    }
}
