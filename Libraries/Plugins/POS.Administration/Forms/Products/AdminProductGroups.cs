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
 *  File: AdminProductGroups.cs
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

using Library;
using Library.BOL.Products;

using SharedControls.Classes;

using POS.Base.Classes;

namespace POS.Administration.Forms.Products
{
    public partial class AdminProductGroups : POS.Base.Controls.BaseTabControl
    {
        #region Private Members

        private WebsiteAdministration _Admin;
        private ProductGroups _Groups;

        #endregion Private Members

        #region Constructors

        public AdminProductGroups(WebsiteAdministration Admin)
        {
            _Admin = Admin;

            InitializeComponent();

            toolStripMainAdd.Image = POS.Base.Icons.AddIcon();
            toolStripMainDelete.Image = POS.Base.Icons.DeleteIcon();
            toolStripMainEdit.Image = POS.Base.Icons.EditIcon();
            toolStripMainRefresh.Image = POS.Base.Icons.RefreshIcon();
            toolStripMainDelete.Enabled = false;
            toolStripMainEdit.Enabled = false;

            RebuildContextMenu(toolStripMain, contextMenuList);

            LoadGroups();
        }

        #endregion Constructors

        #region Overridden Methods
        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            toolStripMainAdd.Text = LanguageStrings.AppMenuButtonNew;

            colHeaderGroupName.Text = LanguageStrings.AppProductGroupName;
            colHeaderPrimaryGroup.Text = LanguageStrings.AppPrimaryGroup;
            colHeaderSortOrder.Text = LanguageStrings.AppSortOrder;

            toolStripMainAdd.Text = LanguageStrings.AppHintNew;
            toolStripMainDelete.Text = LanguageStrings.AppHintDelete;
            toolStripMainRefresh.Text = LanguageStrings.AppHintRefresh;
            toolStripMainEdit.Text = LanguageStrings.AppHintEdit;
        }

        protected override void SetPermissions()
        {
            toolStripMainAdd.Enabled = AppController.ActiveUser.MemberLevel > MemberLevel.AdminReadOnly;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadGroups()
        {
            this.Cursor = Cursors.WaitCursor;
            lstProductGroups.BeginUpdate();
            try
            {
                bool setRightToLeft = false;

                lstProductGroups.Items.Clear();

                _Groups = _Admin.ProductGroupsGet(1, 1000);

                foreach (ProductGroup group in _Groups)
                {
                    if (!setRightToLeft && Shared.Utilities.IsRightToLeftCharacter(group.Description))
                        setRightToLeft = true;

                    ListViewItem item = lstProductGroups.Items.Add(group.Description);
                    item.SubItems.Add(group.SortOrder.ToString());
                    item.SubItems.Add(group.GroupType.Description);
                    item.SubItems.Add(group.ID.ToString());
                }

                string StatusText = LanguageStrings.AppProductGroupsFound;

                if (_Groups.Count == 1)
                    StatusText = LanguageStrings.AppProductGroupFound;

                toolStripStatusLabelCount.Text = String.Format(StatusText, _Groups.Count);

                lstProductGroups.RightToLeft = setRightToLeft ? RightToLeft.Yes : RightToLeft.No;
            }
            finally
            {
                lstProductGroups.EndUpdate();
                this.Cursor = Cursors.Arrow;
            }
        }

        private void lstProductGroups_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in lstProductGroups.SelectedItems)
            {
                Library.BOL.Products.ProductGroup group = _Admin.ProductGroupGet(
                    Convert.ToInt32(itm.SubItems[3].Text));

                if (group != null)
                {
                    AdminProductGroupEdit productEdit = new AdminProductGroupEdit(group);
                    try
                    {
                        productEdit.ShowDialog(this);
                        LoadGroups();
                        break;
                    }
                    finally
                    {
                        productEdit.Dispose();
                        productEdit = null;
                    }
                }
            }
        }

        private void toolStripMainAdd_Click(object sender, EventArgs e)
        {
            NewProductGroupForm frm = new NewProductGroupForm();
            try
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    AdminProductGroupEdit productEdit = new AdminProductGroupEdit(frm.NewProductGroup);
                    try
                    {
                        if (productEdit.ShowDialog(this) == DialogResult.OK)
                        {
                            LoadGroups();
                        }
                    }
                    finally
                    {
                        productEdit.Dispose();
                        productEdit = null;
                    }
                }
            }
            finally
            {
                frm.Dispose();
                frm = null;
            }
        }

        private void toolStripMainRefresh_Click(object sender, EventArgs e)
        {
            toolStripMainEdit.Enabled = false;
            LoadGroups();
        }

        private void lstProductGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripMainEdit.Enabled = lstProductGroups.SelectedItems.Count > 0;
        }

        #endregion Private Methods
    }
}
