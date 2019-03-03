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
 *  Copyright (c) 2010 - 2019 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: AdminCustomerCommentsForm.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Windows.Forms;

using Languages;
using SharedBase.BOL.Helpdesk;

using POS.Base.Classes;

namespace POS.WebsiteAdministration.Forms.CustomerComments
{
    public partial class AdminCustomerCommentsForm : POS.Base.Controls.BaseOptionsControl
    {
        #region Private Members

        private CustomerComment _selectedComment;
        private ToolStripButton btnViewUser;

        #endregion Private Members

        #region Constructors

        public AdminCustomerCommentsForm()
        {
            InitializeComponent();

            AllowAddNew = false;

            if (!AppController.ApplicationRunning)
                return;

            AddToolbarSeperator();
            btnViewUser = new ToolStripButton();
            btnViewUser.Image = Base.Icons.UserIcon();
            btnViewUser.ToolTipText = LanguageStrings.AppHintViewUser;
            btnViewUser.Click += BtnViewUser_Click;
            AddToobarButton(btnViewUser);

            LoadComments();
            UpdateUI(null, false);
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            base.LanguageChanged(culture);

            lblAllComments.Text = LanguageStrings.AppCustomerCommentsAllComments;
            lblComments.Text = LanguageStrings.AppComments;
            lblName.Text = LanguageStrings.AppName;

            cbShowOnWebsite.Text = LanguageStrings.AppShowOnWebsite;

            colHeaderName.Text = LanguageStrings.AppName;
            colHeaderShowOnWebsite.Text = LanguageStrings.AppShowOnWebsite;
        }

        protected override void OnSaveClicked()
        {
            _selectedComment.Comments = txtComments.Text;
            _selectedComment.UserName = txtName.Text;
            _selectedComment.ShowOnWeb = cbShowOnWebsite.Checked;
            _selectedComment.Save();
            LoadComments();
        }

        protected override void OnDeleteClicked()
        {
            _selectedComment.Delete();
            lvComments.Items.Remove(lvComments.SelectedItems[0]);

            LoadComments();
        }

        #endregion Overridden Methods

        #region Private Methods

        private void BtnViewUser_Click(object sender, EventArgs e)
        {
            SharedBase.BOL.Users.User user = SharedBase.BOL.Users.User.UserGet(_selectedComment.UserID);

            if (user != null)
            {
                PluginManager.RaiseEvent(new POS.Base.Plugins.NotificationEventArgs(user));
            }
            else
            {
                ShowInformation(LanguageStrings.AppCustomerFind, LanguageStrings.AppCustomerNotFound);
            }
        }

        private void LoadComments()
        {
            lvComments.Items.Clear();
            SharedBase.BOL.Helpdesk.CustomerComments comments = SharedBase.BOL.Helpdesk.CustomerComments.GetAll();

            foreach (CustomerComment comment in comments)
            {
                ListViewItem lv = new ListViewItem();
                lv.Text = comment.UserName;
                lv.SubItems.Add(comment.ShowOnWeb ? LanguageStrings.AppYes : LanguageStrings.AppNo);
                lv.SubItems.Add(comment.ID.ToString());
                lvComments.Items.Add(lv);
            }
        }

        private void lvComments_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ListViewItem lv = e.Item;

            UpdateUI(lv, e.IsSelected);

            if (e.IsSelected)
            {
                _selectedComment = SharedBase.BOL.Helpdesk.CustomerComments.Get(Shared.Utilities.StrToIntDef(lv.SubItems[2].Text, -1));
                txtName.Text = _selectedComment.UserName;
                txtComments.Text = _selectedComment.Comments;
                cbShowOnWebsite.Checked = _selectedComment.ShowOnWeb;
            }
            else
                _selectedComment = null;

        }

        private void UpdateUI(ListViewItem lv, bool IsSelected)
        {
            bool enabled = lv != null && IsSelected;

            if (!enabled)
            {
                cbShowOnWebsite.Checked = false;
                txtComments.Text = StringConstants.SYMBOL_EMPTY_STRING;
                txtName.Text = StringConstants.SYMBOL_EMPTY_STRING;
            }

            txtComments.Enabled = enabled;
            txtName.Enabled = enabled;
            cbShowOnWebsite.Enabled = enabled;
            btnViewUser.Enabled = enabled;

            AllowDelete = enabled;
            IsEditing = enabled;
            UpdateUI(IsSelected);
        }

        #endregion Private Methods
    }
}
