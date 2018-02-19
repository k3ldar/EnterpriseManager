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
 *  File: AdminTipsAndTricksEdit.cs
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
using Library.BOL.TipsTricks;

using POS.Base.Classes;

namespace POS.WebsiteAdministration.Forms.TipsAndTricks
{
    public partial class AdminTipsAndTricksEdit : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private TipsTrick _Tip;

        #endregion Private Members

        #region Constructors

        public AdminTipsAndTricksEdit(TipsTrick Tip)
        {
            _Tip = Tip;

            InitializeComponent();

            txtName.Text = _Tip.Name;
            txtDescription.Text = _Tip.Description;
            cbShowOnWeb.Checked = _Tip.ShowOnWeb;
            spnPopupID.Value = _Tip.PopUpID;
        }

        #endregion Costructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.WebTipsAndTricksEdit;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppTipTrickEditAdmin;

            cbShowOnWeb.Text = LanguageStrings.AppShowOnWebsite;

            lblDescription.Text = LanguageStrings.AppDescription;
            lblName.Text = LanguageStrings.AppName;
            lblPopupID.Text = LanguageStrings.AppPopupID;

            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnSave.Text = LanguageStrings.AppMenuButtonSave;
            btnSpellCheck.Text = LanguageStrings.AppSpellCheck;
        }

        protected override void SetPermissions()
        {
            btnSave.Enabled = AppController.ActiveUser.HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.AdministerTipsTricks);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Tip.Name = txtName.Text;
            _Tip.PopUpID = (int)spnPopupID.Value;
            _Tip.Description = txtDescription.Text;
            _Tip.ShowOnWeb = cbShowOnWeb.Checked;
            _Tip.Save();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnSpellCheck_Click(object sender, EventArgs e)
        {
            SharedControls.SpellChecker.SpellChecker.ShowSpellChecker(this, AppController.LocalSettings.CustomDictionary,
                AppController.POSFolder(FolderType.Dictionary, true), txtName, txtDescription);
        }

        #endregion Private Methods
    }
}
