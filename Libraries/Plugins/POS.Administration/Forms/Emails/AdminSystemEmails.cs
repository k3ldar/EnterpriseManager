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
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: AdminSystemEmails.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.ComponentModel;
using System.Windows.Forms;

using Languages;

using SharedBase.BOL.Mail;

using POS.Base.Classes;

#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable IDE0017 // Object Initialization can be simplified

namespace POS.Administration.Forms.Emails
{
    public partial class AdminSystemEmails : POS.Base.Controls.BaseOptionsControl
    {
        #region Private / Protected Members

        private bool _changed = false;
        private SystemEmail _currentEmail = null;

        #endregion Private / Protected Members

        #region Constructors

        public AdminSystemEmails()
            : base()
        {
            InitializeComponent();

            if (!Base.Classes.AppController.ApplicationRunning)
                return;

            AddToolbarSeperator();

            ToolStripButton spellChecker = new ToolStripButton();
            spellChecker.Image = Base.Icons.SpellCheck();
            spellChecker.ToolTipText = LanguageStrings.AppSpellCheck;
            spellChecker.Click += SpellChecker_Click;
            AddToobarButton(spellChecker);

            LoadEmails();
            AllowAddNew = false;
            AllowDelete = false;

            UpdateUI(true);
        }

        #endregion Constructors

        #region Overridden Methods


        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            base.LanguageChanged(culture);

            grpEmails.HeaderText = LanguageStrings.AppEmails;
            grpKey.HeaderText = LanguageStrings.AppKey;
            lblKey.Text = LanguageStrings.AppSystemEmailsKey;
            lblMessage.Text = LanguageStrings.AppMessage;
            lblSubject.Text = LanguageStrings.AppSubject;
            cbAllowSend.Text = LanguageStrings.AppAllowEmailSend;
        }

        protected override void OnSaveClicked()
        {
            CheckSaveEmail(false);
        }

        #endregion Overridden Methods

        #region Private Methods


        private void SpellChecker_Click(object sender, EventArgs e)
        {
            SharedControls.SpellChecker.SpellChecker.ShowSpellChecker(null,
                AppController.LocalSettings.CustomDictionary,
                AppController.POSFolder(FolderType.Dictionary, true),
                txtSubject, txtMessage);
        }

        /// <summary>
        /// Loads emails
        /// </summary>
        private void LoadEmails()
        {
            lstEmails.Items.Clear();
            SystemEmails emails = SystemEmails.Get();

            foreach (SystemEmail email in emails)
                lstEmails.Items.Add(email);

            lstEmails.SelectedIndex = 0;
        }

        /// <summary>
        /// Checks the currently selected email and prompt's to save changes if any have been made
        /// </summary>
        private void CheckSaveEmail(bool prompt)
        {
            // do we need to save the current recrod?
            if (_changed)
            {
                if (!prompt || (prompt && ShowHardConfirm(LanguageStrings.AppSystemEmails,
                    LanguageStrings.AppSystemEmailsPrompt)))
                {
                    _currentEmail.Subject = txtSubject.Text;
                    _currentEmail.Message = txtMessage.Text;
                    _currentEmail.AllowSend = cbAllowSend.Checked;
                    _currentEmail.Save();
                    _changed = false;
                    IsEditing = false;
                    UpdateUI(true);
                }
            }
        }

        private void lstEmails_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSaveEmail(_changed);

            SystemEmail email = (SystemEmail)lstEmails.Items[lstEmails.SelectedIndex];
            _currentEmail = email;
            txtMessage.Text = email.Message;
            txtSubject.Text = email.Subject;
            cbAllowSend.Checked = email.AllowSend;
            _changed = false;
            IsEditing = false;
            UpdateUI(true);

        }

        private void lstEmails_Format(object sender, ListControlConvertEventArgs e)
        {
            SystemEmail email = (SystemEmail)e.ListItem;
            e.Value = email.Name;
        }

        private void txtSubject_TextChanged(object sender, EventArgs e)
        {
            if (!_changed)
                _changed = true;

            IsEditing = true;
            UpdateUI(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CheckSaveEmail(false);
        }

        private void grpEmails_BeforeCollapse(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void lstEmails_SizeChanged(object sender, EventArgs e)
        {
            lstEmails.Left = 3;
        }

        private void lblKey_SizeChanged(object sender, EventArgs e)
        {
            lblKey.Left = 0;
        }

        #endregion Private Methods
    }
}
