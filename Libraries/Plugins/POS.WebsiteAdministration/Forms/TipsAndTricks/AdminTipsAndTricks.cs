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
 *  File: AdminTipsAndTricks.cs
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

using SharedBase;
using SharedBase.BOL.TipsTricks;

using POS.Base.Classes;

#pragma warning disable IDE1006

namespace POS.WebsiteAdministration.Forms.TipsAndTricks
{
    public partial class AdminTipsAndTricks : POS.Base.Controls.BaseTabControl
    {
        #region Constructors

        public AdminTipsAndTricks()
        {
            InitializeComponent();

            toolStripMainAdd.Image = POS.Base.Icons.AddIcon();
            toolStripMainDelete.Image = POS.Base.Icons.DeleteIcon();
            toolStripMainEdit.Image = POS.Base.Icons.EditIcon();
            toolStripMainRefresh.Image = POS.Base.Icons.RefreshIcon();

            toolStripMainEdit.Enabled = false;

            if (!AppController.ApplicationRunning)
                return;

            RebuildContextMenu(toolStripMain, contextMenuList);

            LoadHintsAndTips();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            colHeaderName.Text = LanguageStrings.AppName;
            colHeaderShowOnWeb.Text = LanguageStrings.AppShowOnWebsite;

            toolStripMainAdd.Text = LanguageStrings.AppHintNew;
            toolStripMainDelete.Text = LanguageStrings.AppHintDelete;
            toolStripMainRefresh.Text = LanguageStrings.AppHintRefresh;
            toolStripMainEdit.Text = LanguageStrings.AppHintEdit;


            LoadHintsAndTips();
        }

        protected override void SetPermissions()
        {
            toolStripMainAdd.Enabled = AppController.ActiveUser.HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.AdministerTipsTricks);
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

        private void LoadHintsAndTips()
        {
            this.Cursor = Cursors.WaitCursor;
            lstHints.BeginUpdate();
            try
            {
                lstHints.Items.Clear();
                TipsTricks tricks = AppController.Administration.TipsTricksGet(1, 1000);

                foreach (TipsTrick trick in tricks)
                {
                    ListViewItem item = lstHints.Items.Add(trick.Name);
                    item.SubItems.Add(trick.ShowOnWeb ? StringConstants.YES : StringConstants.NO);
                    item.SubItems.Add(trick.ID.ToString());
                }

                toolStripStatusLabelCount.Text = String.Format(LanguageStrings.AppTipTrickCount, tricks.Count);
            }
            finally
            {
                lstHints.EndUpdate();
                this.Cursor = Cursors.Arrow;
            }
        }

        private void lstHints_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in lstHints.SelectedItems)
            {
                TipsTrick trick = AppController.Administration.TipsTricksGet(Convert.ToInt32(itm.SubItems[2].Text));

                if (trick != null)
                {
                    AdminTipsAndTricksEdit tte = new AdminTipsAndTricksEdit(trick);
                    try
                    {
                        tte.ShowDialog(this);
                    }
                    finally
                    {
                        tte.Dispose();
                        tte = null;
                    }

                    LoadHintsAndTips();
                }
            }
        }

        private void toolStripMainAdd_Click(object sender, EventArgs e)
        {
            TipsTrick newtrick = new TipsTrick(-1, LanguageStrings.AppTipTrickNew, false, -1, String.Empty);
            newtrick = AppController.Administration.TipsTrickCreate(newtrick);
            AdminTipsAndTricksEdit tte = new AdminTipsAndTricksEdit(newtrick);
            try
            {
                tte.ShowDialog();
            }
            finally
            {
                tte.Dispose();
                tte = null;
            }

            LoadHintsAndTips();
        }

        private void toolStripMainDelete_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMainEdit_Click(object sender, EventArgs e)
        {
            lstHints_DoubleClick(sender, e);
        }

        private void toolStripMainRefresh_Click(object sender, EventArgs e)
        {
            LoadHintsAndTips();
        }

        private void lstHints_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripMainEdit.Enabled = lstHints.SelectedItems.Count > 0;
            toolStripMainDelete.Enabled = lstHints.SelectedItems.Count > 0;
        }

        #endregion Private Members
    }
}
