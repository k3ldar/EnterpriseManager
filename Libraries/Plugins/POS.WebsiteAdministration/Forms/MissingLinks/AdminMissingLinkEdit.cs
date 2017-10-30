using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;

using Library;
using Library.Utils;
using Library.BOL.Users;
using Library.BOL.MissingLinks;

using POS.Base.Classes;

namespace POS.WebsiteAdministration.Forms.MissingLinks
{
    public partial class AdminMissingLinkEdit : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private MissingLink _Link;

        #endregion Private Members

        #region Constructors

        public AdminMissingLinkEdit(MissingLink link)
        {
            _Link = link;

            InitializeComponent();

            txtMissingLink.Text = _Link.DeprecatedLink;
            txtRedirectLink.Text = _Link.RedirectLink;
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.WebMissingLinkEdit;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppMissingLinksAdministration;

            lblMissingLink.Text = LanguageStrings.AppMissingLinkMissingPage;
            lblRedirectLink.Text = LanguageStrings.AppMissingLinkRedirectPage;

            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnDelete.Text = LanguageStrings.AppMenuButtonDelete;
            btnSave.Text = LanguageStrings.AppMenuButtonSave;
        }

        protected override void SetPermissions()
        {
            btnSave.Enabled = AppController.ActiveUser.MemberLevel > Library.MemberLevel.AdminReadOnly;
            btnDelete.Enabled = AppController.ActiveUser.MemberLevel == Library.MemberLevel.Admin;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Link.ID == -1)
            {
                AppController.Administration.MissingLinkAdd(txtMissingLink.Text, txtRedirectLink.Text);
            }
            else
            {
                _Link.RedirectLink = txtRedirectLink.Text;
                _Link.DeprecatedLink = txtMissingLink.Text;
                _Link.Save();
            }


            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ShowHardConfirm(LanguageStrings.AppMissingLinkDelete, LanguageStrings.AppMissingLinkDeletePrompt))
            {
                _Link.Delete();
                DialogResult = System.Windows.Forms.DialogResult.Abort;
            }
        }

        #endregion Private Methods
    }
}
