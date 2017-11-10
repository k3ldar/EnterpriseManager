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
 *  File: AdminTreatmentGroups.cs
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
using Library.BOL.Treatments;

using POS.Base.Classes;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation

namespace POS.WebsiteAdministration.Forms.Treatments
{
    public partial class AdminTreatmentGroups : POS.Base.Controls.BaseTabControl
    {
        #region Private Members

        private TreatmentGroups _Groups;

        #endregion Private Members

        #region Constructors

        public AdminTreatmentGroups()
        {
            InitializeComponent();

            if (!AppController.ApplicationRunning)
                return;

            lstProductGroups.Height += 24;

            toolStripMainAdd.Image = POS.Base.Icons.AddIcon();
            toolStripMainDelete.Image = POS.Base.Icons.DeleteIcon();
            toolStripMainEdit.Image = POS.Base.Icons.EditIcon();
            toolStripMainRefresh.Image = POS.Base.Icons.RefreshIcon();

            toolStripMainEdit.Enabled = false;
            RebuildContextMenu(toolStripMain, contextMenuList);

            LoadGroups();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            colHeaderName.Text = LanguageStrings.AppName;
            colHeaderSortOrder.Text = LanguageStrings.AppSortOrder;

            string StatusText = LanguageStrings.AppTreatmentGroupFoundMulti;

            if (_Groups.Count == 1)
                StatusText = LanguageStrings.AppTreatmentGroupFoundSingle;

            toolStripStatusLabelCount.Text = String.Format(StatusText, _Groups.Count);

            toolStripMainAdd.Text = LanguageStrings.AppHintNew;
            toolStripMainDelete.Text = LanguageStrings.AppHintDelete;
            toolStripMainRefresh.Text = LanguageStrings.AppHintRefresh;
            toolStripMainEdit.Text = LanguageStrings.AppHintEdit;
        }

        protected override void SetPermissions()
        {
            toolStripMainAdd.Enabled = AppController.ActiveUser.HasPermissionWebsite(
                SecurityEnums.SecurityPermissionsWebsite.AdministerTreatmentGroups);
            toolStripMainDelete.Enabled = false;
        }

        public override int GetStatusCount()
        {
            return (statusStrip1.Items.Count);
        }

        public override string GetStatusHint(int index)
        {
            return (statusStrip1.Items[index].ToolTipText);
        }

        public override string GetStatusText(int index)
        {
            return (statusStrip1.Items[index].Text);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadGroups()
        {
            this.Cursor = Cursors.WaitCursor;
            lstProductGroups.BeginUpdate();
            try
            {
                lstProductGroups.Items.Clear();

                _Groups = TreatmentGroups.Get();

                foreach (TreatmentGroup group in _Groups)
                {
                    ListViewItem item = lstProductGroups.Items.Add(group.Description);
                    item.SubItems.Add(group.SortOrder.ToString());
                    item.SubItems.Add(group.ID.ToString());
                }

                string StatusText = LanguageStrings.AppTreatmentGroupFoundMulti;

                if (_Groups.Count == 1)
                    StatusText = LanguageStrings.AppTreatmentGroupFoundSingle;

                toolStripStatusLabelCount.Text = String.Format(StatusText, _Groups.Count);
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
                TreatmentGroup group = TreatmentGroups.Get(Convert.ToInt32(itm.SubItems[2].Text));

                if (group != null)
                {
                    AdminTreatmentGroupEdit productEdit = new AdminTreatmentGroupEdit(group);
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
            TreatmentGroups.Create(AppController.ActiveUser, LanguageStrings.AppTreatmentGroupNew);
            LoadGroups();
        }

        private void toolStripMainEdit_Click(object sender, EventArgs e)
        {
            lstProductGroups_DoubleClick(sender, e);
        }

        private void toolStripMainRefresh_Click(object sender, EventArgs e)
        {
            LoadGroups();
        }

        private void lstProductGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripMainEdit.Enabled = lstProductGroups.SelectedItems.Count > -1;
        }

        private void toolStripMainDelete_Click(object sender, EventArgs e)
        {
            if (ShowHardConfirm(LanguageStrings.AppTreatmentGroupDelete,
                LanguageStrings.AppTreatmentGroupDeletePrompt))
            {
                foreach (ListViewItem itm in lstProductGroups.SelectedItems)
                {
                    TreatmentGroup group = TreatmentGroups.Get(Convert.ToInt32(itm.SubItems[2].Text));

                    if (group != null)
                    {
                        if (group.Treatments.Count > 0)
                            ShowInformation(LanguageStrings.AppTreatmentGroupDelete,
                                LanguageStrings.AppTreatmentGroupDeleteContainsTreatments);
                        else
                        {
                            group.Delete(AppController.ActiveUser);
                            lstProductGroups.Items.Remove(itm);
                        }
                    }
                }
            }
        }

        #endregion Private Methods
    }
}
