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
    public partial class ApproveLeave : POS.Base.Forms.BaseForm
    {
        public ApproveLeave()
        {
            InitializeComponent();
            requestsApprove.AllStaff = true;
        }
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.StaffApproveLeave;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppStaffApproveLeave;

            btnApprove.Text = LanguageStrings.AppMenuButtonApprove;
            btnClose.Text = LanguageStrings.AppMenuButtonClose;

            lblApprovePrompt.Text = LanguageStrings.AppStaffApproveLeavePrompt;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            requestsApprove.ApproveAllChecked();
        }
    }
}
