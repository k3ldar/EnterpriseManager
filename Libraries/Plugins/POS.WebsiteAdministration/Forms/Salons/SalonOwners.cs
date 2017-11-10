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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: SalonOwners.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  07/06/2017  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Windows.Forms;

using Languages;
using Library.BOL.Users;
using POS.Base.Classes;

namespace POS.WebsiteAdministration.Forms.Salons
{
    public partial class SalonOwners : POS.Base.Controls.BaseTabControl
    {
        #region Constructors

        public SalonOwners()
        {
            InitializeComponent();

            toolStripMainAdd.Image = POS.Base.Icons.AddIcon();
            toolStripMainDelete.Image = POS.Base.Icons.DeleteIcon();
            toolStripMainEdit.Image = POS.Base.Icons.EditIcon();
            toolStripMainRefresh.Image = POS.Base.Icons.RefreshIcon();

            toolStripMainEdit.Enabled = false;
            RebuildContextMenu(toolStripMain, contextMenuList);

            SearchSalonOwners();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppSalonOwners;

            colHeaderBusinessName.Text = LanguageStrings.AppBusinessName;
            colHeaderDiscount.Text = LanguageStrings.AppDiscount;
            colHeaderEmailAddress.Text = LanguageStrings.AppEmail;
            colHeaderName.Text = LanguageStrings.AppName;

            toolStripMainAdd.Text = LanguageStrings.AppHintNew;
            toolStripMainDelete.Text = LanguageStrings.AppHintDelete;
            toolStripMainRefresh.Text = LanguageStrings.AppHintRefresh;
            toolStripMainEdit.Text = LanguageStrings.AppHintEdit;

        }

        protected override void SetPermissions()
        {
            toolStripMainAdd.Enabled = false;
            toolStripMainDelete.Enabled = false;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void SearchSalonOwners()
        {
            this.Cursor = Cursors.WaitCursor;
            lstUsers.BeginUpdate();
            try
            {
                toolStripMainEdit.Enabled = false;
                lstUsers.Items.Clear();

                Users users;

                users = User.SalonOwners();

                foreach (User user in users)
                {
                    ListViewItem item = lstUsers.Items.Add(user.UserName);
                    item.SubItems.Add(user.BusinessName);
                    item.SubItems.Add(user.Email);
                    item.SubItems.Add(String.Format(StringConstants.PREFIX_AND_SUFFIX,
                        user.AutoDiscount, StringConstants.SYMBOL_PERCENT));
                    item.SubItems.Add(user.ID.ToString());
                }

                string StatusText = LanguageStrings.AppSalonOwnersFound;

                toolStripStatusLabelCount.Text = String.Format(StatusText, users.Count);
            }
            finally
            {
                lstUsers.EndUpdate();
                this.Cursor = Cursors.Arrow;
            }
        }

        private void lstUsers_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in lstUsers.SelectedItems)
            {
                Library.BOL.Users.User member = User.UserGet(Convert.ToInt32(itm.SubItems[4].Text));

                if (member != null)
                {
                    PluginManager.RaiseEvent(new POS.Base.Plugins.NotificationEventArgs(member));
                    SearchSalonOwners();                 
                }
            }
        }

        #endregion Private Methods

        private void toolStripMainAdd_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMainDelete_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMainEdit_Click(object sender, EventArgs e)
        {
            lstUsers_DoubleClick(sender, e);
        }

        private void toolStripMainRefresh_Click(object sender, EventArgs e)
        {
            SearchSalonOwners();
        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripMainEdit.Enabled = lstUsers.SelectedItems.Count > 0;
        }
    }
}
