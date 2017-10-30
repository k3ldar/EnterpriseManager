using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;
using Library.BOL.Staff;
using Library.BOL.Therapists;
using POS.Staff.Classes;

namespace POS.Staff.Controls.Wizards.Commission.BonusPayments
{
    public partial class Step2 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private PayCommissionSettings _settings;

        #endregion Private Members

        #region Constructors

        public Step2(PayCommissionSettings settings)
        {
            InitializeComponent();

            _settings = settings;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            base.LanguageChanged(culture);

            lblSelectUsers.Text = LanguageStrings.AppSelectStaffCommissionSplit;

            btnSelectAll.Text = LanguageStrings.AppMenuSelectAll;
            btnUnSelectAll.Text = LanguageStrings.AppMenuUnSelectAll;
            btnInvertSelection.Text = LanguageStrings.AppMenuInvertSelection;
        }

        public override void PageShown()
        {
            LoadStaff();    
        }

        public override bool NextClicked()
        {
            Library.BOL.Staff.StaffMembers staffList = new Library.BOL.Staff.StaffMembers();

            for (int i = 0; i < clbStaff.Items.Count; i++)
            {
                if (clbStaff.GetItemChecked(i))
                {
                    staffList.Add((StaffMember)clbStaff.Items[i]);
                }
            }

            if (staffList.Count == 0)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppCommissionSelect1Employee);
                return (false);
            }

            _settings.StaffMembers = staffList;

            return (true);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadStaff()
        {
            clbStaff.Items.Clear();

            foreach (StaffMember staff in Library.BOL.Staff.StaffMembers.All())
            {
                int idx = clbStaff.Items.Add(staff);

                Therapist ther = Therapists.GetTherapist(staff.UserID);

                if (_settings.StaffMembers != null && _settings.StaffMembers.Count > 0)
                {
                    bool found = false;

                    foreach (StaffMember preSelected in _settings.StaffMembers)
                    {
                        if (preSelected.UserID == staff.UserID)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (found)
                        clbStaff.SetItemChecked(idx, true);
                }
            }
        }

        private void clbStaff_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((StaffMember)e.ListItem).UserRecord.UserName;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbStaff.Items.Count; i++)
            {
                clbStaff.SetItemChecked(i, true);
            }
        }

        private void btnUnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbStaff.Items.Count; i++)
            {
                clbStaff.SetItemChecked(i, false);
            }
        }

        private void btnInvertSelection_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbStaff.Items.Count; i++)
            {
                clbStaff.SetItemChecked(i, !clbStaff.GetItemChecked(i));
            }
        }

        #endregion Private Methods
    }
}
