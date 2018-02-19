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
 *  File: AdminMissingLinkEdit.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
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
