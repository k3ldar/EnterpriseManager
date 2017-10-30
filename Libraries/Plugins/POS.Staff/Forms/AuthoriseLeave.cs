using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;

namespace POS.Staff.Forms
{
    public partial class AuthoriseLeave : POS.Base.Forms.BaseForm
    {
        public AuthoriseLeave()
        {
            InitializeComponent();
            requestsAuthorise.AllStaff = true;
        }
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.StaffAuthoriseLeave;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppStaffAuthoriseLeave;

            btnAuthorise.Text = LanguageStrings.AppMenuButtonAuthorise;
            btnClose.Text = LanguageStrings.AppMenuButtonClose;

            lblApprovePrompt.Text = LanguageStrings.AppStaffAuthoriseLeavePrompt;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            requestsAuthorise.AuthoriseAllChecked();
        }
    }
}
